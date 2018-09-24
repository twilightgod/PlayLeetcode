using System;
using System.Collections.Generic;
using System.IO;

namespace _0241
{
    public class Solution
    {
        public IList<int> DiffWaysToCompute(string input)
        {
            var nums = new List<int>();
            var signs = new List<char>();

            var num = 0;
            foreach (var c in input)
            {
                if (Char.IsDigit(c))
                {
                    num = num * 10 + ((int)c - (int)'0');
                }
                else
                {
                    nums.Add(num);
                    num = 0;
                    signs.Add(c);
                }
            }
            // last num
            nums.Add(num);

            return DFS(nums, 0, nums.Count, signs);
        }

        // process nums[l, r), signs[l, r - 1)
        public List<int> DFS(List<int> nums, int l_num, int r_num, List<char> signs)
        {
            var answer = new List<int>();

            if (l_num == r_num - 1)
            {
                // only one number
                answer.Add(nums[l_num]);
                return answer; 
            }

            // loop thru possible split point, sign is 1 less than nums
            for (var i = l_num; i < r_num - 1; ++i)
            {
                var leftResult = DFS(nums, l_num, i + 1, signs);
                var rightResult = DFS(nums, i + 1, r_num, signs);

                foreach (var left in leftResult)
                {
                    foreach (var right in rightResult)
                    {
                        var result = 0;
                        switch (signs[i])
                        {
                            case '+':
                                result = left + right;
                                break;
                            case '-':
                                result = left - right;
                                break;
                            case '*':
                                result = left * right;
                                break;
                        }
                        answer.Add(result);
                    }
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
