using System;
using System.Collections.Generic;
using System.Text;

namespace _0535
{
    public class Codec
    {
        Dictionary<string, string> urlMap = new Dictionary<string, string>();
        Random random = new Random();

        // Encodes a URL to a shortened URL
        public string encode(string longUrl)
        {
            while (true)
            {
                var key = GetHash();
                if (!urlMap.ContainsKey(key))
                {
                    urlMap[key] = longUrl;
                    return key;
                }
            }
        }

        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl)
        {
            return urlMap[shortUrl];
        }

        private string GetHash()
        {
            const string codes = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var key = (long)(random.NextDouble() * Int64.MaxValue);
            var sb = new StringBuilder();
            for (var i = 0; i < 7; ++i)
            {
                sb.Append(key % 62);
                key /= 62;
            }
            return sb.ToString();
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.decode(codec.encode(url));

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
