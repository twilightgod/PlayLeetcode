using System;
using System.Collections.Generic;

namespace _0901
{
    public class StockSpanner
    {
        Stack<(int price, int span)> stack = new Stack<(int price, int span)>();

        public StockSpanner()
        {

        }

        public int Next(int price)
        {
            if (stack.Count == 0 || price < stack.Peek().price)
            {
                stack.Push((price, 1));
            }
            else
            {
                var span = 1;
                while (stack.Count > 0 && price >= stack.Peek().price)
                {
                    var node = stack.Pop();
                    span += node.span;
                }
                stack.Push((price, span));
            }

            return stack.Peek().span;
        }
    }

    /**
     * Your StockSpanner object will be instantiated and called as such:
     * StockSpanner obj = new StockSpanner();
     * int param_1 = obj.Next(price);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
