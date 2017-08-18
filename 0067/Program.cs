using System;
using System.Linq;
using System.Text;

namespace _67
{
    public class Solution
    {
        public string AddBinary(string a, string b)
        {
            var sb = new StringBuilder();
            a = new String(a.Reverse().ToArray());
            b = new String(b.Reverse().ToArray());

            var rest = 0;
            var i = 0;
            var j = 0;
            while (i < a.Length || j < b.Length)
            {
                var sum = 0;
                if (i < a.Length)
                {
                    sum += (byte)a[i] - 48;
                    i++;
                }
                if (j < b.Length)
                {
                    sum += (byte)b[j] - 48;
                    j++;
                }
                sum += rest;
                sb.Append((sum % 2).ToString());
                rest = sum / 2;
            }

            if (rest > 0)
            {
                sb.Append(rest.ToString());
            }

            return new String(sb.ToString().Reverse().ToArray());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().AddBinary("111", "1"));
        }
    }
}
