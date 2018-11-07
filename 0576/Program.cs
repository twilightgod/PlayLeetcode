using System;

namespace _0576
{
    public class Solution
    {
        public int FindPaths(int m, int n, int N, int i, int j)
        {
            var moves = new int[,] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
            // padding
            m+=2;
            n+=2;
            i++;
            j++;
            var f = new int[N + 1, m, n];
            var MOD = 1000000007;
            f[0, i, j] = 1;
            var answer = 0;
            for (var k = 1; k <= N; ++k)
            {
                for (var x = 0; x < m; ++x)
                {
                    for (var y = 0; y < n; ++y)
                    {
                        for (var d = 0; d < 4; ++d)
                        {
                            var nx = x + moves[d, 0];
                            var ny = y + moves[d, 1];
                            if (nx >= 1 && nx < m - 1 && ny >= 1 && ny < n - 1)
                            {
                                f[k, x, y] += f[k - 1, nx, ny];
                                f[k, x, y] %= MOD;
                            }
                        }

                        if (x == 0 || x == m - 1 || y == 0 || y == n - 1)
                        {
                            answer += f[k, x, y];
                            answer %= MOD;
                        }
                    }
                }
            }
            return answer;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().FindPaths(2, 2, 2, 0, 0);
            Console.WriteLine("Hello World!");
        }
    }
}
