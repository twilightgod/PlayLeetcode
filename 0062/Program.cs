using System;

namespace _0062
{
    public class Solution
    {
        public int UniquePaths(int m, int n)
        {
            var f = new int[m, n];
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (i == 0 && j == 0)
                    {
                        f[i, j] = 1;
                    }
                    else
                    {
                        f[i, j] = (i - 1 >= 0 ? f[i - 1, j] : 0) + (j - 1 >= 0 ? f[i, j - 1] : 0);
                    }
                }
            }
            return f[m - 1, n - 1];
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
