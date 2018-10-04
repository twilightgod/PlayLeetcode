using System;

namespace _0393
{
    public class Solution
    {
        public bool ValidUtf8(int[] data)
        {
            var counter = 0;
            foreach (var d in data)
            {
                var b = (byte)d;
                byte mask1 = 0b10000000;
                byte mask2 = 0b11000000;
                if ((b & mask1) == 0)
                {
                    // single byte
                    if (counter > 0)
                    {
                        return false;
                    }
                }
                else if (counter == 0)
                {
                    // first byte of multi bytes
                    do
                    {
                        b <<= 1;
                        if ((b & mask1) == mask1)
                        {
                            counter++;
                        }
                        else
                        {
                            break;
                        }
                    } while (b > 0);

                    // can't start with 10
                    if (counter == 0)
                    {
                        return false;
                    }
                    // longer than 4 byte
                    if (counter >= 4)
                    {
                        return false;
                    }
                }
                else
                {
                    // following of multi bytes, should start with 10
                    if ((b & mask2) == mask1)
                    {
                        counter--;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return counter == 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().ValidUtf8(new int[] {197, 130, 1});
            Console.WriteLine("Hello World!");
        }
    }
}
