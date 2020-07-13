using Booli.ML.Data.Database;
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
        public async Task<ActionResult<List<ViewData>>> GetListing(string filter)
        {
            if (filter == null)
                return await _context.Listings.Include(l => l.location).ThenInclude(a => a.address)
                    .Select(l => new ViewData { BooliId = l.booliId, StreetAddress = l.location.address.streetAddress, County = l.location.region.countyName, Municipality = l.location.region.municipalityName })
                    .Distinct()
                    .OrderBy(vd => vd.StreetAddress)
                    .Take(10).ToListAsync();

            return await _context.Listings.Include(l => l.location).ThenInclude(a => a.address)
                .Select(l => new ViewData { BooliId = l.booliId, StreetAddress = l.location.address.streetAddress, County = l.location.region.countyName, Municipality = l.location.region.municipalityName })
                .Distinct()
                .Where(vd => vd.StreetAddress.Contains(filter))
                .OrderBy(vd => vd.StreetAddress).Take(10).ToListAsync();
        }
    }

    public class ViewData
    {
        public int BooliId { get; set; }
        public string StreetAddress { get; set; }
        public string County { get; set; }
        public string Municipality { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ViewData data &&
                   StreetAddress == data.StreetAddress &&
                   County == data.County &&
                   Municipality == data.Municipality;
        }
    }
}