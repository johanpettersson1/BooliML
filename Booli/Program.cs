using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

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
            string url = $"{baseUrl}listings?q=nacka&callerId={callerId}&time={timestamp}&unique={unique}&hash={Hash(callerId + timestamp + privateKey + unique)}";
            using (Stream s = client.GetStreamAsync(url).Result)
            using (StreamReader sr = new StreamReader(s))
            {
                string line = sr.ReadToEnd();
                Console.WriteLine(line);
                Console.ReadLine();
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
