using System;

namespace IBuy.API.DTOs
{
    public class WishlistItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public string? Description{ get; set; }
    }
}
