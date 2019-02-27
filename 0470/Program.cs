using System;

namespace _0470
{
    /**
 * The Rand7() API is already defined in the parent class SolBase.
 * public int Rand7();
 * @return a random integer in the range 1 to 7
 */
    public class Solution : SolBase
    {
        public int Rand10()
        {
            /*
                Run rand7 twice
                7 * 7 = 49
                49 / 10 = 4
                49 % 10 = 9
                discard last 9 entries
             */

            while (true)
            {
                var r1 = Rand7();
                var r2 = Rand7();
                // x is [0, 48]
                var x = (r1 - 1) * 7 + (r2 - 1);
                if (x >= 40)
                {
                    continue;
                }
                return x % 10 + 1;
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
