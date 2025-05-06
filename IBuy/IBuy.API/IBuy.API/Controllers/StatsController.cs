using Microsoft.AspNetCore.Mvc;
using IBuy.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace IBuy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class StatsController : ControllerBase
    {
        private readonly IBuyDbContext _context;

        public StatsController(IBuyDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "AdminOffice")]
        [HttpGet("guadagno-totale")]
        public async Task<IActionResult> GetTotalEarnings()
        {
            var totale = await _context.Transactions.SumAsync(t => t.Amount);
            return Ok(new { guadagnoTotale = totale });
        }

        [Authorize(Roles = "AdminOffice")]
        [HttpGet("movimenti")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var movimenti = await _context.Transactions
                .Include(t => t.Product)
                .OrderByDescending(t => t.Timestamp)
                .ToListAsync();

            return Ok(movimenti);
        }
    }
}
