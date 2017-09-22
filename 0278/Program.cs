using System;

namespace _0278
{
    public class Solution : VersionControl
    {
        public int FirstBadVersion(int n)
        {
            var l = 1;
            var r = n;
            var lowerbound = -1;

            while (l <= r)
            {
                var m64 = ((long)l + r) / 2;
                var m = (int)m64;

                Console.WriteLine($"{l}, {r}, {m}");

                if (IsBadVersion(m))
                {
                    lowerbound = lowerbound == -1 ? m : Math.Min(lowerbound, m);
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }

            return lowerbound;
        }
    }

    public class VersionControl
    {
        public bool IsBadVersion(int version)
        {
            return version >= 1702766719;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().FirstBadVersion(2126753390));
        }
    }
}
