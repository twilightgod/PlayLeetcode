using System;

namespace _0661
{
    public class Solution
    {
        public int[,] ImageSmoother(int[,] M)
        {
            var m = M.GetLength(0);
            var n = M.GetLength(1);

            var ans = new int[m, n];

            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    var cnt = 0;
                    var sum = 0;
                    for (var dx = -1; dx <= 1; ++dx)
                    {
                        for (var dy = -1; dy <= 1; ++dy)
                        {
                            var x = i + dx;
                            var y = j + dy;
                            if (x >= 0 && x < m && y >= 0 && y < n)
                            {
                                sum += M[x, y];
                                cnt++;
                            }
                        }
                    }
                    ans[i, j] = (int)Math.Floor(sum * 1.0 / cnt);
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
