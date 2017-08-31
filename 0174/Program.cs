using System;

namespace _0174
{
    class Program
    {
        public class Solution
        {
            public int CalculateMinimumHP(int[,] dungeon)
            {
                var m = dungeon.GetLength(0);
                var n = dungeon.GetLength(1);

                var lowesthp = new int[m, n];
                var currenthp = new int[m, n];

                for (var i = 0; i < m; ++i)
                {
                    for (var j = 0; j < n; ++j)
                    {
                        if (i == 0 && j == 0)
                        {
                            currenthp[i, j] = dungeon[i, j];
                            lowesthp[i, j] = dungeon[i, j] < 0 ? dungeon[i, j] : 0;
                        }
                        else if (i == 0)
                        {
                            currenthp[i, j] = dungeon[i, j] + currenthp[i, j - 1];
                            lowesthp[i, j] = currenthp[i, j] < 0 ? Math.Min(currenthp[i, j], lowesthp[i, j - 1]) :
                                                                    Math.Min(0, lowesthp[i, j - 1]);
                        }
                        else if (j == 0)
                        {
                            currenthp[i, j] = dungeon[i, j] + currenthp[i - 1, j];
                            lowesthp[i, j] = currenthp[i, j] < 0 ? Math.Min(currenthp[i, j], lowesthp[i - 1, j]) :
                                                                    Math.Min(0, lowesthp[i - 1, j]);                            
                        }
                        else
                        {
                            var currenthp_down = dungeon[i, j] + currenthp[i - 1, j];
                            var lowesthp_down = currenthp_down < 0 ? Math.Min(currenthp_down, lowesthp[i - 1, j]) :
                                                                    Math.Min(0, lowesthp[i - 1, j]);

                            var currenthp_right = dungeon[i, j] + currenthp[i, j - 1];
                            var lowesthp_right = currenthp_right < 0 ? Math.Min(currenthp_right, lowesthp[i, j - 1]) :
                                                                    Math.Min(0, lowesthp[i, j - 1]);

                            if (lowesthp_down > lowesthp_right)
                            {
                                currenthp[i, j] = currenthp_down;
                                lowesthp[i, j] = lowesthp_down;
                            }
                            else
                            {
                                currenthp[i, j] = currenthp_right;
                                lowesthp[i, j] = lowesthp_right;
                            }
                        }
                    }
                }

                return -lowesthp[m - 1, n - 1] + 1;
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
