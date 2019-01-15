using System;
using System.Collections.Generic;

namespace _0216
{
    public class Solution
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            var answer = new List<int>();
            var answers = new List<IList<int>>();
            var used = new HashSet<int>();

            DFS(0, k, 0, n, used, answer, answers);

            return answers;
        }

        private void DFS(int depth, int k, int sum, int n, HashSet<int> used, List<int> answer, List<IList<int>> answers)
        {
            if (depth == k)
            {
                if (sum == n)
                {
                    answers.Add(new List<int>(answer));
                }
                return;
            }

            for (var i = depth == 0 ? 1 : answer[depth - 1]; i <= 9; ++i)
            {
                if (!used.Contains(i))
                {
                    if (sum + i <= n)
                    {
                        used.Add(i);
                        answer.Add(i);
                        DFS(depth + 1, k, sum + i, n, used, answer, answers);
                        answer.RemoveAt(depth);
                        used.Remove(i);
                    }
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
