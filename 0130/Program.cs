using System;
using System.Collections.Generic;

namespace _0130
{
    public class Solution
    {
        int[,] move = new int[,]{{-1,0},{0,-1},{1,0},{0,1}};

        public void Solve(char[,] board)
        {
            var n = board.GetLength(0);
            var m = board.GetLength(1);

            for (var i = 0; i < n; ++i)
            {
                if (board[i, 0] == 'O')
                {
                    BFS(board, i, 0, n, m);
                }

                if (board[i, m - 1] == 'O')
                {
                    BFS(board, i, m - 1, n, m);
                }
            }

            for (var j = 1; j < m - 1; ++j)
            {
                if (board[0, j] == 'O')
                {
                    BFS(board, 0, j, n, m);
                }

                if (board[n - 1, j] == 'O')
                {
                    BFS(board, n - 1, j, n, m);
                }
            }

            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < m; ++j)
                {
                    if (board[i, j] == 'O')
                    {
                        board[i, j] = 'X';
                    }
                    else if (board[i, j] == 'A')
                    {
                        board[i, j] = 'O';
                    }
                }
            }
        }

        private void BFS(char[,] board, int startx, int starty, int n, int m)
        {
            var q = new Queue<(int x, int y)>();
            board[startx, starty] = 'A';
            q.Enqueue((startx, starty));

            while (q.Count > 0)
            {
                var pos = q.Dequeue();

                for (var i = 0; i < 4; ++i)
                {
                    var x = pos.x + move[i, 0];
                    var y = pos.y + move[i, 1];

                    if (x >= 0 && y >= 0 && x < n && y < m && board[x, y] == 'O')
                    {
                        board[x, y] = 'A';
                        q.Enqueue((x, y));
                    }
                }
            }
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
