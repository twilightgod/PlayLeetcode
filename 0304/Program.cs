using System;

namespace _0304
{
    public class NumMatrix
    {
        int[,] sum = null;
        int m, n;

        public NumMatrix(int[,] matrix)
        {
            m = matrix.GetLength(0);
            n = matrix.GetLength(1);
            sum = new int[m + 1, n + 1];
            for (var i = 1; i <= m; ++i)
            {
                for (var j = 1; j <= n; ++j)
                {
                    sum[i, j] = sum[i, j - 1] + sum[i - 1, j] + matrix[i - 1, j - 1] - sum[i - 1, j - 1];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            row1++;
            col1++;
            row2++;
            col2++;
            return sum[row2, col2] - sum[row1 - 1, col2] - sum[row2, col1 - 1] + sum[row1 - 1, col1 - 1];
        }
    }

    /**
     * Your NumMatrix object will be instantiated and called as such:
     * NumMatrix obj = new NumMatrix(matrix);
     * int param_1 = obj.SumRegion(row1,col1,row2,col2);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
