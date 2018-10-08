using System;
using System.Collections.Generic;
using System.Linq;

namespace _0015
{
    class Program
    {
        public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        var cnt = new Dictionary<int, int>();
        var nums_sorted = new List<int>();
        foreach (var num in nums)
        {
            if (cnt.ContainsKey(num))
            {
                cnt[num]++;
            }
            else
            {
                cnt[num] = 1;
            }
            if (cnt[num] <= 3)
            {
                nums_sorted.Add(num);
            }
        }
        nums_sorted.Sort();
        var result = new HashSet<Tuple<int, int, int>>();

        var lookup = new HashSet<int>();
        for (int i = 0; i < nums_sorted.Count; ++i)
        {
            var a = nums_sorted[i];
            lookup.Clear();
            for (int j = i + 1; j < nums_sorted.Count; ++j)
            {
                var b = nums_sorted[j];
                var c = - (a + b);
                if (lookup.Contains(c))
                {
                    result.Add(Tuple.Create<int, int, int>(a, b, c));
                    //break;
                }
                else
                {
                    lookup.Add(b);
                }
            }
        }

        return result.Select(x => (new List<int>(){x.Item1, x.Item2, x.Item3}) as IList<int>).ToList() as IList<IList<int>>;
    }
}
        static void Main(string[] args)
        {
            var a = new Solution().ThreeSum(new int[]{-1, 0, 1, 2, -1, -4});
            Console.WriteLine("");
        }
    }
}
