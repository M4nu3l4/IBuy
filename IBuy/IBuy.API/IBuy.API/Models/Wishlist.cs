using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IBuy.API.Models
{
    public class Wishlist
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        public string UserId { get; set; } = string.Empty;

        public Product? Product { get; set; }
    }
}
