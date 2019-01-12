using System;

namespace _0240
{
    public class Solution
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null)
            {
                return false;
            }

            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            var (x, y) = (0, n - 1);
            while (x < m && y >= 0)
            {
                if (matrix[x, y] == target)
                {
                    return true;
                }
                else if (matrix[x, y] < target)
                {
                    x++;
                }
                else
                {
                    y--;
                }
            }
            
            return false;
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
