using System;
using System.Collections.Generic;
using System.Linq;

namespace _0480
{
    public class Solution
    {
        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            if (nums == null)
            {
                return null;
            }
            
            // Insertion Sort
            // SortedList doesn't allow duplicate keys, so add index as part of the key, and we don't need value actually: <(nums[i], i), 0>
            var data = new SortedList<(int, int), int>();
            for (var i = 0; i < k; ++i)
            {
                data.Add((nums[i], i), 0);
            }
            var answer = new List<double>();
            // generate answer
            for (var i = k; i <= nums.Length; ++i)
            {
                // loop one more time in order to make code clean
                answer.Add((k & 1) == 0 ? ((double)data.Keys[(k - 1) / 2].Item1 + data.Keys[(k - 1) / 2 + 1].Item1) / 2.0 : data.Keys[(k - 1) / 2].Item1);
                if (i == nums.Length)
                {
                    break;
                }
                data.Add((nums[i], i), 0);
                data.Remove((nums[i - k], i - k)); 
            }
            return answer.ToArray();
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
