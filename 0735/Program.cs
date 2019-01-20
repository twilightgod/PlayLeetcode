using System;
using System.Collections.Generic;
using System.Linq;

namespace _0735
{
    public class Solution
    {
        public int[] AsteroidCollision(int[] asteroids)
        {
            var stack = new Stack<int>();

            foreach (var a in asteroids)
            {
                var ast = a;
                while (stack.Count > 0 && stack.Peek() > 0 && ast < 0)
                {
                    if (-ast == stack.Peek())
                    {
                        stack.Pop();
                        ast = 0;
                    }
                    else if (-ast > stack.Peek())
                    {
                        stack.Pop();
                    }
                    else
                    {
                        ast = 0;
                    }
                }
                if (ast != 0)
                {
                    stack.Push(ast);
                }
            }

            return stack.Reverse().ToArray();
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
