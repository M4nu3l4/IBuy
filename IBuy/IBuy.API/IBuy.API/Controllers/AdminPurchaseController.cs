using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IBuy.API.Data;
using IBuy.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IBuy.API.Controllers
{
    [ApiController]
    [Route("api/purchase")]
    public class AdminPurchaseController : ControllerBase
    {
        private readonly IBuyDbContext _context;

        public AdminPurchaseController(IBuyDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "AdminOffice")]
        [HttpPost("annulla/{id}")]
        public async Task<IActionResult> AnnullaOrdine(Guid id)
        {
            var transazione = await _context.Transactions
                .Include(t => t.Product)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transazione == null)
                return NotFound("Transazione non trovata.");

            if (transazione.Type != "Vendita")
                return BadRequest("Solo le vendite possono essere annullate.");

            transazione.Type = "Annullato";
            transazione.Product.Quantity += transazione.Quantity;
            transazione.Amount = 0;

            await _context.SaveChangesAsync();
            return Ok("Ordine annullato con successo.");
        }

        [Authorize(Roles = "AdminOffice")]
        [HttpPost("reso/{id}")]
        public async Task<IActionResult> ResoOrdine(Guid id)
        {
            var transazione = await _context.Transactions
                .Include(t => t.Product)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transazione == null)
                return NotFound("Transazione non trovata.");

            if (transazione.Type != "Vendita")
                return BadRequest("Solo le vendite possono essere rimborsate.");

            transazione.Type = "Reso";
            transazione.Product.Quantity += transazione.Quantity;
            transazione.Amount *= -1; // Guadagno negativo

            await _context.SaveChangesAsync();
            return Ok("Ordine restituito con successo.");
        }
    }
}
