// IBuy.API/DTOs/CustomerDetailsDto.cs
using System.ComponentModel.DataAnnotations;

public class CustomerDetailsDto
{
    [Required]
    public string Email { get; set; } = default!;

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

    // NUOVI CAMPI
    [MaxLength(25)]
    public string? CreditCard { get; set; }
    [MaxLength(34)]
    public string? IBAN { get; set; }
}
