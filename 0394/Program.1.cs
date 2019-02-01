using System;
using System.Collections.Generic;
using System.Text;

namespace _0394_1
{
    // Stage Machine + Stack
    public class Solution
    {
        public string DecodeString(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return s;
            }

            s += "]";

            var stack = new Stack<(int, string)>();
            var curNum = 1;
            var curStr = String.Empty;
            var nextNum = -1;
            foreach (var c in s)
            {
                if (Char.IsDigit(c))
                {
                    if (nextNum == -1)
                    {
                        nextNum = c - '0';
                    }
                    else
                    {
                        nextNum = nextNum * 10 + c - '0';
                    }
                }
                else if (c == '[')
                {
                    stack.Push((curNum, curStr));
                    curNum = nextNum;
                    curStr = String.Empty;
                    nextNum = -1;
                }
                else if (c == ']')
                {
                    var (preNum, preStr) = stack.Pop();
                    for (var i = 0; i < curNum; ++i)
                    {
                        preStr += curStr;
                    }
                    curNum = preNum;
                    curStr = preStr;
                }
                else
                {
                    curStr += c;
                }
            }
            return curStr;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().DecodeString("3[a]2[bc]");
            Console.WriteLine("Hello World!");
        }
    }
}
