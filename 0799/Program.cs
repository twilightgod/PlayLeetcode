using System;

namespace _0799
{
    public class Solution
    {
        public double ChampagneTower(int poured, int query_row, int query_glass)
        {
            var f = new double[query_row + 2, query_row + 2];
            f[0, 0] = poured;
            for (var i = 0; i <= query_row; ++i)
            {
                for (var j = 0; j <= i; ++j)
                {
                    if (f[i, j] > 1)
                    {
                        var overflow = (f[i, j] - 1) / 2;
                        f[i + 1, j] += overflow;
                        f[i + 1, j + 1] += overflow;
                        f[i, j] = 1;
                    }
                }
            }
            return f[query_row, query_glass];
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
