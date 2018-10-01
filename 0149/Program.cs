using System;
using System.Collections.Generic;
using System.Linq;

namespace _0149
{
    /**
 * Definition for a point.
 */
    public class Point
    {
        public int x;
        public int y;
        public Point() { x = 0; y = 0; }
        public Point(int a, int b) { x = a; y = b; }
    }

    public class Solution
    {
        public int MaxPoints(Point[] points)
        {
            if (points == null || points.Length == 0)
            {
                return 0;
            }
            // handle all points are identical, in this case, it will not run into the for loop below
            var isAllIdentical = true;
            for (var i = 1; i < points.Length; ++i)
            {
                if (points[0].x != points[i].x || points[0].y != points[i].y)
                {
                    isAllIdentical = false;
                    break;
                }
            }
            if (isAllIdentical)
            {
                return points.Length;
            }

            // (a1 / a2)*x + b = y
            // a1 / a2 = (y1 - y2) / (x1 - x2)
            // b = y1 - (a1 / a2) * x1 => b = (a2 * y1 - a1 * x1) / a2
            // since a1 and a2 have been normalized, we can take b = (a2 * y1 - a1 * x1)
            // let a1 be positive if it's not 0
            var lines = new Dictionary<(int a1, int a2, int b), HashSet<int>>();
            for (var i = 0; i < points.Length; ++i)
            {
                for (var j = i + 1; j < points.Length; ++j)
                {
                    var a1 = points[i].y - points[j].y;
                    var a2 = points[i].x - points[j].x;
                    var b = 0;
                    if (a1 == 0 && a2 == 0)
                    {
                        continue;
                    }
                    else if (a1 == 0)
                    {
                        // horizon
                        a1 = 0;
                        a2 = 1;
                        b = points[i].y;
                    }
                    else if (a2 == 0)
                    {
                        // vertical
                        a1 = points[i].x;
                        a2 = 0;
                        b = 0;
                    }
                    else
                    {
                        // normalize
                        var isPositive = a1 * 1.0 / a2 > 0;
                        a1 = Math.Abs(a1);
                        a2 = Math.Abs(a2);
                        var g = GCD(a1, a2);
                        a1 /= g;
                        a2 /= g;
                        if (!isPositive)
                        {
                            a2 = -a2;
                        }
                        b = a2 * points[i].y - a1 * points[i].x;
                    }
                    var dictKey = (a1, a2, b);
                    if (!lines.ContainsKey(dictKey))
                    {
                        lines[dictKey] = new HashSet<int>();
                    }
                    lines[dictKey].Add(i);
                    lines[dictKey].Add(j);
                }
            }
            var answer = 0;
            foreach (var val in lines.Values)
            {
                answer = Math.Max(answer, val.Count);
            }
            return answer;
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                var c = a % b;
                a = b;
                b = c;
            }
            return a;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var points = new Point[2];
            points[0] = new Point(560, 248);
            points[1] = new Point(0, 16);
            //points[2] = new Point(3, 10);
            //points[3] = new Point(0, 2);
            new Solution().MaxPoints(points);
            Console.WriteLine("Hello World!");
        }
    }
}
