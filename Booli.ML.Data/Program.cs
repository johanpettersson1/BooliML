using Booli.ML.Data.Database;
using Booli.ML.Data.Database.ListingsModel;
using Booli.ML.Data.Database.SoldModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Booli.ML.Data
{
    internal class Program
    {
        public static HttpClient client = new HttpClient();
        public static string baseUrl = "https://api.booli.se/";
        public static string callerId = ConfigurationManager.AppSettings["callerId"];
        public static string privateKey = ConfigurationManager.AppSettings["privateKey"];

        private static void Main(string[] args)
        {
            Console.WriteLine("=============== Scraping Start ===============");
            List<Task> tasks = new List<Task>();
            Task t1 = Task.Run(() => ScrapeSoldData());
            Task t2 = Task.Run(() => ScrapeListingsData());
            Task.WaitAll(new Task[] { t1, t2 });
            Console.WriteLine("=============== Scraping End ===============");
            Console.ReadKey();
        }

        private static void ScrapeListingsData()
        {
            string queryValue = "sverige"; // stockholm, nacka, etc.
            long limit = 500; // max 500. src: https://www.booli.se/p/api/
            long offset = 0;
            long max = int.MaxValue;
            while (offset < max)
            {
                long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                string unique = Helpers.Get16CharacterRandomString();
                string url = $"{baseUrl}listings?q={queryValue}&limit={limit}&offset={offset}&callerId={callerId}&time={timestamp}&unique={unique}&hash={Helpers.Hash(callerId + timestamp + privateKey + unique)}";
                using (Stream s = client.GetStreamAsync(url).Result)
                using (StreamReader sr = new StreamReader(s))
                {
                    string jsonString = sr.ReadToEnd();
                    var data = JsonSerializer.Deserialize<ListingsQuery>(jsonString);
                    Commands.SaveListings(data.listings);
                    max = data.totalCount;
                    Console.WriteLine($"ScrapeListingsData: {String.Format("{0:0.00}", (float)100 * offset / (float)data.totalCount)}%");
                }

                offset += 500;
                Thread.Sleep(1000);
            }
        }

        private static void ScrapeSoldData()
        {
            string queryValue = "sverige"; // stockholm, nacka, etc.
            long limit = 500; // max 500. src: https://www.booli.se/p/api/
            long offset = 0;
            long max = int.MaxValue;
            while (offset < max)
            {
                long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                string unique = Helpers.Get16CharacterRandomString();
                string url = $"{baseUrl}sold?q={queryValue}&limit={limit}&offset={offset}&callerId={callerId}&time={timestamp}&unique={unique}&hash={Helpers.Hash(callerId + timestamp + privateKey + unique)}";
                using (Stream s = client.GetStreamAsync(url).Result)
                using (StreamReader sr = new StreamReader(s))
                {
                    string jsonString = sr.ReadToEnd();
                    var data = JsonSerializer.Deserialize<SoldQuery>(jsonString);
                    Commands.SaveSold(data.sold);
                    max = data.totalCount;
                    Console.WriteLine($"ScrapeSoldData: {String.Format("{0:0.00}", (float)100 * offset / (float)data.totalCount)}%");
                }

                offset += 500;
                Thread.Sleep(1000);
            }
        }
    }
}