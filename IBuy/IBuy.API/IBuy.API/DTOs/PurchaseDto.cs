namespace IBuy.API.DTOs
{
    public class PurchaseDto
    {
        public Guid TransactionId { get; set; }
        public string ProductName { get; set; } = default!;
        public decimal Amount { get; set; }
        public string Type { get; set; } = default!;
        public DateTime Date { get; set; }
    }
}
