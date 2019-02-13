using System;
using System.Text;

namespace _0824
{
    public class Solution
    {
        public string ToGoatLatin(string S)
        {
            var parts = S.Split(' ');
            for (var i = 0; i < parts.Length; ++i)
            {
                var s = parts[i];
                var c = Char.ToLower(s[0]);
                var sb = new StringBuilder();
                if (
                    c == 'a' ||
                    c == 'e' ||
                    c == 'i' ||
                    c == 'o' ||
                    c == 'u'
                    )
                {
                    sb.Append(s);
                }
                else
                {
                    sb.Append(s.Substring(1) + s[0]);
                }
                sb.Append("ma");
                for (var j = 0; j < i + 1; ++j)
                {
                    sb.Append("a");
                }
                parts[i] = sb.ToString();
            }
            return String.Join(' ', parts);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
