using System;

namespace _0135
{
    public class Solution
    {
        public int Candy(int[] ratings)
        {
            var n = ratings.Length;
            var left = new int[n];
            var right = new int[n];
            for (var i = 0; i < n; ++i)
            {
                left[i] = 1;
                if (i > 0 && ratings[i] > ratings[i - 1])
                {
                    left[i] = left[i - 1] + 1;
                }
            }
            for (var i = n - 1; i >= 0; --i)
            {
                right[i] = 1;
                if (i < n - 1 && ratings[i] > ratings[i + 1])
                {
                    right[i] = right[i + 1] + 1;
                }
            }
            var answer = 0;
            for (var i = 0; i < n; ++i)
            {
                answer += Math.Max(left[i], right[i]);
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
