using System;

namespace _0905
{
    public class Solution
    {
        public int[] SortArrayByParity(int[] A)
        {
            // quick sort style in place swap
            var l = 0;
            var r = A.Length - 1;
            while (l < r)
            {
                if (A[l] % 2 > A[r] % 2)
                {
                    (A[l], A[r]) = (A[r], A[l]);
                }
                if (A[l] % 2 == 0)
                {
                    ++l;
                }
                if (A[r] % 2 == 1)
                {
                    --r;
                }
            }
            return A;
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
