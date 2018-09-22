using System;
using System.Collections.Generic;
using System.Text;

namespace _0060
{
    public class Solution
    {
        public string GetPermutation(int n, int k)
        {
            var nums = new List<int>();
            for (var i = 1; i <= n; ++i)
            {
                nums.Add(i);
            }

            var factorials = new List<int>();
            for (var i = 0; i <= 9; ++i)
            {
                if (i == 0)
                {
                    factorials.Add(1);
                }
                else
                {
                    factorials.Add(i * factorials[i - 1]);
                }
            }

            // 0-based index
            k--;

            var sb = new StringBuilder();
            for (var i = n; i >= 1; --i)
            {
                var group = k / factorials[i - 1];
                k = k % factorials[i - 1];

                sb.Append(nums[group]);
                nums.RemoveAt(group);
            }

            return sb.ToString();

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
