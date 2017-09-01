using System;
using System.Collections.Generic;

namespace _0202
{
    public class Solution
    {
        public bool IsHappy(int n)
        {
            var set = new HashSet<int>();
            while (true)
            {
                var newn = 0;
                while (n > 0)
                {
                    newn += (int)Math.Pow(n % 10, 2);
                    n /= 10;
                }

                if (newn == 1)
                {
                    return true;
                }

                if (set.Contains(newn))
                {
                    return false;
                }

                set.Add(newn);
                n = newn;
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
