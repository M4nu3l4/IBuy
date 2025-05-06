using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IBuy.API.Data;
using IBuy.API.Models;
using IBuy.API.DTOs;

namespace IBuy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IBuyDbContext _context;

        public ProductController(IBuyDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name,
                    Quantity = p.Quantity,
                    Price = p.Price,
                    Producer = p.Producer,
                    Description = p.Description,
                    Image = p.Image,
                    IsBestSeller = p.IsBestSeller
                })
                .ToListAsync();

            return Ok(products);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.Id == id)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Image = p.Image,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name,
                    Quantity = p.Quantity,
                    Producer = p.Producer,
                    IsBestSeller = p.IsBestSeller
                })
                .FirstOrDefaultAsync();

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet("category/{categoryName}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByCategory(string categoryName)
        {
            var decodedCategory = Uri.UnescapeDataString(categoryName).ToLower();

            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Name.ToLower() == decodedCategory)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Image = p.Image,
                    CategoryName = p.Category.Name,
                    Quantity = p.Quantity
                })
                .ToListAsync();

            if (!products.Any())
                return NotFound("Nessun prodotto trovato per la categoria selezionata.");

            return Ok(products);
        }

        [Authorize(Roles = "AdminBe,AdminFe")]
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            product.Id = Guid.NewGuid();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [Authorize(Roles = "AdminBe,AdminFe")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Product updatedProduct)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.Quantity = updatedProduct.Quantity;
            product.CategoryId = updatedProduct.CategoryId;
            product.Producer = updatedProduct.Producer;
            product.Image = updatedProduct.Image;
            product.IsBestSeller = updatedProduct.IsBestSeller;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "AdminBe,AdminFe")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
