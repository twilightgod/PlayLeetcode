using System;

namespace _0074
{
    public class Solution
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix.Length == 0)
            {
                return false;
            }
            
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            var l = 0;
            var r = m - 1;

            while (l <= r)
            {
                var mid = (l + r) / 2;
                if (matrix[mid, 0] == target)
                {
                    return true;
                }
                else if (matrix[mid, 0] > target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            if (r < 0)
            {
                return false;
            }

            var row = r;

            l = 0;
            r = n - 1;

            while (l <= r)
            {
                var mid = (l + r) / 2;
                if (matrix[row, mid] == target)
                {
                    return true;
                }
                else if (matrix[row, mid] > target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
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
