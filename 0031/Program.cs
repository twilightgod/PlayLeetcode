using System;

namespace _0031
{
    public class Solution
    {
        public void NextPermutation(int[] nums)
        {
            if (nums.Length == 0)
            {
                return;
            }

            var pos = nums.Length - 1;
            for (; pos > 0; --pos)
            {
                if (nums[pos] > nums[pos - 1])
                {
                    // swap pos - 1 and larger one
                    for (var i = nums.Length - 1; i >= pos; --i)
                    {
                        if (nums[i] > nums[pos - 1])
                        {
                            // found the one right larger than pos - 1
                            Swap(ref nums[i], ref nums[pos - 1]);
                            break;
                        }
                    }
                    break;
                }
            }

            // reverse [pos ... num.Length - 1]
            for (int i = pos, j = nums.Length - 1; i < j; ++i, --j)
            {
                Swap(ref nums[i], ref nums[j]);
            }

        }

        private void Swap(ref int a, ref int b)
        {
            var c = a;
            a = b;
            b = c;
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
