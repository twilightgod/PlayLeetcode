using System;
using System.Collections.Generic;

namespace _0659
{
    public class Solution
    {
        public bool IsPossible(int[] nums)
        {
            var counter = new Dictionary<int, int>();
            var tails = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                counter[num] = counter.GetValueOrDefault(num, 0) + 1;
            }
            foreach (var num in nums)
            {
                // use up
                if (counter[num] == 0)
                {
                    continue;
                }
                // try to add it to a existing list
                if (tails.GetValueOrDefault(num - 1, 0) > 0)
                {
                    --tails[num - 1];
                    tails[num] = tails.GetValueOrDefault(num, 0) + 1;
                }
                // create a new list, the key is to make its length 3 at first, so that we don't need to store the length for each list
                else if (counter.GetValueOrDefault(num + 1, 0) > 0 && counter.GetValueOrDefault(num + 2, 0) > 0)
                {
                    --counter[num + 1];
                    --counter[num + 2];
                    tails[num + 2] = tails.GetValueOrDefault(num + 2, 0) + 1;
                }
                else
                {
                    return false;
                }
                --counter[num];
            }
            return true;
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
