using System;

namespace _0457
{
    public class Solution
    {
        public bool CircularArrayLoop(int[] nums)
        {
            Console.WriteLine("start");
            if (nums == null || nums.Length == 0)
            {
                return false;
            }

            var idx = 0;
            var startIdx = 0;
            var n = nums.Length;
            var forward = nums[idx] > 0;
            var visitCount = 0;
            while (true)
            {
                var nextIdx = 0;
                if (nums[idx] > 0)
                {
                    if (!forward)
                    {
                        // mark as failure
                        nextIdx = idx;
                    }
                    else
                    {
                        nextIdx = (idx + nums[idx]) % n;
                    }
                }
                else
                {
                    if (forward)
                    {
                        // mark as failure
                        nextIdx = idx;
                    }
                    else
                    {
                        nextIdx = (idx + (n + (nums[idx] % n))) % n;
                    }
                }
                if (nums[idx] != 0)
                {
                    visitCount++;
                }
                nums[idx] = 0;
                Console.WriteLine($"{idx}, {nextIdx}");
                Console.WriteLine($"v {visitCount}");
                // self loop is not a loop
                if (idx == nextIdx)
                {
                    // run out of elements
                    if (visitCount == n)
                    {
                        return false;
                    }
                    // find next start position
                    while (nums[nextIdx] == 0)
                    {
                        nextIdx = (nextIdx + 1) % n;
                    }
                    startIdx = nextIdx;
                    forward = nums[nextIdx] > 0;
                }
                // true loop
                else if (nextIdx == startIdx)
                {
                    return true;
                }
                idx = nextIdx;
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
