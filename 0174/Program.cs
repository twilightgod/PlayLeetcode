using System;

namespace _0174
{
    class Program
    {
        public class Solution
        {
            private int GetHP(int[,] hp, int m, int n, int i, int j)
            {
                if (i == m - 1 && j == n || i == m && j == n - 1)
                {
                    return 1;
                }
                else if (i == m || j == n)
                {
                    return Int32.MaxValue;
                }
                else
                {
                    return hp[i, j];
                }
            }

            public int CalculateMinimumHP(int[,] dungeon)
            {
                var m = dungeon.GetLength(0);
                var n = dungeon.GetLength(1);

                var hp = new int[m, n];
                
                for (var i = m - 1; i >= 0; --i)
                {
                    for (var j = n - 1; j >= 0; --j)
                    {
                        hp[i, j] = Math.Max(1, Math.Min(GetHP(hp, m, n, i, j + 1), GetHP(hp, m, n, i + 1, j)) - dungeon[i, j]);
                    }
                }

                return hp[0, 0];
            }
        }

        static void Main(string[] args)
        {
            //int[,] arr = {{-2, -3, 3},{-5, -10, 1}, {10, 30, -5}};
            int[,] arr = {{1, -3, 3},{0, -2, 0}, {-3, -3, -3}};
            Console.WriteLine(new Solution().CalculateMinimumHP(arr));
        }
    }
}
