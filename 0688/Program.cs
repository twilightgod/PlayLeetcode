using System;

namespace _0688
{
    public class Solution
    {
        public double KnightProbability(int N, int K, int r, int c)
        {
            if (K == 0)
            {
                return 1;
            }
            var moves = new int[,] { { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 }, { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 } };
            var f = new double[K + 1, N, N];
            f[0, r, c] = 1;
            var answer = 0d;
            for (var k = 1; k <= K; ++k)
            {
                for (var x = 0; x < N; ++x)
                {
                    for (var y = 0; y < N; ++y)
                    {
                        for (var d = 0; d < 8; ++d)
                        {
                            var nx = x + moves[d, 0];
                            var ny = y + moves[d, 1];
                            if (nx >= 0 && nx < N && ny >= 0 && ny < N)
                            {
                                f[k, x, y] += f[k - 1, nx, ny] / 8;
                            }
                        }
                        if (k == K)
                        {
                            answer += f[k, x, y];
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
            Console.WriteLine("Hello World!");
        }
    }
}
