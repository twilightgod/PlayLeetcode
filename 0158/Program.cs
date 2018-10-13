using System;
using System.Collections.Generic;

namespace _0158
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

        char[] tmpBuffer = new char[4];
        int tmpBufferIndex = 0;
        int tmpBufferLength = 0;
        bool IsEOF = false;

        public int Read(char[] buf, int n)
        {
            var counter = 0;
            
            while (true)
            {
                while (tmpBufferIndex < tmpBufferLength && counter < n)
                {
                    buf[counter++] = tmpBuffer[tmpBufferIndex++];
                }
                if (counter == n || IsEOF)
                {
                    // read enough n chars or EOF
                    break;
                }

                if (!IsEOF)
                {
                    tmpBufferLength = Read4(tmpBuffer);
                    tmpBufferIndex = 0;
                    if (tmpBufferLength < 4)
                    {
                        IsEOF = true;
                    }
                }
            }

            return counter;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().Read(new char[10], 1);
            Console.WriteLine("Hello World!");
        }
    }
}
