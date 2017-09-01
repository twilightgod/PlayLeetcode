using System;
using System.Linq;

namespace _0204
{
    public class Solution
    {
        public int CountPrimes(int n)
        {
            var IsPrime = Enumerable.Repeat(true, n).ToArray();
            
            for (var i = 2; i <= (int)Math.Sqrt(n); ++i)
            {
                if (IsPrime[i])
                {
                    for (int j = 2; i * j < n; ++j)
                    {
                        IsPrime[i * j] = false;
                    }
                }
            }
            
            var cnt = 0;

            for (var i = 2; i < n; ++i)
            {
                if (IsPrime[i])
                {
                    cnt++;
                }
            }

            return cnt;
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
