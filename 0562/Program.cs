using System;

namespace _0562
{
    public class Solution
    {
        public int LongestLine(int[,] M)
        {
            var m = M.GetLength(0);
            var n = M.GetLength(1);
            var f = new int[2, n, 4];
            var pre = 0;
            var cur = 1;
            var answer = 0;
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (M[i, j] == 1)
                    {
                        for (var k = 0; k < 4; ++k)
                        {
                            f[cur, j, k] = 1;
                        }
                        if (j > 0)
                        {
                            f[cur, j, 0] = f[cur, j - 1, 0] + 1;
                            f[cur, j, 1] = f[pre, j - 1, 1] + 1;
                        }
                        f[cur, j, 2] = f[pre, j, 2] + 1;
                        if (j < n - 1)
                        {
                            f[cur, j, 3] = f[pre, j + 1, 3] + 1;
                        }
                        for (var k = 0; k < 4; ++k)
                        {
                            answer = Math.Max(answer, f[cur, j, k]);
                        }
                    }
                    else
                    {
                        for (var k = 0; k < 4; ++k)
                        {
                            f[cur, j, k] = 0;
                        }
                    }
                }
                pre = (pre + 1) % 2;
                cur = (cur + 1) % 2;
            }
            return answer;
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
