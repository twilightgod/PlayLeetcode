using System;
using System.Collections.Generic;

namespace _0093
{
    public class Solution
    {
        public IList<string> RestoreIpAddresses(string s)
        {
            var answers = new List<string>();
            DFS(0, answers, s, String.Empty, 0);
            return answers;
        }

        void DFS(int depth, List<string> answers, string s, string cur, int idx)
        {
            if (depth == 4)
            {
                // use up all digits
                if (idx == s.Length)
                {
                    answers.Add(cur);
                }
                return;
            }

            for (var i = 0; i < 3 && idx + i < s.Length; ++i)
            {
                var seg = s.Substring(idx, i + 1);
                var segInt = Int32.Parse(seg);
                // within range and no leading zeros
                if (segInt >= 0 && segInt <= 255 && segInt.ToString() == seg)
                {
                    DFS(depth + 1, answers, s, cur + (depth == 0 ? String.Empty : ".") + seg, idx + i + 1);
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
