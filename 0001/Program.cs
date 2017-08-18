using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var rest = target - nums[i];
                if (dict.ContainsKey(rest))
                {
                    return new int[2] { dict[rest], i };
                }
                else
                {
                    dict[nums[i]] = i;
                }
            }

            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ret = new Solution().TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            Console.WriteLine(ret);
        }
    }
}
