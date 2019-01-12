using System;

namespace _0048
{
    public class Solution
    {
        public void Rotate(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            
            // vertical mirror
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n / 2; ++j)
                {
                    (matrix[i, j], matrix[i, n - j - 1]) = (matrix[i, n - j - 1], matrix[i, j]);
                }
            }

            // diagonal mirror, (n - i - 1 - j) is the distance between (i, j) to diagonal line 
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n - i - 1; ++j)
                {
                    (matrix[i, j], matrix[i + (n - i - 1 - j), j + (n - i - 1 - j)]) = (matrix[i + (n - i - 1 - j), j + (n - i - 1 - j)], matrix[i, j]);
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
