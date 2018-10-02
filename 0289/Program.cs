using System;

namespace _0289
{
    public class Solution
    {
        public void GameOfLife(int[][] board)
        {
            if (board == null || board.Length == 0)
            {
                return;
            }

            var m = board.GetLength(0);
            var n = board[0].GetLength(0);

            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    var counter = 0;
                    for (var x = Math.Max(0, i - 1); x < Math.Min(m, i + 2); ++x)
                    {
                        for (var y = Math.Max(0, j - 1); y < Math.Min(n, j + 2); ++y)
                        {
                            if ((board[x][y] & 1) == 1)
                            {
                                counter++;
                            }
                        }
                    }
                    if ((board[i][j] & 1) == 1)
                    {
                        if (counter - 1 < 2 || counter - 1 > 3)
                        {
                            // die
                        }
                        else if (counter - 1 == 2 || counter - 1 == 3)
                        {
                            // live
                            board[i][j] |= 2;
                        }
                    }
                    else
                    {
                        if (counter == 3)
                        {
                            // live
                            board[i][j] |= 2;
                        }
                        else
                        {
                            // die
                        }
                    }
                }
            }

            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    board[i][j] >>= 1;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var board = new int[4][]{new int[]{0,1,0}, new int[]{0,0,1}, new int[]{1,1,1}, new int[]{0,0,0}};
            new Solution().GameOfLife(board);
            Console.WriteLine("Hello World!");
        }
    }
}
