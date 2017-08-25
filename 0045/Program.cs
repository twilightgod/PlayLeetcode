using System;
using System.Collections.Generic;

namespace _0045
{
    public class Solution
    {
        public int Jump(int[] nums)
        {
            var n = nums.Length;
            var step = new int[n];
            var q = new Queue<int>();
            var maxreach = 0;

            q.Enqueue(0);

            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node == n - 1)
                {
                    break;
                }

                for (int i = maxreach + 1; i - node <= nums[node] && i < n; ++i)
                {
                    if (step[i] == 0)
                    {
                        step[i] = step[node] + 1;
                        q.Enqueue(i);
                    }
                }

                maxreach = Math.Max(maxreach, node + nums[node]);
            }
            return step[n - 1];
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
