using System;

namespace _0348
{
    public class TicTacToe
    {
        int[] rowSum = null;
        int[] colSum = null;
        int diagSum1 = 0;
        int diagSum2 = 0;
        int n = 0;

        /** Initialize your data structure here. */
        public TicTacToe(int n)
        {
            this.n = n;
            rowSum = new int[n];
            colSum = new int[n];
        }

        /** Player {player} makes a move at ({row}, {col}).
            @param row The row of the board.
            @param col The column of the board.
            @param player The player, can be either 1 or 2.
            @return The current winning condition, can be either:
                    0: No one wins.
                    1: Player 1 wins.
                    2: Player 2 wins. */
        public int Move(int row, int col, int player)
        {
            var delta = player == 1 ? 1 : -1;
            rowSum[row] += delta;
            colSum[col] += delta;
            if (row == col)
            {
                diagSum1 += delta;
            }
            if (row + col == n - 1)
            {
                diagSum2 += delta;
            }
            if (rowSum[row] == n || colSum[col] == n || diagSum1 == n || diagSum2 == n)
            {
                return 1;
            }
            if (rowSum[row] == -n || colSum[col] == -n || diagSum1 == -n || diagSum2 == -n)
            {
                return 2;
            }
            return 0;
        }
    }

    /**
     * Your TicTacToe object will be instantiated and called as such:
     * TicTacToe obj = new TicTacToe(n);
     * int param_1 = obj.Move(row,col,player);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
