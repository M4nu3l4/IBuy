using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IBuy.API.Data;
using IBuy.API.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using IBuy.API.DTOs;
using Microsoft.EntityFrameworkCore;
using IBuy.API.Services;

namespace IBuy.API.Controllers
{
    [ApiController]
    [Route("api/purchase")]
    public class PurchaseController : ControllerBase
    {
        private readonly IBuyDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly MailjetEmailService _emailService;
        private readonly ILogger<PurchaseController> _logger;

        public PurchaseController(
            IBuyDbContext context,
            UserManager<IdentityUser> userManager,
            MailjetEmailService emailService,
            ILogger<PurchaseController> logger)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] List<CartItemDto> cartItems)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var userName = User.FindFirstValue(ClaimTypes.Name) ?? "Cliente";

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userEmail))
            {
                _logger.LogWarning("Utente non autenticato correttamente.");
                return Unauthorized();
            }

            decimal totalAmount = 0;

            foreach (var item in cartItems)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null)
                    return NotFound($"Prodotto con ID {item.ProductId} non trovato.");

                if (product.Quantity < item.Quantity)
                    return BadRequest($"Quantità insufficiente per il prodotto: {product.Name}");

                product.Quantity -= item.Quantity;

                var transaction = new Transaction
                {
                    Id = Guid.NewGuid(),
                    ProductId = product.Id,
                    UserId = userId,
                    Quantity = item.Quantity,
                    Amount = product.Price * item.Quantity,
                    Date = DateTime.UtcNow,
                    Type = "Vendita",
                    UserEmail = userEmail,
                    Timestamp = DateTime.UtcNow,
                    OrderStatus = "Attivo",
                    RequestedAction = null,
                    CustomerNote = null,
                    IsPendingApproval = false
                };

                totalAmount += transaction.Amount;
                _context.Transactions.Add(transaction);
            }

            await _context.SaveChangesAsync();

            try
            {
                await _emailService.SendPurchaseConfirmationEmailAsync(userEmail, userName, cartItems, totalAmount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante l'invio dell'email di conferma acquisto.");
            }

            return Ok(new
            {
                Message = "Pagamento completato con successo.",
                Totale = totalAmount
            });
        }

        [Authorize]
        [HttpGet("orders")]
        public async Task<IActionResult> GetUserOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            var transactions = await _context.Transactions
                .Where(t => t.UserId == userId && t.Type == "Vendita")
                .Include(t => t.Product)
                .OrderByDescending(t => t.Date)
                .ToListAsync();

            var orders = transactions.Select(t => new
            {
                id = t.Id,
                productName = t.Product.Name,
                quantity = t.Quantity,
                total = t.Amount,
                date = t.Date.ToLocalTime().ToString("dd/MM/yyyy HH:mm"),
                orderStatus = t.OrderStatus,
                requestedAction = t.RequestedAction
            });

            return Ok(orders);
        }

        [Authorize(Roles = "AdminOffice")]
        [HttpGet("all-orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _context.Transactions
                .Include(t => t.Product)
                .OrderByDescending(t => t.Date)
                .ToListAsync();

            return Ok(orders);
        }

        [Authorize]
        [HttpPut("request-action/{id}")]
        public async Task<IActionResult> RequestOrderAction(Guid id, [FromBody] OrderActionRequestDto dto)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (transaction.UserId != userId)
                return Forbid();

            if (transaction.OrderStatus != "Attivo")
                return BadRequest("L'ordine non è più modificabile.");

            transaction.RequestedAction = dto.Action;
            transaction.CustomerNote = dto.Note;
            transaction.IsPendingApproval = true;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Richiesta inviata con successo." });
        }

        [Authorize(Roles = "AdminOffice")]
        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> CancelOrder(Guid id)
        {
            var transaction = await _context.Transactions.Include(t => t.Product).FirstOrDefaultAsync(t => t.Id == id);
            if (transaction == null) return NotFound();

            if (transaction.OrderStatus != "Attivo")
                return BadRequest("L'ordine è già stato gestito.");

            transaction.OrderStatus = "Annullato";
            transaction.Product.Quantity += transaction.Quantity;
            transaction.Amount = 0;
            transaction.IsPendingApproval = false;

            await _context.SaveChangesAsync();

            try
            {
                var user = await _userManager.FindByIdAsync(transaction.UserId);
                var userName = user?.UserName ?? "Cliente";
                await _emailService.SendOrderCanceledEmailAsync(transaction.UserEmail, userName, transaction.Product.Name, transaction.Quantity, transaction.Date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante l'invio email di annullamento.");
            }

            return Ok(new { message = "Ordine annullato correttamente." });
        }

        [Authorize(Roles = "AdminOffice")]
        [HttpPut("return/{id}")]
        public async Task<IActionResult> ReturnOrder(Guid id)
        {
            var transaction = await _context.Transactions.Include(t => t.Product).FirstOrDefaultAsync(t => t.Id == id);
            if (transaction == null) return NotFound();

            if (transaction.OrderStatus != "Attivo")
                return BadRequest("L'ordine è già stato gestito.");

            transaction.OrderStatus = "Reso";
            transaction.Product.Quantity += transaction.Quantity;
            transaction.Amount = 0;
            transaction.IsPendingApproval = false;

            await _context.SaveChangesAsync();

            try
            {
                var user = await _userManager.FindByIdAsync(transaction.UserId);
                var userName = user?.UserName ?? "Cliente";
                await _emailService.SendOrderReturnedEmailAsync(transaction.UserEmail, userName, transaction.Product.Name, transaction.Quantity, transaction.Date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante l'invio email di reso.");
            }

            return Ok(new { message = "Ordine restituito con successo." });
        }
    }
}
