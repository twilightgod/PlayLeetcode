using System;

namespace _0258
{
    public class Solution
    {
        public int AddDigits(int num)
        {
            return 1 + (num - 1) % 9;
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
