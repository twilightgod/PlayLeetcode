using System;

namespace _0528
{
    public class Solution
    {
        int[] sum = null;
        int n;
        Random generator = null;

        public Solution(int[] w)
        {
            n = w.Length;
            sum = new int[n];
            sum[0] = w[0];
            for (var i = 1; i < n; ++i)
            {
                sum[i] = sum[i - 1] + w[i];
            }
            generator = new Random(233233233);
        }

        public int PickIndex()
        {
            // [min, max)
            var ran = generator.Next(1, sum[n - 1] + 1);
            var l = 0;
            var r = n;
            while (l < r)
            {
                var m = l + (r - l) / 2;
                if (sum[m] >= ran)
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }
            return l;
        }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(w);
     * int param_1 = obj.PickIndex();
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
