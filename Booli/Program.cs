using Booli.Database;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Booli
{
    class Program
    {
        public static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            string baseUrl = "https://api.booli.se/";
            string callerId = ConfigurationManager.AppSettings["callerId"];
            string privateKey = ConfigurationManager.AppSettings["privateKey"];
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            string unique = Get16CharacterRandomString();
            string url = $"{baseUrl}sold?q=stockholm&limit=500&callerId={callerId}&time={timestamp}&unique={unique}&hash={Hash(callerId + timestamp + privateKey + unique)}";
            using (Stream s = client.GetStreamAsync(url).Result)
            using (StreamReader sr = new StreamReader(s))
            {
                string jsonString = sr.ReadToEnd();
                var data = JsonSerializer.Deserialize<Database.Query>(jsonString);
                SaveDataToDatabase(data);
            }
        }

        private static void SaveDataToDatabase(Query data)
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

        public static string Hash(string stringToHash)
        {
            using (var sha1 = new SHA1Managed())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(stringToHash))).Replace("-", "");
            }
        }

        public static string Get16CharacterRandomString()
        {
            return (Path.GetRandomFileName() + Path.GetRandomFileName()).Replace(".", "").Substring(0, 16);
        }
    }
}
