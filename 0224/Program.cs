using System;
using System.Collections.Generic;
using System.Linq;

namespace _0224
{
    public class Solution
    {
        public int Calculate(string s)
        {
            if (String.IsNullOrEmpty(s) || s.Length == 0)
            {
                return 0;
            }

            var tokenizer = new Tokenizer(s);
            var numStack = new Stack<int>();
            var opStack = new Stack<(int level, char op)>();
            int level = 0;

            while (true)
            {
                var (type, token) = tokenizer.GetNextToken();
                if (type == TokenType.Invalid)
                {
                    break;
                }
                else if (type == TokenType.Parenthese)
                {
                    if ((char)token == '(')
                    {
                        level++;
                    }
                    else
                    {
                        level--;
                    }
                }
                else if (type == TokenType.Number)
                {
                    numStack.Push((int)token);
                }
                else
                {
                    while (opStack.Count > 0 && level <= opStack.Peek().level)
                    {
                        var num1 = numStack.Pop();
                        var num2 = numStack.Pop();
                        var op = opStack.Pop().op;
                        if (op == '+')
                        {
                            num2 += num1;
                        }
                        else
                        {
                            num2 -= num1;
                        }
                        numStack.Push(num2);
                    }
                    opStack.Push((level, (char)token));
                }
            }

            while (opStack.Count > 0)
            {
                var num1 = numStack.Pop();
                var num2 = numStack.Pop();
                var op = opStack.Pop().op;
                if (op == '+')
                {
                    num2 += num1;
                }
                else
                {
                    num2 -= num1;
                }
                numStack.Push(num2);
            }

            return numStack.First();
        }
    }

    public enum TokenType
    {
        Invalid,
        Operator,
        Number,
        Parenthese,
    }

    public class Tokenizer
    {
        int idx = 0;
        string s;

        public Tokenizer(string s)
        {
            this.s = s;
        }

        public (TokenType type, object token) GetNextToken()
        {
            while (idx < s.Length && s[idx] == ' ')
            {
                idx++;
            }
            if (idx == s.Length)
            {
                return (TokenType.Invalid, ' ');
            }
            else if (s[idx] == '(')
            {
                idx++;
                return (TokenType.Parenthese, '(');
            }
            else if (s[idx] == ')')
            {
                idx++;
                return (TokenType.Parenthese, ')');
            }
            else if (s[idx] == '+')
            {
                idx++;
                return (TokenType.Operator, '+');
            }
            else if (s[idx] == '-')
            {
                idx++;
                return (TokenType.Operator, '-');
            }
            else
            {
                var num = 0;
                while (idx < s.Length && Char.IsDigit(s[idx]))
                {
                    num = num * 10 + ((int)s[idx++] - (int)'0');
                }
                return (TokenType.Number, num);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().Calculate("2-(8-6+(4-10))"));
            Console.WriteLine("Hello World!");
        }
    }
}
