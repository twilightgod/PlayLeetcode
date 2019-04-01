using System;

namespace _0755_1
{
    public class Solution
    {
        public int[] PourWater(int[] heights, int V, int K)
        {
            if (heights == null)
            {
                return heights;
            }

            while (V-- > 0)
            {
                var idx = K;
                // try left first
                for (var i = K - 1; i >= 0; --i)
                {
                    if (heights[i] < heights[idx])
                    {
                        idx = i;
                    }
                    else if (heights[i] > heights[idx])
                    {
                        break;
                    }
                }

                if (idx == K)
                {
                    // try right
                    for (var i = K + 1; i < heights.Length; ++i)
                    {
                        if (heights[i] < heights[idx])
                        {
                            idx = i;
                        }
                        else if (heights[i] > heights[idx])
                        {
                            break;
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
