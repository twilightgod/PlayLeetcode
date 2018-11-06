using System;
using System.Collections.Generic;

namespace _0454
{
    public class Solution
    {
        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            var seen = new Dictionary<int, int>();
            foreach (var a in A)
            {
                foreach (var b in B)
                {
                    seen[a + b] = seen.GetValueOrDefault(a + b, 0) + 1;
                }
            }
            var answer = 0;
            foreach (var c in C)
            {
                foreach (var d in D)
                {
                    answer += seen.GetValueOrDefault(-(c + d), 0);
                }
            }
            return answer;
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
