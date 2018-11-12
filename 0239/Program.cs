using System;
using System.Collections.Generic;
using System.Linq;

namespace _0239
{
    public class Solution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var idxList = new LinkedList<int>();
            var n = nums.Length;
            var answers = new List<int>();
            for (var i = 0; i < n; ++i)
            {
                // remove old
                if (idxList.Count > 0 && idxList.First() < i - k + 1)
                {
                    idxList.RemoveFirst();
                }
                // remove all elements less or equal than i, since they will not be max when i is in the queue
                while (idxList.Count > 0 && nums[idxList.Last()] <= nums[i])
                {
                    idxList.RemoveLast();
                }
                // add i
                idxList.AddLast(i);
                if (i >= k - 1)
                {
                    answers.Add(nums[idxList.First()]);
                }
            }
            return answers.ToArray();
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
