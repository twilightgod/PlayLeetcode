using System;

namespace _0661
{
    public class Solution
    {
        public int[,] ImageSmoother(int[,] M)
        {
            var delta = new int[8, 2] { { 0, 1 }, { 1, 1 }, { 1, 0 }, { 0, -1 }, { -1, -1 }, { -1, 0 }, { 1, -1 }, { -1, 1 } };
            var n = M.GetLength(0);
            var m = M.GetLength(1);

            var ans = new int[n, m];

            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < m; ++j)
                {
                    var validcnt = 1;
                    var validsum = M[i, j];
                    for (var k = 0; k < 8; ++k)
                    {
                        try
                        {
                            validsum += M[i + delta[k, 0], j + delta[k, 1]];
                            validcnt++;
                        }
                        catch (IndexOutOfRangeException ex)
                        {

                        }
                    }
                    ans[i, j] = (int)Math.Floor(validsum * 1.0 / validcnt);
                }
            }

            return ans;
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
