using System;

namespace _0167
{
    public class Solution
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return null;
            }

            var l = 0;
            var r = numbers.Length - 1;

            while (l < r)
            {
                var sum = numbers[l] + numbers[r];
                if (sum == target)
                {
                    return new int[] {l + 1, r + 1};
                }
                else if (sum < target)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }

            return null;
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
