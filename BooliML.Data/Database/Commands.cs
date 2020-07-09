using System.Collections.Generic;
using System.Linq;

namespace Booli.Database
{
    public class Commands
    {
        public static void Save(List<Sold> properties)
        {
            foreach (var property in properties)
            {
                using (var _context = new BooliContext())
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
                        source = new Source { id = property.source.id, name = property.source.name, type = property.source.type, url = property.source.url };
                        _context.Sources.Add(source);
                    }

                    property.source = source;
                    _context.Sold.Add(property);
                    _context.SaveChanges();
                }
            }
        }
    }
}
