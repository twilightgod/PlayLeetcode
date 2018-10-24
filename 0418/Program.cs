using System;

namespace _0418
{
    public class Solution
    {
        public int WordsTyping(string[] sentence, int rows, int cols)
        {
            var s = String.Join(" ", sentence);
            s += " ";
            var answer = 0;
            var len = s.Length;
            var p = 0;
            for (var i = 0; i < rows; ++i)
            {
                var newp = (p + cols) % len;
                var times = (p + cols) / len;
                // adjust newp
                // if it stops at non-space char, need to go back to last space, and add 1 for next round
                while (s[newp] != ' ')
                {
                    newp--;
                    if (newp == -1)
                    {
                        newp = len - 1;
                        times--;
                    }
                }

                if (++newp == len)
                {
                    times++;
                    newp = 0;
                }

                p = newp;
                answer += times;

                // optimization for loop
                if (p == 0)
                {
                    answer = answer * rows / (i + 1);
                    break;
                }
            }

            return answer;
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
