using IBuy.API.DTOs; 

namespace IBuy.API.DTOs
{
    public class OrderActionRequestDto
    {
        public string Action { get; set; } 
        public string? Note { get; set; } 
    }
}
