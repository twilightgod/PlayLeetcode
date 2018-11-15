using System;
using System.Collections.Generic;

namespace _0036
{
    public class Solution
    {
        public bool IsValidSudoku(char[,] board)
        {
            var rowSet = new List<HashSet<char>>();
            var colSet = new List<HashSet<char>>();
            var boxSet = new List<HashSet<char>>();
            for (var i = 0; i < 9; ++i)
            {
                rowSet.Add(new HashSet<char>());
                colSet.Add(new HashSet<char>());
                boxSet.Add(new HashSet<char>());
            }
            for (var i = 0; i < 9; ++i)
            {
                for (var j = 0; j < 9; ++j)
                {
                    var c = board[i, j];
                    if (c == '.')
                    {
                        continue;
                    }
                    else if (c >= '0' && c <= '9')
                    {
                        var box = i / 3 * 3 + j / 3;
                        if (rowSet[i].Contains(c) || colSet[j].Contains(c) || boxSet[box].Contains(c))
                        {
                            return false;
                        }
                        else
                        {
                            rowSet[i].Add(c);
                            colSet[j].Add(c);
                            boxSet[box].Add(c);
                        }
                    } 
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
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
