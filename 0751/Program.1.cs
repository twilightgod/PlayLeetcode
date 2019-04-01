using System;
using System.Collections.Generic;

namespace _0751_1
{
    public class Solution
    {
        public IList<string> IpToCIDR(string ip, int n)
        {
            var nl = (long)n;
            var ret = new List<string>();
            var start = IpToLong(ip);
            while (nl > 0)
            {
                var cnt = LowBit(start);
                while (cnt > nl)
                {
                    cnt >>= 1;
                }
                ret.Add($"{LongToIp(start)}/{32 - LowBitPos(cnt) + 1}");
                start += cnt;
                nl -= cnt;
            }
            return ret;
        }

        private long LowBit(long x)
        {
            return x & (-x);
        }

        private int LowBitPos(long x)
        {
            var pos = 0;
            while (x > 0)
            {
                pos++;
                x >>= 1;
            }
            return pos;
        }

        private long IpToLong(string ip)
        {
            var parts = ip.Split(".");
            var x = 0l;
            x += Int64.Parse(parts[0]) << 24;
            x += Int64.Parse(parts[1]) << 16;
            x += Int64.Parse(parts[2]) << 8;
            x += Int64.Parse(parts[3]);
            return x;
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
