using System;
using System.Linq;

namespace _0152
{
    public class Solution
    {
        public int MaxProduct(int[] nums)
        {
            var best = nums.Max();
            
            var pre_max = 1;
            var pre_min = 1;

            foreach (var num in nums)
            {
                var cur_max = Math.Max(pre_max * num, pre_min * num);
                var cur_min = Math.Min(pre_max * num, pre_min * num);

                if (cur_max < 1)
                {
                    pre_max = 1;
                }
                else
                {
                    pre_max = cur_max;
                    best = Math.Max(best, cur_max);
                }

                if (cur_min >= 0)
                {
                    pre_min = 1;
                }
                else
                {
                    pre_min = cur_min;
                }
            }

            return best;
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
