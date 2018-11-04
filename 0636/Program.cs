using System;
using System.Collections.Generic;

namespace _0636
{
    public class Solution
    {
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            var stack = new Stack<(int id, int t)>();
            var time = new int[n];

            foreach (var log in logs)
            {
                var op = log.Split(':');
                var id = Int32.Parse(op[0]);
                var t = Int32.Parse(op[2]);
                if (op[1] == "start")
                {
                    stack.Push((id, t));
                }
                else
                {
                    var top = stack.Pop();
                    var span = t - top.t + 1;
                    time[id] += span;
                    if (stack.Count > 0)
                    {
                        time[stack.Peek().id] -= span;
                    }
                }
            }

            return time;
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
