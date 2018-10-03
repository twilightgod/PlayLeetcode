using System;
using System.Collections.Generic;

namespace _0296
{
    public class Solution
    {
        public int MinTotalDistance(int[,] grid)
        {
            var rows = new List<int>();
            var cols = new List<int>();

            for (var i = 0; i < grid.GetLength(0); ++i)
            {
                for (var j = 0; j < grid.GetLength(1); ++j)
                {
                    if (grid[i, j] == 1)
                    {
                        rows.Add(i);
                    }
                }
            }

            for (var i = 0; i < grid.GetLength(1); ++i)
            {
                for (var j = 0; j < grid.GetLength(0); ++j)
                {
                    if (grid[j, i] == 1)
                    {
                        cols.Add(i);
                    }
                }
            }

            return MinTotalDistance1D(rows) + MinTotalDistance1D(cols);
        }

        private int MinTotalDistance1D(List<int> nums)
        {
            var distance = 0;
            var l = 0;
            var r = nums.Count - 1;
            while (l < r)
            {
                distance += (nums[r--] - nums[l++]);
            }

            return distance;
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
