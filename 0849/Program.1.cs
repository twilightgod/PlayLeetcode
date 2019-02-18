using System;

namespace _0849_1
{
    public class Solution
    {
        public int MaxDistToClosest(int[] seats)
        {
            var n = seats.Length;
            var pre0 = -1;
            var answer = -1;
            for (var i = 0; i < n; ++i)
            {
                if (seats[i] == 0)
                {
                    if (pre0 == -1)
                    {
                        pre0 = i;
                    }
                    var d = -1;
                    // seat in begin or end of [pre0, i]
                    if (pre0 == 0 || i == n - 1)
                    {
                        d = i - pre0 + 1;
                    }
                    // seat in middle of [pre0, i]
                    else
                    {
                        d = ((i - pre0) >> 1) + 1;
                    }
                    answer = Math.Max(answer, d);
                }
                else
                {
                    pre0 = -1;
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
