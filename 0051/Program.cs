using System;
using System.Collections.Generic;

namespace _0051
{
    public class Solution
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            var usedCol = new HashSet<int>();
            var usedDiag1 = new HashSet<int>();
            var usedDiag2 = new HashSet<int>();
            var answers = new List<IList<string>>();
            var answer = new char[n][];
            for (var i = 0; i < n; ++i)
            {
                answer[i] = new char[n];
                for (var j = 0; j < n; ++j)
                {
                    answer[i][j] = '.';
                }
            }
            DFS(n, 0, answer, answers, usedCol, usedDiag1, usedDiag2);
            return answers;
        }

        private void DFS(int n, int depth, char[][] answer, List<IList<string>> answers,
            HashSet<int> usedCol, HashSet<int> usedDiag1, HashSet<int> usedDiag2)
        {
            if (depth == n)
            {
                var clonedAnswer = new List<string>();
                for (var i = 0; i < n; ++i)
                {
                    clonedAnswer.Add(new String(answer[i]));
                }
                answers.Add(clonedAnswer);
                return;
            }
            for (var i = 0; i < n; ++i)
            {
                if (!usedCol.Contains(i) && !usedDiag1.Contains(i + depth) && !usedDiag2.Contains(i - depth))
                {
                    answer[depth][i] = 'Q';
                    usedCol.Add(i);
                    usedDiag1.Add(i + depth);
                    usedDiag2.Add(i - depth);
                    DFS(n, depth + 1, answer, answers, usedCol, usedDiag1, usedDiag2);
                    answer[depth][i] = '.';
                    usedCol.Remove(i);
                    usedDiag1.Remove(i + depth);
                    usedDiag2.Remove(i - depth);
                }
            }
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
