using IBuy.API.DTOs;
using IBuy.API.Models; // <--- AGGIUNGI per la nuova entità
using IBuy.API.Services;
using Microsoft.AspNetCore.Authorization; // <--- AGGIUNGI per protezione endpoint extra
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;      // <--- AGGIUNGI per .FirstOrDefaultAsync
using System.Security.Claims;             // <--- AGGIUNGI per Claims
// AGGIUNGI usando il tuo ApplicationDbContext (o come si chiama il tuo DbContext)
using IBuy.API.Data;

namespace IBuy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly TokenService _tokenService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IBuyDbContext _context; // <--- AGGIUNGI per accesso DB

        public UserController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            TokenService tokenService,
            SignInManager<IdentityUser> signInManager,
            IBuyDbContext context 
        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var user = new IdentityUser
            {
                UserName = dto.UserName,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            // Assegna ruolo di default
            await _userManager.AddToRoleAsync(user, "Cliente");

            return Ok("Utente registrato correttamente.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user == null)
                    return Unauthorized("Email o password non validi");

                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
                if (!result.Succeeded)
                    return Unauthorized("Email o password non validi");

                var roles = await _userManager.GetRolesAsync(user);

                if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.UserName))
                {
                    return StatusCode(500, "⚠️ Utente trovato ma dati incompleti (Email o Username nulli)");
                }

                var token = _tokenService.CreateToken(user, roles);

                return Ok(new
                {
                    token,
                    email = user.Email,
                    user = user.UserName,
                    roles
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore interno durante il login: {ex.Message}");
            }
        }

        // ----------------------------------------------------------------------
        // --- INIZIO GESTIONE DETTAGLI CLIENTE (CustomerDetails) --------------

        // POST: api/user/customer-details  (crea o aggiorna i dettagli)
        [Authorize]
        [HttpPost("customer-details")]
        public async Task<IActionResult> SaveCustomerDetails([FromBody] CustomerDetailsDto dto)
        {
            try
            {
                var userEmail = User.FindFirstValue(ClaimTypes.Email);
                var user = await _userManager.FindByEmailAsync(userEmail!);
                if (user == null)
                    return NotFound("Utente non trovato");

                var existing = await _context.CustomerDetails.FirstOrDefaultAsync(d => d.UserId == user.Id);

                if (existing == null)
                {
                    var details = new CustomerDetails
                    {
                        UserId = user.Id,
                        Address = dto.Address,
                        City = dto.City,
                        Cap = dto.Cap,
                        Phone = dto.Phone,
                        DiscountCode = dto.DiscountCode,
                        CreditCard = dto.CreditCard,   // <--- AGGIUNGI QUESTI CAMPI!
                        IBAN = dto.IBAN
                    };
                    _context.CustomerDetails.Add(details);
                }
                else
                {
                    existing.Address = dto.Address;
                    existing.City = dto.City;
                    existing.Cap = dto.Cap;
                    existing.Phone = dto.Phone;
                    existing.DiscountCode = dto.DiscountCode;
                    existing.CreditCard = dto.CreditCard;   // <--- AGGIUNGI QUESTI CAMPI!
                    existing.IBAN = dto.IBAN;
                    _context.CustomerDetails.Update(existing);
                }
                await _context.SaveChangesAsync();
                return Ok("Dati cliente salvati/aggiornati con successo.");
            }
            catch (Exception ex)
            {
                // LOGGA ERRORE DETTAGLIATO
                Console.WriteLine("ERRORE Salvataggio CustomerDetails: " + ex.ToString());
                return StatusCode(500, "Errore durante il salvataggio: " + ex.Message);
            }
        }


        // GET: api/user/customer-details   (recupera i dettagli per l'utente autenticato)
        [Authorize]
        [HttpGet("customer-details")]
        public async Task<IActionResult> GetCustomerDetails()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(userEmail!);
            if (user == null)
                return NotFound();

            var details = await _context.CustomerDetails
                .Where(x => x.UserId == user.Id)
                .Select(x => new CustomerDetailsDto
                {
                    Email = user.Email!,
                    Address = x.Address,
                    City = x.City,
                    Cap = x.Cap,
                    Phone = x.Phone,
                    DiscountCode = x.DiscountCode,
                    CreditCard = x.CreditCard,
                    IBAN = x.IBAN
                })
                .FirstOrDefaultAsync();

            return Ok(details);
        }


        // --- FINE GESTIONE DETTAGLI CLIENTE -----------------------------------
        // ----------------------------------------------------------------------
    }
}
