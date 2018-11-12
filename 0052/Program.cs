using System;
using System.Collections.Generic;

namespace _0052
{
    public class Solution
    {
        public int TotalNQueens(int n)
        {
            var usedCol = new HashSet<int>();
            var usedDiag1 = new HashSet<int>();
            var usedDiag2 = new HashSet<int>();
            return DFS(n, 0, usedCol, usedDiag1, usedDiag2);
        }

        private int DFS(int n, int depth, 
            HashSet<int> usedCol, HashSet<int> usedDiag1, HashSet<int> usedDiag2)
        {
            if (depth == n)
            {
                return 1;
            }
            var answer = 0;
            for (var i = 0; i < n; ++i)
            {
                if (!usedCol.Contains(i) && !usedDiag1.Contains(i + depth) && !usedDiag2.Contains(i - depth))
                {
                    usedCol.Add(i);
                    usedDiag1.Add(i + depth);
                    usedDiag2.Add(i - depth);
                    answer += DFS(n, depth + 1, usedCol, usedDiag1, usedDiag2);
                    usedCol.Remove(i);
                    usedDiag1.Remove(i + depth);
                    usedDiag2.Remove(i - depth);
                }
            }
            return answer;
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
