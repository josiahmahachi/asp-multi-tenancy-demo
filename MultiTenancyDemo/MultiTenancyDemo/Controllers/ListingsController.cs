using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTenancyDemo.Contracts.Factories;
using MultiTenancyDemo.Data;

namespace MultiTenancyDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly TenantDbContext _context;

        public ListingsController(ITenantDbContextFactory dbContextFactory)
        {
            _context = dbContextFactory.GetDbContext();
        }

        [HttpGet]
        public async Task<ActionResult> GetListings()
        {
            var listings = await _context.Listings.ToListAsync();

            return Ok(listings);
        }
    }
}
