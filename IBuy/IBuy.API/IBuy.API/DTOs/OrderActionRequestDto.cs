using IBuy.API.DTOs; // Add this directive at the top of the file

// Ensure the OrderActionRequestDto class is defined in the IBuy.API.DTOs namespace
namespace IBuy.API.DTOs
{
    public class OrderActionRequestDto
    {
        public string Action { get; set; } // Example property
        public string? Note { get; set; } // Example property
    }
}
