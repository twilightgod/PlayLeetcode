using System;
using System.Collections.Generic;
using System.Linq;

namespace _0018
{
    class Program
    {
        public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        IList<IList<int>> result = new List<IList<int>>();
        var sorted = nums.ToList();
        sorted.Sort();
        if (sorted.Count < 4)
        {
            return result;
        }

        for (int i = 0; i < sorted.Count; )
        {
            for (int j = i + 1; j < sorted.Count; )
            {
                

                var l = j + 1;
                var r = sorted.Count - 1;

                while (l < r)
                {
                    var sum = sorted[l] + sorted[r] + sorted[i] + sorted[j];
                    if (sum == target)
                    {
                        result.Add(new List<int>(){sorted[i], sorted[j], sorted[l], sorted[r]} as IList<int>);
                    }

                    if (sum < target)
                    {
                        do
                        {
                            l++;
                        }
                        while(l + 1 <= r && sorted[l] == sorted[l - 1]);
                    }
                    else
                    {
                        do
                        {
                            r--;
                        }
                        while(l <= r - 1 && sorted[r] == sorted[r + 1]);
                    }
                }

                do
                {
                    j++;
                }
                while (j + 1 <= sorted.Count && sorted[j] == sorted[j - 1]);
            }
            
            do
            {
                i++;
            }
            while (i + 1 <= sorted.Count && sorted[i] == sorted[i - 1]);
        }

        return result;
    }
}
        static void Main(string[] args)
        {
            var b = new Solution().FourSum(new int[]{0, 0, 0, 0, 0, 0}, 0);
            var a = new Solution().FourSum(new int[]{1, 0, -1, 0, -2, 2}, 0);
            Console.WriteLine("Hello World!");
        }
    }
}
