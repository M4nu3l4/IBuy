using System;
using System.Collections.Generic;

namespace IBuy.API.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        // Relazione uno-a-molti: una categoria può avere più prodotti
        public ICollection<Product>? Products { get; set; }
    }
}

