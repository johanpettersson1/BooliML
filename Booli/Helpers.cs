using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Booli
{
    public class Helpers
    {
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
