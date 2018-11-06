using System;

namespace _0845
{
    public class Solution
    {
        public int LongestMountain(int[] A)
        {
            if (A == null || A.Length == 0)
            {
                return 0;
            }

            var n = A.Length;
            var L = new int[n];
            var R = new int[n];

            for (var i = 1; i < n; ++i)
            {
                if (A[i] > A[i - 1])
                {
                    L[i] = L[i - 1] + 1;
                }
            }

            for (var i = n - 2; i >= 0; --i)
            {
                if (A[i] > A[i + 1])
                {
                    R[i] = R[i + 1] + 1;
                }
            }

            var answer = 0;
            for (var i = 0; i < n; ++i)
            {
                if (L[i] > 0 && R[i] > 0)
                {
                    answer = Math.Max(answer, L[i] + R[i] + 1);
                }
            }

            return answer;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            [2,1,4,7,3,2,5]
[2,2,2]
[1]
[1,2]
[2,3,3,2,0,2] */
            Console.WriteLine("Hello World!");
        }
    }
}
