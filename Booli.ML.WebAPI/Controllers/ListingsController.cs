using Booli.ML.Data.Database;
using Booli.ML.Data.Database.ListingsModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booli.ML.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly BooliMLListingsContext _context;

        public ListingsController(BooliMLListingsContext context)
        {
            _context = context;
        }

        // GET: api/Listings/5
        [HttpGet("{filter?}")]
        public async Task<ActionResult<List<Listing>>> GetListing(string filter)
        {
            if (filter == null)
                return await _context.Listings.AsNoTracking().Include(l => l.location.address).Include(l => l.location.region)
                    .Take(10).ToListAsync();

            return await _context.Listings.AsNoTracking().Include(l => l.location.address).Include(l => l.location.region)
            .Where(vd => vd.location.address.streetAddress.Contains(filter)).Take(10).ToListAsync();
        }
    }
}