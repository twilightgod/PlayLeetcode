using System;

namespace _0059
{
    public class Solution
    {
        public int[,] GenerateMatrix(int n)
        {
            var matrix = new int[n, n];
            var n1 = n;
            var n2 = n - 1;
            var moves = new int[,] {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
            var phase = 0;
            var val = 1;
            var x = 0;
            var y = -1;

            while (val <= n * n)
            {
                var isHorizon = phase % 2 == 0;
                for (var i = 0; i < (isHorizon ? n1 : n2); ++i)
                {
                    x += moves[phase, 0];
                    y += moves[phase, 1];
                    matrix[x, y] = val++;
                }
                if (isHorizon)
                {
                    n1--;
                }
                else
                {
                    n2--;
                }
                phase = (phase + 1) % 4;
            }

            return matrix;
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
