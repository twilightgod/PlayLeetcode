using System;
using System.Collections.Generic;

namespace _0753
{
    public class Solution
    {
        public string CrackSafe(int n, int k)
        {
            var m = (int)Math.Pow(k, n);
            var start = string.Empty;
            for (var i = 0; i < n; ++i)
            {
                start += '0';
            }

            var visited = new HashSet<string>();
            visited.Add(start);

            var answer = string.Empty;
            DFS(start, k, m, visited, start, ref answer);

            return answer;
        }

        private bool DFS(string current, int k, int m, HashSet<string> visited, string answer_tmp, ref string answer)
        {
            if (visited.Count == m)
            {
                answer = answer_tmp;
                return true;
            }

            for (var i = 0; i < k; ++i)
            {
                var next = current.Substring(1) + i.ToString();
                if (!visited.Contains(next))
                {
                    visited.Add(next);
                    if (DFS(next, k, m, visited, answer_tmp + i.ToString(), ref answer))
                    {
                        return true;
                    }
                    visited.Remove(next);
                }
            }

            return false;
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
