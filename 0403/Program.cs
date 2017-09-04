using System;
using System.Collections.Generic;

namespace _0403
{
    public class Solution
    {
        public bool CanCross(int[] stones)
        {
            var jumpk = new Dictionary<int, HashSet<int>>();
            foreach (var stone in stones)
            {
                jumpk.Add(stone, new HashSet<int>());
            }

            jumpk[0].Add(0);

            foreach (var stone in stones)
            {
                if (jumpk[stone].Count > 0)
                {
                    foreach (var k in jumpk[stone])
                    {
                        for (var i = -1; i <= 1; ++i)
                        {
                            var jumpto = stone + k + i;
                            if (jumpto <= stone)
                            {
                                continue;
                            }
                            if (jumpk.ContainsKey(jumpto))
                            {
                                jumpk[jumpto].Add(k + i);
                            }
                        }
                    }
                }
            }

            return jumpk[stones[stones.Length - 1]].Count > 0;
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
