using System;

namespace _0896
{
    public class Solution
    {
        public bool IsMonotonic(int[] A)
        {
            if (A == null || A.Length == 0)
            {
                return false;
            }
            return IsMonotonic(A, 1) || IsMonotonic(A, -1);
        }

        private bool IsMonotonic(int[] A, int sign)
        {
            for (var i = 1; i < A.Length; ++i)
            {
                if (A[i - 1] * sign > A[i] * sign)
                {
                    return false;
                }
            }
            return true;
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
