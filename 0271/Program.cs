using System;
using System.Collections.Generic;
using System.Text;

namespace _0271
{
    public class Codec
    {

        // Encodes a list of strings to a single string.
        public string encode(IList<string> strs)
        {
            var sb = new StringBuilder();
            sb.Append(strs.Count.ToString("X4"));
            foreach (var s in strs)
            {
                sb.Append(s.Length.ToString("X4"));
                sb.Append(s);
            }
            return sb.ToString();
        }

        // Decodes a single string to a list of strings.
        public IList<string> decode(string s)
        {
            var strs = new List<string>();

            var n = Int32.Parse(s.Substring(0, 4), System.Globalization.NumberStyles.HexNumber);
            s = s.Substring(4);

            while (n-- > 0)
            {
                var len = Int32.Parse(s.Substring(0, 4), System.Globalization.NumberStyles.HexNumber);
                s = s.Substring(4);
                strs.Add(s.Substring(0, len));
                s = s.Substring(len);
            }

            return strs;
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.decode(codec.encode(strs));

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
