using System.ComponentModel.DataAnnotations;

namespace IBuy.API.DTOs
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
