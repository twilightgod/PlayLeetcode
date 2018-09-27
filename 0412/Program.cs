using System;
using System.Collections.Generic;
using System.Text;

namespace _0412
{
    public class Solution
    {
        public IList<string> FizzBuzz(int n)
        {
            var answers = new List<string>();
            for (var i = 1; i <= n; ++i)
            {
                var sb = new StringBuilder();
                if (i % 3 == 0)
                {
                    sb.Append("Fizz");
                }
                if (i % 5 == 0)
                {
                    sb.Append("Buzz");
                }
                if (sb.Length == 0)
                {
                    sb.Append(i);
                }
                answers.Add(sb.ToString());
            }
            return answers;
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
