using System;
using System.Collections.Generic;

namespace _0077
{
    public class Solution
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            var answers = new List<IList<int>>();
            var answer = new List<int>();
            var used = new HashSet<int>();
            DFS(0, n, k, used, answer, answers);
            return answers;
        }

        private void DFS(int depth, int n, int k, HashSet<int> used, List<int> answer, List<IList<int>> answers)
        {
            if (depth == k)
            {
                answers.Add(new List<int>(answer));
                return;
            }
            
            for (var i = answer.Count == 0 ? 1 : answer[answer.Count - 1]; i <= n; ++i)
            {
                if (!used.Contains(i))
                {
                    used.Add(i);
                    answer.Add(i);
                    DFS(depth + 1, n, k, used, answer, answers);
                    answer.RemoveAt(answer.Count - 1);
                    used.Remove(i);
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
