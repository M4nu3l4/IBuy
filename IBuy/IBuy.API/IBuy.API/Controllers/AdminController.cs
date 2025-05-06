using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IBuy.API.DTOs;

namespace IBuy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "AdminOffice")]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // POST: api/admin/assign-role
        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] RoleAssignmentDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) return NotFound("Utente non trovato");

            if (!await _roleManager.RoleExistsAsync(dto.Role))
                await _roleManager.CreateAsync(new IdentityRole(dto.Role));

            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles); // rimuove ruoli attuali
            await _userManager.AddToRoleAsync(user, dto.Role);

            return Ok($"Ruolo '{dto.Role}' assegnato a {dto.Email}");
        }

        // GET: api/admin/users
        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            var result = new List<object>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                result.Add(new { user.Email, user.UserName, Roles = roles });
            }

            return Ok(result);
        }

        // DELETE: api/admin/delete-user?email=...
        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser([FromQuery] string email)
        {
            // LOG PER DEBUG - PUOI RIMUOVERE DOPO
            Console.WriteLine($"Tentativo di eliminare utente con email: {email}");

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return NotFound("Utente non trovato");

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return Ok($"Utente {email} eliminato.");
            else
                return BadRequest("Errore durante l'eliminazione.");
        }
    }
}


