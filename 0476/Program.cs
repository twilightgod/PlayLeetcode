using System;

namespace _0476
{
    /*
    num          = 00000101
    mask         = 11111000
    num ^ (~mask)= 00000010
     */
    public class Solution
    {
        public int FindComplement(int num)
        {
            var mask = -1;
            while ((mask & num) > 0)
            {
                mask <<= 1;
            }
            return num ^ (~mask);
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
