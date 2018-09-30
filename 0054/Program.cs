using System;
using System.Collections.Generic;

namespace _0054
{
    public class Solution
    {
        public IList<int> SpiralOrder(int[,] matrix)
        {
            // R, D, L, U
            var moves = new int[,] {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};

            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            var answers = new List<int>();

            var total = m * n;
            var phase = 0;
            m--;
            var x = 0;
            var y = -1;
            while (answers.Count != total)
            {
                var isHorizon = phase % 2 == 0;
                for (var i = 0; i < (isHorizon ? n : m); ++i)
                {
                    x += moves[phase, 0];
                    y += moves[phase, 1];
                    answers.Add(matrix[x, y]);
                }

                if (isHorizon)
                {
                    n--;
                }
                else
                {
                    m--;
                }
                phase = (phase + 1) % 4;
            }

            return answers;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().SpiralOrder(new int[,]{{0}});
            Console.WriteLine("Hello World!");
        }
    }
}
