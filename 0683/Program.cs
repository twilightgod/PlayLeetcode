using System;
using System.Collections.Generic;
using System.Linq;

namespace _0683
{
    public class Solution
    {
        public int KEmptySlots(int[] flowers, int k)
        {
            if (k + 2 > flowers.Length)
            {
                return -1;
            }

            // conver to slot view
            var slot = new int[flowers.Length];
            for (var i = 1; i < flowers.Length; ++i)
            {
                slot[flowers[i] - 1] = i + 1;
            }

            var ans = -1;
            var l = 0;
            var r = l + k + 1;
            for (var i = l + 1; r < flowers.Length; ++i)
            {
                // <= is for i == r case
                if (slot[i] < slot[l] || slot[i] <= slot[r])
                {
                    if (i == r)
                    {
                        var candidate = Math.Max(slot[l], slot[i]);
                        ans = ans == -1 ? candidate : Math.Min(candidate, ans);                    
                    }
                    
                    // if we found i between (l, r) range that slot[i] is smaller than both slot[l] and slot[r]
                    // that means [l, r] is not an answer candidate
                    // we can move l to i directly, since all slots in (l, i - 1) range are larger than slot[i]
                    // it's impossible to find a candidate with new l value in (l, i - 1) with k + 2 length, it will encounter slot[i]
                    l = i; // i will be l + 1 in next iteration
                    r = l + k + 1;
                }
            }

            return ans;
        }

        public int KEmptySlots_Heap(int[] flowers, int k)
        {
            if (k + 2 > flowers.Length)
            {
                return -1;
            }

            // conver to slot view
            var slot = new int[flowers.Length];
            for (var i = 1; i < flowers.Length; ++i)
            {
                slot[flowers[i] - 1] = i + 1;
            }

            var ans = -1;
            var minHeap = new SortedSet<int>();

            for (var i = 0; i <= flowers.Length - k - 2; ++i)
            {
                // insert bloom time into heap
                if (i == 0)
                {
                    for (var j = 0; j < k + 1; ++j)
                    {
                        minHeap.Add(slot[j]);
                    }
                }
                minHeap.Add(slot[i + k + 1]);

                // find top 2 smallest
                var min1 = minHeap.Min;
                minHeap.Remove(min1);

                var min2 = minHeap.Min;

                // add min1 back to heap
                minHeap.Add(min1);

                var dayMin = Math.Min(slot[i], slot[i + k + 1]);
                var dayMax = Math.Max(slot[i], slot[i + k + 1]);

                if (dayMin == min1 && dayMax == min2)
                {
                    // if top 2 smallest is ith and (i + k + 1)th slots, that means all flowers between them will bloom later
                    ans = ans == -1 ? dayMax : Math.Min(ans, dayMax);
                }
                minHeap.Remove(slot[i]);
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
