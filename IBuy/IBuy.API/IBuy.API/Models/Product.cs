using IBuy.API.Models;

namespace IBuy.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public required string Producer { get; set; }

        public string? Description { get; set; }
        public string? Image { get; set; }
        public bool IsBestSeller { get; set; }
    }

}
