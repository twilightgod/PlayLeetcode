using System;
using System.Collections.Generic;
using System.Linq;

namespace _0227
{
    public class Solution
    {
        public int Calculate(string s)
        {
            if (String.IsNullOrEmpty(s) || s.Length == 0)
            {
                return 0;
            }

            s = "(" + s + ")+";

            var tokenizer = new Tokenizer(s);
            var numStack = new Stack<int>();
            // rank is (level, priority)
            // level is parenthese level
            // priority for + and - is 0, * and / is 1
            var opStack = new Stack<((int, int) rank, char op)>();
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
                    var curop = (char)token;
                    var priority = curop == '*' || curop == '/' ? 1 : 0;
                    var currank = (level, priority);
                    while (opStack.Count > 0 && currank.CompareTo(opStack.Peek().rank) <= 0)
                    {
                        var num1 = numStack.Pop();
                        var num2 = numStack.Pop();
                        var op = opStack.Pop().op;
                        switch (op)
                        {
                            case '+':
                                num2 += num1;
                                break;
                            case '-':
                                num2 -= num1;
                                break;
                            case '*':
                                num2 *= num1;
                                break;
                            case '/':
                                num2 /= num1;
                                break;
                        }
                        numStack.Push(num2);
                    }
                    opStack.Push((currank, curop));
                }
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
            else if (s[idx] == '+' || s[idx] == '-' || s[idx] == '*' || s[idx] == '/')
            {
                return (TokenType.Operator, s[idx++]);
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
            Console.WriteLine("Hello World!");
        }
    }
}
