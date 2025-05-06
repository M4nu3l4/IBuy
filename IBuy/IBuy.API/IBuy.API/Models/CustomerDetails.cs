using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class CustomerDetails
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = default!;
    [ForeignKey("UserId")]
    public IdentityUser User { get; set; } = default!;

    [MaxLength(100)]
    public string? Address { get; set; }
    [MaxLength(50)]
    public string? City { get; set; }
    [MaxLength(10)]
    public string? Cap { get; set; }
    [MaxLength(20)]
    public string? Phone { get; set; }
    [MaxLength(50)]
    public string? DiscountCode { get; set; }
    [MaxLength(25)]
    public string? CreditCard { get; set; }
    [MaxLength(34)]
    public string? IBAN { get; set; }
}
