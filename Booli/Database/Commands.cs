using System.Linq;

namespace Booli.Database
{
    public class Commands
    {
        public static void SaveDataToDatabase(Query data)
        {
            foreach (var item in data.sold)
            {
                using (var _context = new BooliContext())
                {
                    var sold = _context.Solds.Where(s => s.booliId == item.booliId).FirstOrDefault();
                    if (sold != null)
                    {
                        _context.Solds.Remove(sold);
                        _context.SaveChanges();
                    }

                    var source = _context.Sources.Where(s => s.id == item.source.id).FirstOrDefault();
                    if (source == null)
                    {
                        source = new Source { id = item.source.id, name = item.source.name, type = item.source.type, url = item.source.url };
                        _context.Sources.Add(source);
                        _context.SaveChanges();
                    }

                    item.source = source;
                    _context.Solds.Add(item);
                    _context.SaveChanges();
                }
            }
        }
    }
}
