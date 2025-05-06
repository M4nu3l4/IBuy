using System;
using System.ComponentModel.DataAnnotations;

namespace IBuy.API.DTOs
{
    public class UpdateProductDto
    {
        [Required]
        public Guid Id { get; set; }

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
