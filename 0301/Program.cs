using System;
using System.Collections.Generic;

namespace _0301
{
    public class Solution
    {
        public IList<string> RemoveInvalidParentheses(string s)
        {
            var result = new List<string>();

            DFS(s, 0, 0, result, Parentheses1);

            return result;
        }

        private static Tuple<char, char> Parentheses1 = new Tuple<char, char>('(', ')');
        private static Tuple<char, char> Parentheses2 = new Tuple<char, char>(')', '(');

        private void DFS(string s, int CurrentPos, int LastDeletePos, List<string> Result, Tuple<char, char> Parentheses)
        {
            var counter = 0;

            for (var i = CurrentPos; i < s.Length; ++i)
            {
                if (s[i] == Parentheses.Item1)
                {
                    counter++;
                }
            
                if (s[i] == Parentheses.Item2)
                {
                    counter--;
                }

                // Parenthese 2 is more than 1
                if (counter < 0)
                {
                    for (var j = LastDeletePos; j <= i; ++j)
                    {
                        if (s[j] == Parentheses.Item2 && (j == 0 || s[j - 1] != Parentheses.Item2))
                        {
                            // actually since j has been deleted, i & j shift by 1
                            DFS(s.Substring(0, j) + s.Substring(j + 1), i, j, Result, Parentheses);
                        }
                    }

                    // don't need to check reverse version, since current s has more Parenthese 2
                    return;
                }
            }

            if (Parentheses == Parentheses1)
            {
                DFS(ReverseString(s), 0, 0, Result, Parentheses2);
            }
            else // if (counter == 0)
            {
                Result.Add(ReverseString(s));
            }
        }

        private static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().RemoveInvalidParentheses("(()a");
            Console.WriteLine("Hello World!");
        }
    }
}
