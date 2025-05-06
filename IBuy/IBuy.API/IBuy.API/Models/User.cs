using System.ComponentModel.DataAnnotations;

namespace IBuy.API.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        public string Name { get; set; } = default!;
    }
}
