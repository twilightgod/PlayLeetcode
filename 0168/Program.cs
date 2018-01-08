using System;
using System.Linq;
using System.Text;

namespace _0168
{
    public class Solution
    {
        public string ConvertToTitle(int n)
        {
            var sb = new StringBuilder();
            while (n > 0)
            {
                var mod = n % 26;
                sb.Append((char)(mod == 0 ? 'Z' : (mod) - 1 + 'A'));
                n /= 26;
                if (mod == 0)
                {
                    n--;
                }
            }
            return new String(sb.ToString().Reverse().ToArray());
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
