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
                    var sold = _context.Solds.Where(s => s.booliId == property.booliId).FirstOrDefault();
                    if (sold != null)
                    {
                        _context.Solds.Remove(sold);
                        _context.SaveChanges();
                    }

                    var source = _context.Sources.Where(s => s.id == property.source.id).FirstOrDefault();
                    if (source == null)
                    {
                        source = new Source { id = property.source.id, name = property.source.name, type = property.source.type, url = property.source.url };
                        _context.Sources.Add(source);
                        _context.SaveChanges();
                    }

                    property.source = source;
                    _context.Solds.Add(property);
                    _context.SaveChanges();
                }
            }
        }
    }
}
