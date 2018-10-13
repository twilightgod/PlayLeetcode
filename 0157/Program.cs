using System;

namespace _0157
{
    /* The Read4 API is defined in the parent class Reader4.
      int Read4(char[] buf); */

    public class Solution : Reader4
    {
        /**
         * @param buf Destination buffer
         * @param n   Maximum number of characters to read
         * @return    The number of characters read
         */
        public int Read(char[] buf, int n)
        {
            var counter = 0;
            var innerBuffer = new char[4];
            while (true)
            {
                var r = Read4(innerBuffer);
                for (var j = 0; j < r; ++j)
                {
                    if (counter == n)
                    {
                        break;
                    }
                    buf[counter++] = innerBuffer[j];
                }
                if (r < 4)
                {
                    break;
                }
            }
            return counter;
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
