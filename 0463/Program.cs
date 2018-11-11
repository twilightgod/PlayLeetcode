using System;

namespace _0463
{
    public class Solution
    {
        public int IslandPerimeter(int[,] grid)
        {
            var m = grid.GetLength(0);
            var n = grid.GetLength(1);
            var answer = 0;
            var moves = new int[,]{{0,1},{0,-1},{1,0},{-1,0}};
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (grid[i, j] == 1)
                    {
                        answer += 4;
                        for (var k = 0; k < 4; ++k)
                        {
                            var x = i + moves[k, 0];
                            var y = j + moves[k, 1];
                            if (x >= 0 && x < m && y >= 0 && y < n && grid[x, y] == 1)
                            {
                                answer--;
                            }
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
