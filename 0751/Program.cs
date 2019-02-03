using System;
using System.Collections.Generic;

namespace _0751
{
    public class Solution
    {
        public IList<string> IpToCIDR(string ip, int n)
        {
            var answer = new List<string>();
            var nn = (long)n;

            var start = IpToLong(ip);
            while (nn > 0)
            {
                var step = LowBit(start);
                while (step > nn)
                {
                    step >>= 1;
                }
                var mask = 32 - (BitLen(step) - 1);
                answer.Add($"{LongToIp(start)}/{mask}");
                start += step;
                nn -= step;
            }

            return answer;
        }

        private long LowBit(long x)
        {
            return x & -x;
        }

        private int BitLen(long x)
        {
            var len = 0;
            while (x > 0)
            {
                len++;
                x >>= 1;
            }
            return len;
        }

        private long IpToLong(string ip)
        {
            var parts = ip.Split(".");
            return (Int64.Parse(parts[0]) << 24) + 
                   (Int64.Parse(parts[1]) << 16) +
                   (Int64.Parse(parts[2]) << 8) +
                   Int64.Parse(parts[3]);
        }

        private string LongToIp(long x)
        {
            return $"{x >> 24}.{(x >> 16) & 255}.{(x >> 8) & 255}.{x & 255}";
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
