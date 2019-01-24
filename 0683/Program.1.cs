using System;
using System.Collections.Generic;
using System.Linq;

namespace _0683_1
{
    public class Solution
    {
        //BST
        public int KEmptySlots(int[] flowers, int k)
        {
            if (k + 2 > flowers.Length)
            {
                return -1;
            }

            // convert to slot view
            var slot = new int[flowers.Length];
            for (var i = 1; i < flowers.Length; ++i)
            {
                slot[flowers[i] - 1] = i + 1;
            }

            var ans = -1;
            var bst = new SortedSet<int>();

            for (var i = 0; i <= flowers.Length - k - 2; ++i)
            {
                // insert bloom time into bst
                if (i == 0)
                {
                    for (var j = 0; j < k + 1; ++j)
                    {
                        bst.Add(slot[j]);
                    }
                }
                bst.Add(slot[i + k + 1]);

                // find top 2 smallest
                var min1 = bst.ElementAt(0);
                var min2 = bst.ElementAt(1);

                var dayMin = Math.Min(slot[i], slot[i + k + 1]);
                var dayMax = Math.Max(slot[i], slot[i + k + 1]);

                if (dayMin == min1 && dayMax == min2)
                {
                    // if top 2 smallest is ith and (i + k + 1)th slots, that means all flowers between them will bloom later
                    ans = ans == -1 ? dayMax : Math.Min(ans, dayMax);
                }

                // expire
                bst.Remove(slot[i]);
            }

            return ans;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().KEmptySlots(new int[]{1,3,2}, 1);
            new Solution().KEmptySlots(new int[]{3,9,2,8,1,6,10,5,4,7}, 1);
            Console.WriteLine("Hello World!");
        }
    }
}
