using Booli.ML.Data.Database;
using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;

namespace Booli.ML.Data
{
    internal class Program
    {
        public static HttpClient client = new HttpClient();

        //@TODO: make two methods. One for scraping SOLD and one for scraping listings.
        private static void Main(string[] args)
        {
            string baseUrl = "https://api.booli.se/";
            string callerId = ConfigurationManager.AppSettings["callerId"];
            string privateKey = ConfigurationManager.AppSettings["privateKey"];
            string queryKey = "sold"; // possible values: [listings, sold, areas]
            string queryValue = "sverige"; // stockholm, nacka, etc.
            long limit = 500; // max 500. src: https://www.booli.se/p/api/
            long offset = 0;
            long max = int.MaxValue;
            while (offset < max)
            {
                long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                string unique = Helpers.Get16CharacterRandomString();
                string url = $"{baseUrl}{queryKey}?q={queryValue}&limit={limit}&offset={offset}&callerId={callerId}&time={timestamp}&unique={unique}&hash={Helpers.Hash(callerId + timestamp + privateKey + unique)}";
                using (Stream s = client.GetStreamAsync(url).Result)
                using (StreamReader sr = new StreamReader(s))
                {
                    string jsonString = sr.ReadToEnd();
                    var data = JsonSerializer.Deserialize<Query>(jsonString);
                    Commands.Save(data.sold);
                    max = data.totalCount;
                    Console.WriteLine($"{String.Format("{0:0.00}", (float)100 * offset / (float)data.totalCount)}%");
                }

                offset += 500;
                Thread.Sleep(500);
            }
        }
    }
}