using System;

namespace _0568
{
    public class Solution
    {
        public int MaxVacationDays(int[,] flights, int[,] days)
        {
            var n = flights.GetLength(0);
            var k = days.GetLength(1);
            var f = new int[k + 1, n];
            var answer = 0;

            for (var i = 1; i < n; ++i)
            {
                f[0, i] = Int32.MinValue;
            }

            for (var i = 1; i <= k; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    f[i, j] = Int32.MinValue;
                    for (var p = 0; p < n; ++p)
                    {
                        if (flights[p, j] == 1 || p == j)
                        {
                            f[i, j] = Math.Max(f[i, j], f[i - 1, p]);
                        }
                    }
                    // reachable
                    if (f[i, j] != Int32.MinValue)
                    {
                        f[i, j] += days[j, i - 1];
                    }
                    if (i == k)
                    {
                        answer = Math.Max(answer, f[i, j]);
                    }
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
