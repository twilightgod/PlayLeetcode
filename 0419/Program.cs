using System;

namespace _0419
{
    class Program
    {
        public class Solution
        {
            public int CountBattleships(char[,] board)
            {
                var ans = 0;

                for (var i = 0; i < board.GetLength(0); ++i)
                {
                    for (var j = 0; j < board.GetLength(1); ++j)
                    {
                        if (board[i, j] == 'X' && !IsShip(board, i - 1, j) && !IsShip(board, i, j - 1))
                        {
                            ans++;
                        }
                    }
                }

                return ans;
            }

            private bool IsShip(char[,] board, int i, int j)
            {
                if (i < 0 || j < 0)
                {
                    return false;
                }

                return board[i, j] == 'X';
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
