using System;
using System.Collections.Generic;

namespace _0447
{
    public class Solution
    {
        public int NumberOfBoomerangs(int[,] points)
        {
            var ans = 0;
            var n = points.GetLength(0);
            var cnt = new Dictionary<int, int>();

            for (var i = 0; i < n; ++i)
            {
                cnt.Clear();

                for (var j = 0; j < n; ++j)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var distance = (points[i, 0] - points[j, 0]) * (points[i, 0] - points[j, 0]) + (points[i, 1] - points[j, 1]) * (points[i, 1] - points[j, 1]);
                    
                    if (!cnt.ContainsKey(distance))
                    {
                        cnt.Add(distance, 0);
                    }
                    cnt[distance] += 1;
                }

                foreach (var val in cnt.Values)
                {
                    ans += (val - 1) * val;
                }
            }

            return ans;
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
