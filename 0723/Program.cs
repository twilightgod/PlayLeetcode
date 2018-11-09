using System;
using System.Collections.Generic;

namespace _0723
{
    public class Solution
    {
        public int[,] CandyCrush(int[,] board)
        {
            var m = board.GetLength(0);
            var n = board.GetLength(1);
            while (true)
            {
                var found = false;
                for (var i = 0; i < m; ++i)
                {
                    for (var j = 0; j < n; ++j)
                    {
                        var c = Math.Abs(board[i, j]);
                        if (c > 0)
                        {
                            if (j < n - 2)
                            {
                                if (Math.Abs(board[i, j + 1]) == c && Math.Abs(board[i, j + 2]) == c)
                                {
                                    board[i, j] = -c;
                                    board[i, j + 1] = -c;
                                    board[i, j + 2] = -c;
                                    found = true;
                                }
                            }
                            if (i < m - 2)
                            {
                                if (Math.Abs(board[i + 1, j]) == c && Math.Abs(board[i + 2, j]) == c)
                                {
                                    board[i, j] = -c;
                                    board[i + 1, j] = -c;
                                    board[i + 2, j] = -c;
                                    found = true;
                                }
                            }
                        }
                    }
                }

                if (!found)
                {
                    break;
                }

                for (var j = 0; j < n; ++j)
                {
                    var last = m - 1;
                    for (var i = m - 1; i >= 0; --i)
                    {
                        if (board[i, j] > 0)
                        {
                            board[last--, j] = board[i, j];
                        }
                    }
                    while (last >= 0)
                    {
                        board[last--, j] = 0;
                    }
                }
            }
            return board;
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
