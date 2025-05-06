using IBuy.API.Models;

public class Transaction
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public DateTime Timestamp { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
    public string UserEmail { get; set; }
    public required string UserId { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public string OrderStatus { get; set; }
    public string? RequestedAction { get; set; } // Added this property
    public string? CustomerNote { get; set; } // Added this property
    public bool IsPendingApproval { get; set; } // Added this property
}
