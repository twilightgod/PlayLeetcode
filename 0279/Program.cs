using System;

namespace _0279
{
    public class Solution
    {
        public int NumSquares(int n)
        {
            var f = new int[n + 1];
            f[0] = 1;

            for (var i = 1; i <= (int)Math.Sqrt(n); ++i)
            {
                var ii = i * i;
                for (var j = ii; j <= n; ++j)
                {
                    if (f[j - ii] > 0)
                    {
                        if (f[j] == 0)
                        {
                            f[j] = f[j - ii] + 1;
                        }
                        else
                        {
                            f[j] = Math.Min(f[j], f[j - ii] + 1);
                        }
                    }
                }
            }

            return f[n] - 1;
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
