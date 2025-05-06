namespace IBuy.API.DTOs
{
    public class CartItemDto
    {
        public Guid ProductId { get; set; }
        public required string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
