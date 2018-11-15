using System;

namespace _0755
{
    public class Solution
    {
        public int[] PourWater(int[] heights, int V, int K)
        {
            if (heights == null || heights.Length == 0 || V == 0)
            {
                return heights;
            }

            while (V-- > 0)
            {
                // try left
                var idx = K;
                for (var i = K - 1; i >= 0; --i)
                {
                    if (heights[i] > heights[idx])
                    {
                        break;
                    }
                    if (heights[i] < heights[idx])
                    {
                        idx = i;
                    }
                }
                if (idx == K)
                {
                    //try right
                    for (var i = K + 1; i < heights.Length; ++i)
                    {
                        if (heights[i] > heights[idx])
                        {
                            break;
                        }
                        if (heights[i] < heights[idx])
                        {
                            idx = i;
                        }
                    }
                }
                heights[idx]++;
            }

            return heights;
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
