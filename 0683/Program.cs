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

            // convert to slot view
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
                // i meets r means we find out an answer                
                if (i == r)
                {
                    var candidate = Math.Max(slot[l], slot[r]);
                    ans = ans == -1 ? candidate : Math.Min(candidate, ans);                    
                }

                // if i violates conditions or i meets r, move l and r
                if (slot[i] < slot[l] || slot[i] < slot[r] || i == r)
                {
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
