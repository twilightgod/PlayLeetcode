using System;
using System.Collections.Generic;

namespace _0247
{
    public class Solution
    {
        public IList<string> FindStrobogrammatic(int n)
        {
            var mapping = new Dictionary<char, char>()
            {
                ['0'] = '0',
                ['1'] = '1',
                ['6'] = '9',
                ['8'] = '8',
                ['9'] = '6',
            };
            var answers = new List<string>();
            var answer = new char[n];
            DFS(0, n, mapping, answers, answer);
            return answers;
        }

        private void DFS(int depth, int n, Dictionary<char, char> mapping, List<string> answers, char[] answer)
        {
            if (depth == (n + 1) / 2)
            {
                answers.Add(new String(answer));
                return;
            }
            foreach (var kvp in mapping)
            {
                if (n % 2 == 1 && depth == n / 2)
                {
                    if (kvp.Key == '6' || kvp.Key == '9')
                    {
                        continue;
                    }
                }
                else if (depth == 0 && kvp.Key == '0')
                {
                    continue;
                }
                answer[depth] = kvp.Key;
                answer[n - depth - 1] = kvp.Value;
                DFS(depth + 1, n, mapping, answers, answer);
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
