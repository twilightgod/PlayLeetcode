using System;

namespace _0029
{
    public class Solution
    {
        public int Divide(int dividend, int divisor)
        {
            if (dividend == Int32.MinValue && divisor == -1)
            {
                // overflow
                return Int32.MaxValue;
            }

            // make them all negtive to avoid overflow
            var flipSign = false;

            if (dividend < 0)
            {
                if (divisor < 0)
                {

                }
                else
                {
                    divisor = -divisor;
                    flipSign = true;
                }
            }
            else
            {
                dividend = -dividend;
                if (divisor < 0)
                {
                    flipSign = true;
                }
                else
                {
                    divisor = -divisor;
                }
            }

            var result = 0;

            // reverse of >= since they're negtive
            while (dividend <= divisor)
            {
                var times = 1;
                var subvalue = divisor;
                // reverse of < since they're negtive
                while (dividend - subvalue < subvalue)
                {
                    times += times;
                    subvalue += subvalue;
                }
                result += times;
                dividend -= subvalue;
            }

            return flipSign ? -result : result;
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
