using System;
using System.Collections.Generic;

namespace _0939
{
    public class Solution
    {
        public int MinAreaRect(int[][] points)
        {
            var answer = Int32.MaxValue;
            const int maxCood = 40001;

            if (points == null)
            {
                return answer;
            }

            var pointIdSet = new HashSet<int>();
            var n = points.GetLength(0);
            for (var i = 0; i < n; ++i)
            {
                var xi = points[i][0];
                var yi = points[i][1];
                pointIdSet.Add(xi * maxCood + yi);
            }

            // loop through diagonal of rectangle
            for (var i = 0; i < n; ++i)
            {
                var xi = points[i][0];
                var yi = points[i][1];
                
                for (var j = 0; j < n; ++j)
                {
                    var xj = points[j][0];
                    var yj = points[j][1];

                    if (xi < xj && yi < yj)
                    {
                        if (pointIdSet.Contains(xi * maxCood + yj) && pointIdSet.Contains(xj * maxCood + yi))
                        {
                            answer = Math.Min(answer, (xj - xi) * (yj - yi));
                        }
                    }
                }
            }

            return answer == Int32.MaxValue ? 0 : answer;
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
