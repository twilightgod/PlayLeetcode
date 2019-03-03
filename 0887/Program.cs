using System;

namespace _0887
{
    // TLE, need to change k loop to BinarySearch
    public class Solution
    {
        public int SuperEggDrop(int K, int N)
        {
            /*  https://www.youtube.com/watch?v=KVfxgpI3Tv0&t=438s
                K eggs
                N floors
                f[i, j] means the minimal times needed for i eggs and j floors
                f[i, j] = min(max(            // drop in k-th floor
                            f[i - 1, j - k],  // break, then we have 1 less egg and validate upper part (j - k floors)
                            f[i, k - 1]       // doesn't break, then need to validate bottom part (k - 1 floors)
                            )) + 1
            */

            var f = new int[K + 1, N + 1];
            
            // only have 1 egg, need to go through all floors from bottom to up
            for (var j = 1; j <= N; ++j)
            {
                f[1, j] = j;
            }

            for (var i = 2; i <= K; ++i)
            {
                for (var j = 1; j <= N; ++j)
                {
                    f[i, j] = Int32.MaxValue;
                    for (var k = 1; k <= j; ++k)
                    {
                        f[i, j] = Math.Min(f[i, j], Math.Max(f[i - 1, j - k], f[i, k - 1]) + 1);
                    }
                }
            }

            return f[K, N];
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
