using System;

namespace _0120
{
    public class Solution
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var n = triangle.Count;
            for (var i = n - 2; i >= 0; --i)
            {
                for (var j = 0; j < i + 1; ++j)
                {
                    triangle[i][j] += Math.Min(triangle[i + 1][j], triangle[i + 1][j + 1]);
                }
            }
            return triangle[0][0];
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
