using System;
using System.Collections.Generic;

namespace _0766
{
    public class Solution
    {
        public bool IsToeplitzMatrix(int[,] matrix)
        {
            var diagValue = new Dictionary<int, int>();
            for (var i = 0; i < matrix.GetLength(0); ++i)
            {
                for (var j = 0; j < matrix.GetLength(1); ++j)
                {
                    var d = i - j;
                    if (!diagValue.ContainsKey(d))
                    {
                        diagValue[d] = matrix[i, j];
                    }
                    else if (diagValue[d] != matrix[i, j])
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
