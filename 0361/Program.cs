using System;
using System.Text;

namespace _0361
{
    public class Solution
    {
        public int MaxKilledEnemies(char[,] grid)
        {
            var len0 = grid.GetLength(0);
            var len1 = grid.GetLength(1);
            var N = new int[len0, len1];
            var S = new int[len0, len1];
            var W = new int[len0, len1];
            var E = new int[len0, len1];
            var best = 0;

/*
            var sb = new StringBuilder();
            sb.Append("[");
            for (var i = 0; i < len0; ++i)
            {
                sb.Append("[");
                if (i != 0)
                {
                    sb.Append(",");
                }
                for (var j = 0; j < len1; ++j)
                {
                    sb.AppendFormat("\"{0}\"", grid[i, j]);
                    if (j != 0)
                    {
                        sb.Append(",");
                    }
                }
                sb.Append("]");
            }
            sb.Append("]");

            Console.WriteLine(sb.ToString()); */

            for (var i = 0; i < len0; ++i)
            {
                for (var j = 0; j < len1; ++j)
                {
                    var last = j == 0 ? 0 : W[i, j - 1];
                    if (grid[i, j] == '0')
                    {
                        W[i, j] = last;
                    }
                    else if (grid[i, j] == 'E')
                    {
                        W[i, j] = last + 1;
                    }
                    else
                    {
                        W[i, j] = 0;
                    }
                }
            }

            for (var i = 0; i < len0; ++i)
            {
                for (var j = len1 - 1; j >= 0; --j)
                {
                    var last = j == len1 - 1 ? 0 : E[i, j + 1];
                    if (grid[i, j] == '0')
                    {
                        E[i, j] = last;
                    }
                    else if (grid[i, j] == 'E')
                    {
                        E[i, j] = last + 1;
                    }
                    else
                    {
                        E[i, j] = 0;
                    }
                }
            }

            for (var j = 0; j < len1; ++j)
            {
                for (var i = 0; i < len0; ++i)
                {
                    var last = i == 0 ? 0 : N[i - 1, j];
                    if (grid[i, j] == '0')
                    {
                        N[i, j] = last;
                    }
                    else if (grid[i, j] == 'E')
                    {
                        N[i, j] = last + 1;
                    }
                    else
                    {
                        N[i, j] = 0;
                    }
                }
            }

            for (var j = 0; j < len1; ++j)
            {
                for (var i = len0 - 1; i >= 0; --i)
                {
                    var last = i == len0 - 1 ? 0 : S[i + 1, j];
                    if (grid[i, j] == '0')
                    {
                        S[i, j] = last;
                    }
                    else if (grid[i, j] == 'E')
                    {
                        S[i, j] = last + 1;
                    }
                    else
                    {
                        S[i, j] = 0;
                    }
                }
            }
            
            for (var i = 0; i < len0; ++i)
            {
                for (var j = 0; j < len1; ++j)
                {
                    if (grid[i, j] == '0')
                    {
                        best = Math.Max(best,
                            (j - 1 < 0 ? 0 : W[i, j - 1])+
                            (j + 1 > len1 - 1 ? 0 : E[i, j + 1])+
                            (i - 1 < 0 ? 0 : N[i - 1, j])+
                            (i + 1 > len0 - 1 ? 0 : S[i + 1, j])
                        );
                    }
                }
            }

            return best;
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
