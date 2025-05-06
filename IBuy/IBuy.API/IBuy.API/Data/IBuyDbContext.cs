using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IBuy.API.Models;
using IBuy.API.Data.Seed;

namespace IBuy.API.Data
{
    public class IBuyDbContext : IdentityDbContext
    {
        public IBuyDbContext(DbContextOptions<IBuyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed(); // richiama il tuo seed completo
        }
    }
}
