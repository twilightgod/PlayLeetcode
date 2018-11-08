using System;

namespace _0741
{
    public class Solution
    {
        public int CherryPickup(int[,] grid)
        {
            var m = grid.GetLength(0);
            var n = grid.GetLength(1);
            var steps = m + n - 1;
            var maxslots = Math.Max(m, n);
            var f = new int[steps, maxslots, maxslots];
            f[0, 0, 0] = grid[0, 0] == 1 ? 1 : 0;
            for (var i = 1; i < steps; ++i)
            {
                for (var x1 = 0; x1 < maxslots; ++x1)
                {
                    var y1 = i - x1;
                    if (IsInRange(m, n, x1, y1) && grid[x1, y1] != -1)
                    {
                        for (var x2 = 0; x2 < maxslots; ++x2)
                        {
                            var y2 = i - x2;
                            if (IsInRange(m, n, x2, y2) && grid[x2, y2] != -1)
                            {
                                // -1 means un-reachable
                                f[i, x1, x2] = -1;
                                var cherry1 = grid[x1, y1] + grid[x2, y2];
                                if (x1 == x2)
                                {
                                    cherry1 /= 2;
                                }
                                // 3 -> 1, 4 -> 2
                                for (var j = -1; j <= 0; ++j)
                                {
                                    var x3 = x1 + j;
                                    var y3 = i - 1 - x3;
                                    if (IsInRange(m, n, x3, y3) && grid[x3, y3] != -1)
                                    {
                                        for (var k = -1; k <= 0; ++k)
                                        {
                                            var x4 = x2 + k;
                                            var y4 = i - 1 - x4;
                                            if (IsInRange(m, n, x4, y4) && grid[x4, y4] != -1 && f[i - 1, x3, x4] != -1)
                                            {
                                                f[i, x1, x2] = Math.Max(f[i, x1, x2], cherry1 + f[i - 1, x3, x4]);
                                                Console.WriteLine($"i {i} x1 {x1} y1 {y1} x2 {x2} y2 {y2} x3 {x3} y3 {y3} x4 {x4} y4 {y4} f {f[i, x1, x2]}");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return Math.Max(0, f[steps - 1, m - 1, m - 1]);
        }

        private bool IsInRange(int m, int n, int x, int y)
        {
            return x >= 0 && x < m && y >= 0 && y < n;
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
