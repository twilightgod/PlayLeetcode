using System;
using System.Collections.Generic;
using System.Text;

namespace _0722
{
    public class Solution
    {
        public IList<string> RemoveComments(string[] source)
        {
            var isInComment = false;
            var answer = new List<string>();
            var sb = new StringBuilder();
            foreach (var s in source)
            {
                if (!isInComment)
                {
                    sb = new StringBuilder();
                }
                for (var i = 0; i < s.Length; ++i)
                {
                    if (!isInComment && i + 1 < s.Length && s[i] == '/' && s[i + 1] == '/')
                    {
                        break;
                    }
                    else if (!isInComment && i + 1 < s.Length && s[i] == '/' && s[i + 1] == '*')
                    {
                        isInComment = true;
                        i++;
                    }
                    else if (isInComment && i + 1 < s.Length && s[i] == '*' && s[i + 1] == '/')
                    {
                        isInComment = false;
                        i++;
                    }
                    else if (!isInComment)
                    {
                        sb.Append(s[i]);
                    }
                }
                if (!isInComment && sb.Length > 0)
                {
                    answer.Add(sb.ToString());
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
