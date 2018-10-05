using System;

namespace _0343
{
    public class Solution
    {
        public int IntegerBreak(int n)
        {
            var f = new int[n + 1];
            f[1] = 1;
            for (var i = 2; i <= n; ++i)
            {
                for (var j = 1; j < i; ++j)
                {
                    f[i] = Math.Max(Math.Max(
                        f[i], 
                        f[j] * (i - j)),
                        j * (i - j)
                    );
                }
            }
            return f[n];
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
