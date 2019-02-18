using System;
using System.Collections.Generic;
using System.Linq;

namespace _0850
{
    // O(n^3)
    public class Solution
    {
        public int RectangleArea(int[][] rectangles)
        {
            var MOD = 1000000007l;
            var area = 0l;
            var x = new List<int>();
            var y = new List<int>();
            var n = rectangles.GetLength(0);
            for (var i = 0; i < n; ++i)
            {
                x.Add(rectangles[i][0]);
                y.Add(rectangles[i][1]);
                x.Add(rectangles[i][2]);
                y.Add(rectangles[i][3]);
            }
            x = x.Distinct().ToList();
            x.Sort();
            y = y.Distinct().ToList();
            y.Sort();
            for (var i = 1; i < x.Count; ++i)
            {
                for (var j = 1; j < y.Count; ++j)
                {
                    var x1 = x[i - 1];
                    var y1 = y[j - 1];
                    var x2 = x[i];
                    var y2 = y[j];
                    for (var k = 0; k < n; ++k)
                    {
                        if (rectangles[k][0] <= x1 &&
                            rectangles[k][1] <= y1 &&
                            rectangles[k][2] >= x2 &&
                            rectangles[k][3] >= y2)
                        {
                            area = (area + ((long)x2 - x1) * (y2 - y1)) % MOD;
                            break;
                        }
                    }
                }
            }
            return (int)area;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().RectangleArea(new int[][]{new int[]{0,0,2,2}, new int[]{1,0,2,3}, new int[]{1,0,3,1}});
            Console.WriteLine("Hello World!");
        }
    }
}
