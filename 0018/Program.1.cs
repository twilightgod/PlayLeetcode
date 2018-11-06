using System;
using System.Collections.Generic;
using System.Linq;

namespace _0018_1
{
    public class Solution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            var resultSet = new HashSet<(int, int, int, int)>();
            var seen = new HashSet<int>();
            var n = nums.Length;
            for (var i = 0; i < n; ++i)
            {
                for (var j = i + 1; j < n; ++j)
                {
                    for (var k = j + 1; k < n; ++k)
                    {
                        var left = target - nums[i] - nums[j] - nums[k];
                        if (seen.Contains(left))
                        {
                            var buf = new List<int>();
                            buf.Add(nums[i]);
                            buf.Add(nums[j]);
                            buf.Add(nums[k]);
                            buf.Add(left);
                            buf.Sort();
                            resultSet.Add((buf[0], buf[1], buf[2], buf[3]));
                        }
                    }
                }
                seen.Add(nums[i]);
            }

            foreach (var r in resultSet)
            {
                var t = new List<int>();
                t.Add(r.Item1);
                t.Add(r.Item2);
                t.Add(r.Item3);
                t.Add(r.Item4);
                result.Add(t);
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var b = new Solution().FourSum(new int[] { 0, 0, 0, 0, 0, 0 }, 0);
            var a = new Solution().FourSum(new int[] { 1, 0, -1, 0, -2, 2 }, 0);
            Console.WriteLine("Hello World!");
        }
    }
}
