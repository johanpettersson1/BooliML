using Booli.ML.Data.Database.ListingsModel;
using Booli.ML.Data.Database.SoldModel;
using System.Collections.Generic;
using System.Linq;

namespace Booli.ML.Data.Database
{
    public class Commands
    {
        public static void SaveSold(List<Sold> properties)
        {
            foreach (var property in properties)
            {
                using (var _context = new BooliMLSoldContext())
                {
                    var sold = _context.Sold.Where(s => s.booliId == property.booliId).FirstOrDefault();
                    if (sold != null)
                    {
                        _context.Sold.Remove(sold);
                        _context.SaveChanges();
                    }

                    var source = _context.Sources.Where(s => s.id == property.source.id).FirstOrDefault();
                    if (source == null)
                    {
                        source = new SoldModel.Source { id = property.source.id, name = property.source.name, type = property.source.type, url = property.source.url };
                        _context.Sources.Add(source);
                    }

                    property.source = source;
                    _context.Sold.Add(property);
                    _context.SaveChanges();
                }
            }
        }

        internal static void SaveListings(List<Listing> listings)
        {
            foreach (var listing in listings)
            {
                using (var _context = new BooliMLListingsContext())
                {
                    var sold = _context.Listings.Where(s => s.booliId == listing.booliId).FirstOrDefault();
                    if (sold != null)
                    {
                        _context.Listings.Remove(sold);
                        _context.SaveChanges();
                    }

                    var source = _context.Sources.Where(s => s.id == listing.source.id).FirstOrDefault();
                    if (source == null)
                    {
                        source = new ListingsModel.Source { id = listing.source.id, name = listing.source.name, type = listing.source.type, url = listing.source.url };
                        _context.Sources.Add(source);
                    }

                    listing.source = source;
                    _context.Listings.Add(listing);
                    _context.SaveChanges();
                }
            }
        }
    }
}