using System;
using System.Collections.Generic;

namespace _66
{
    public class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            var list = new List<int>();
            var rest = 1;
            for (int i = digits.Length - 1; i >= 0; --i)
            {
                list.Add((digits[i] + rest) % 10);
                rest = (digits[i] + rest) / 10;
            }

            if (rest > 0)
            {
                list.Add(rest);
            }

            list.Reverse();

            return list.ToArray();
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
