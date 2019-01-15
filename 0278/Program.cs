using System;

namespace _0278
{
    public class Solution : VersionControl
    {
        public int FirstBadVersion(int n)
        {
            var l = 0;
            var r = n;

            while (l < r)
            {
                var m = l + (r - l) / 2;

                if (IsBadVersion(m + 1))
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }

            return l + 1;
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
