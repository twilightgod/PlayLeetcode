using System;
using System.Collections.Generic;

namespace _1001
{
    public class Solution
    {
        Dictionary<int, int> r;
        Dictionary<int, int> c;
        Dictionary<int, int> d1;
        Dictionary<int, int> d2;

        public int[] GridIllumination(int N, int[][] lamps, int[][] queries)
        {
            var lampSet = new HashSet<(int x, int y)>();
            var n = lamps.GetLength(0);
            var m = queries.GetLength(0);
            var answer = new int[m];
            r = new Dictionary<int, int>();
            c = new Dictionary<int, int>();
            d1 = new Dictionary<int, int>();
            d2 = new Dictionary<int, int>();

            for (var i = 0; i < n; ++i)
            {
                var x = lamps[i][0];
                var y = lamps[i][1];
                lampSet.Add((x, y));
                UpdateDict(x, y, 1);
            }

            for (var i = 0; i < m; ++i)
            {
                var x = queries[i][0];
                var y = queries[i][1];
                answer[i] = IsLit(x, y) ? 1 : 0;
                for (var dx = -1; dx <= 1; ++dx)
                {
                    for (var dy = -1; dy <= 1; ++dy)
                    {
                        var x1 = x + dx;
                        var y1 = y + dy;
                        if (lampSet.Contains((x1, y1)))
                        {
                            lampSet.Remove((x1, y1));
                            UpdateDict(x1, y1, -1);
                        }
                    }
                }
            }

            return answer;
        }

        private void UpdateDict(int x, int y, int delta)
        {
            r[x] = r.GetValueOrDefault(x) + delta;
            c[y] = c.GetValueOrDefault(y) + delta;
            d1[x + y] = d1.GetValueOrDefault(x + y) + delta;
            d2[x - y] = d2.GetValueOrDefault(x - y) + delta;
        }

        private bool IsLit(int x, int y)
        {
            return r.ContainsKey(x) && r[x] > 0
            || c.ContainsKey(y) && c[y] > 0
            || d1.ContainsKey(x + y) && d1[x + y] > 0
            || d2.ContainsKey(x - y) && d2[x - y] > 0;
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
