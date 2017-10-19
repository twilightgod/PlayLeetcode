using System;
using System.Collections.Generic;

namespace _0150
{
    public class Solution
    {
        public int EvalRPN(string[] tokens)
        {
            var stack = new Stack<int>();
            foreach (var str in tokens)
            {
                var IsOperation = false;
                
                switch(str)
                {
                    case "+":
                        case "-":
                        case "*":
                        case "/":
                        IsOperation = true;
                        break;
                        default:
                            stack.Push(Int32.Parse(str));
                            break;

                }

                if (IsOperation)
                {
                    var n2 = stack.Pop();
                    var n1 = stack.Pop();
                    var n3 = 0;
                    switch(str)
                    {
                        case "+":
                            n3 = n1 + n2;
                            break;
                            case "-":
                            n3 = n1 - n2;
                            break;
                            case "*":
                            n3 = n1 * n2;
                            break;
                            case "/":
                            n3 = n1 / n2;
                            break;
                            default:
                                break;

                    }

                    stack.Push(n3);
                }
            }

            return stack.Peek();
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
