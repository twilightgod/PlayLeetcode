using System;
using System.Collections.Generic;

namespace _0267
{
    public class Solution
    {
        public IList<string> GeneratePalindromes(string s)
        {
            var n = s.Length;
            var cnt = new Dictionary<char, int>();
            foreach (var c in s)
            {
                cnt[c] = cnt.GetValueOrDefault(c) + 1;
            }
            var answers = new List<string>();
            var answer = new char[n];
            if (IsPossible(cnt))
            {
                DFS(0, n, cnt, answer, answers);
            }
            return answers;
        }

        private bool IsPossible(Dictionary<char, int> cnt)
        {
            var oddCnt = 0;
            foreach (var value in cnt.Values)
            {
                if (value % 2 == 1)
                {
                    if (++oddCnt > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void DFS(int depth, int n, Dictionary<char, int> cnt, char[] answer, List<string> answers)
        {
            // only need to fill half
            if (depth == n / 2)
            {
                // fill in last one for odd length
                if (n % 2 == 1)
                {
                    foreach (var kvp in cnt)
                    {
                        if (kvp.Value != 0)
                        {
                            answer[depth] = kvp.Key;
                            break;
                        }
                    }
                }
                answers.Add(new string(answer));
                return;
            }

            // need to make a copy since Dictionary can't be changed during loop
            var cnt_copied = new Dictionary<char, int>(cnt);
            foreach (var kvp in cnt)
            {
                if (kvp.Value >= 2)
                {
                    answer[depth] = kvp.Key;
                    answer[n - depth - 1] = kvp.Key;
                    cnt_copied[kvp.Key] -= 2;
                    DFS(depth + 1, n, cnt_copied, answer, answers);
                    cnt_copied[kvp.Key] += 2;
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
