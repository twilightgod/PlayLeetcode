using System;
using System.Collections.Generic;

namespace _0301_1
{
    public class Solution
    {
        public IList<string> RemoveInvalidParentheses(string s)
        {
            // get how many left and right parentheses need to be removed
            var lCount = 0;
            var rCount = 0;
            foreach (var c in s)
            {
                if (c == ')')
                {
                    if (lCount == 0)
                    {
                        rCount++;
                    }
                    else
                    {
                        lCount--;
                    }
                }
                else if (c == '(')
                {
                    lCount++;
                }
            }

            var answers = new List<string>();

            DFS(s, 0, answers, lCount, rCount);
                
            return answers;
        }

        private void DFS(string answer, int startIndex, List<string> answers, int lCount, int rCount)
        {
            if (lCount == 0 && rCount == 0)
            {
                if (IsValidString(answer))
                {
                    answers.Add(answer);
                }
                return;
            }

            for (var i = startIndex; i < answer.Length; ++i)
            {
                // only handle first one for continous ( or ) to avoid duplication
                if (i == startIndex || answer[i] != answer[i - 1])
                {
                    // handle ) first, to ensure answer[0 ... i] is valid 
                    if (rCount > 0 && answer[i] == ')')
                    {
                        // removed ith char, so next startindex is still i
                        DFS(answer.Remove(i, 1), i, answers, lCount, rCount - 1);
                    }
                    else if (lCount > 0 && answer[i] == '(')
                    {
                        DFS(answer.Remove(i, 1), i, answers, lCount - 1, rCount);
                    }
                }
            }
        }

        private bool IsValidString(string s)
        {
            var counter = 0;

            foreach (var c in s)
            {
                if (c == ')')
                {
                    counter--;
                }
                else if (c == '(')
                {
                    counter++;
                }
                if (counter < 0)
                {
                    return false;
                }
            }

            return counter == 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().RemoveInvalidParentheses(")(");
            new Solution().RemoveInvalidParentheses("()())()");
            new Solution().RemoveInvalidParentheses("(()a");
            Console.WriteLine("Hello World!");
        }
    }
}
