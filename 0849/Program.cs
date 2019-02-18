using System;

namespace _0849
{
    public class Solution
    {
        public int MaxDistToClosest(int[] seats)
        {
            var n = seats.Length;
            var left = new int[n];
            for (var i = 0; i < n; ++i)
            {
                if (seats[i] == 1)
                {
                    left[i] = 0;
                }
                else
                {
                    if (i == 0)
                    {
                        left[i] = 1;
                    }
                    else
                    {
                        left[i] = left[i - 1] + 1;
                    }
                }
            }
            var right = new int[n];
            for (var i = n - 1; i >= 0; --i)
            {
                if (seats[i] == 1)
                {
                    right[i] = 0;
                }
                else
                {
                    if (i == n - 1)
                    {
                        right[i] = 1;
                    }
                    else
                    {
                        right[i] = right[i + 1] + 1;
                    }
                }
            }
            var answer = -1;
            for (var i = 0; i < n; ++i)
            {
                var d = 0;
                if (i == 0)
                {
                    d = right[i];
                }
                else if (i == n - 1)
                {
                    d = left[i];
                }
                else
                {
                    d = Math.Min(left[i], right[i]);
                }
                answer = Math.Max(answer, d);
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
