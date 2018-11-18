using System;

namespace _0360
{
    public class Solution
    {
        public int[] SortTransformedArray(int[] nums, int a, int b, int c)
        {
            var n = nums.Length;
            var answer = new int[n];
            if (a == 0)
            {
                if (b == 0)
                {
                    for (var i = 0; i < n; ++i)
                    {
                        answer[i] = c;
                    }
                }
                else if (b > 0)
                {
                    for (var i = 0; i < n; ++i)
                    {
                        answer[i] = b * nums[i] + c;
                    }
                }
                else // b < 0
                {
                    for (var i = 0; i < n; ++i)
                    {
                        answer[i] = b * nums[n - i - 1] + c;
                    }
                }
            }
            else if (a > 0)
            {
                // find min to cut the array
                var cut = 0;
                for (var i = 0; i < n; ++i)
                {
                    nums[i] = a * nums[i] * nums[i] + b * nums[i] + c;
                    if (nums[i] < nums[cut])
                    {
                        cut = i;
                    }
                }
                // merge [cut -> 0] and [cut + 1 -> n - 1]
                var idx = 0;
                var p1 = cut;
                var p2 = cut + 1;
                while (p1 >= 0 && p2 < n)
                {
                    if (nums[p1] < nums[p2])
                    {
                        answer[idx++] = nums[p1--];
                    }
                    else
                    {
                        answer[idx++] = nums[p2++];
                    }
                }
                while (p1 >= 0)
                {
                    answer[idx++] = nums[p1--];
                }
                while (p2 < n)
                {
                    answer[idx++] = nums[p2++];
                }
            }
            else // a < 0
            {
                // find max to cut the array
                var cut = 0;
                for (var i = 0; i < n; ++i)
                {
                    nums[i] = a * nums[i] * nums[i] + b * nums[i] + c;
                    if (nums[i] > nums[cut])
                    {
                        cut = i;
                    }
                }
                // merge [0 -> cut] and [n - 1 -> cut + 1]
                var idx = 0;
                var p1 = 0;
                var p2 = n - 1;
                while (p1 <= cut && p2 > cut)
                {
                    if (nums[p1] < nums[p2])
                    {
                        answer[idx++] = nums[p1++];
                    }
                    else
                    {
                        answer[idx++] = nums[p2--];
                    }
                }
                while (p1 <= cut)
                {
                    answer[idx++] = nums[p1++];
                }
                while (p2 > cut)
                {
                    answer[idx++] = nums[p2--];
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
