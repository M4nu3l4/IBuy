using System;
using System.ComponentModel.DataAnnotations;

namespace IBuy.API.DTOs
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Producer { get; set; } = default!;

        public string? Description { get; set; }
        public string? Image { get; set; }
        public bool IsBestSeller { get; set; }
    }
}
