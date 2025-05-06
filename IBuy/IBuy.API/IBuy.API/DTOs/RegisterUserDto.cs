using System.ComponentModel.DataAnnotations;

namespace IBuy.API.DTOs
{
    public class RegisterUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;

        [Required]
        public string Role { get; set; } = default!; // Es: "Utente", "Amministrativo"
    }
}



