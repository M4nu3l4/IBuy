using System;

namespace IBuy.API.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Producer { get; set; } = default!;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public bool IsBestSeller { get; set; }
    }
}
