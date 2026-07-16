using System;
using System.Collections.Generic;

namespace IBuy.API.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        
        public ICollection<Product>? Products { get; set; }
    }
}

