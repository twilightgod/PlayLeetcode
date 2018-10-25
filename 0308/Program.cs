using System;
using System.Collections.Generic;

namespace _0308
{
    public class BIT
    {
        int[] sum = null;
        int n = 0;
        public BIT(int n)
        {
            this.n = n;
            sum = new int[n + 1];
        }

        public void Update(int index, int delta)
        {
            while (index <= n)
            {
                sum[index] += delta;
                index += LowBit(index);
            }
        }

        public int QueryPrefixSum(int index)
        {
            var s = 0;
            while (index > 0)
            {
                s += sum[index];
                index -= LowBit(index);
            }
            return s;
        }

        private int LowBit(int x)
        {
            return x & (-x);
        }
    }

    public class NumMatrix
    {
        List<BIT> Bits = null;
        int[,] Matrix = null;
        int m, n;

        public NumMatrix(int[,] matrix)
        {
            m = matrix.GetLength(0);
            n = matrix.GetLength(1);
            Matrix = new int[m + 1, n + 1];
            var rowSum = new int[m + 1, n + 1];
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    Matrix[i + 1, j + 1] = matrix[i, j];
                    rowSum[i + 1, j + 1] = rowSum[i + 1, j] + matrix[i, j];
                }
            }
            Bits = new List<BIT>();
            // padding
            Bits.Add(new BIT(m));
            for (var j = 1; j <= n; ++j)
            {
                Bits.Add(new BIT(m));
                for (var i = 1; i <= m; ++i)
                {
                    Bits[j].Update(i, rowSum[i, j]);
                }
            }
        }

        public void Update(int row, int col, int val)
        {
            row++;
            col++;
            var delta = val - Matrix[row, col];
            for (var j = col; j <= n; ++j)
            {
                Bits[j].Update(row, delta);
            }
            Matrix[row, col] = val;
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            row1++;
            col1++;
            row2++;
            col2++;
            return Bits[col2].QueryPrefixSum(row2) - Bits[col2].QueryPrefixSum(row1 - 1) - Bits[col1 - 1].QueryPrefixSum(row2) + Bits[col1 - 1].QueryPrefixSum(row1 - 1);
        }
    }

    /**
     * Your NumMatrix object will be instantiated and called as such:
     * NumMatrix obj = new NumMatrix(matrix);
     * obj.Update(row,col,val);
     * int param_2 = obj.SumRegion(row1,col1,row2,col2);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
