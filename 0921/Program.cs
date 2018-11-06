using System;

namespace _0921
{
    public class Solution
    {
        public int MinAddToMakeValid(string S)
        {
            var lCount = 0;
            var rCount = 0;
            foreach (var c in S)
            {
                if (c == ')')
                {
                    if (lCount == 0)
                    {
                        rCount++;
                    }
                    else
                    {
                        lCount--;
                    }
                }
                else if (c == '(')
                {
                    lCount++;
                }
            }
            return lCount + rCount;
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
