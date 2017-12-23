using System;
using System.Collections.Generic;

namespace _0388
{
    public class Solution
    {
        public int LengthLongestPath(string input)
        {
            input += "\n";
            var best = 1;
            var levels = new Stack<int>();
            var curLength = 0;
            var begin = 0;
            var end = 0;

            while (begin < input.Length)
            {
                end = input.IndexOf("\n", begin);
                if (end == -1)
                {
                    break;
                }
                var part = input.Substring(begin, end - begin);
                var curLevel = 1;
                while (part.StartsWith("\t"))
                {
                    curLevel++;
                    part = part.Substring(1);
                }

                while (curLevel <= levels.Count)
                {
                    curLength -= levels.Peek();
                    levels.Pop();
                }

                levels.Push(part.Length + 1);
                curLength += part.Length + 1; // '\'

                if (part.Contains(".")) // file
                {
                    best = Math.Max(best, curLength);
                }

                begin = end + 1;
            }

            return best - 1; // last '\'
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().LengthLongestPath("dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext"));
        }
    }
}
