using System;

namespace _0775
{
    public class Solution
    {
        public bool IsIdealPermutation(int[] A)
        {
            for (var i = 0; i < A.Length; ++i)
            {
                if (Math.Abs(A[i] - i) > 1)
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
