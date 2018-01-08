using System;
using System.Collections.Generic;

namespace _0128
{
    public class Solution
    {
        public int LongestConsecutive(int[] nums)
        {
            var ans = 0;
            // Left bound starts with key
            var LenMapLeft = new Dictionary<int, int>();
            // Right bound ends with key
            var LenMapRight = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (LenMapLeft.ContainsKey(num) || LenMapRight.ContainsKey(num))
                {
                    continue;
                }
                var NewLen = 1;
                var LeftBound = num;
                var RightBound = num;

                if (LenMapRight.ContainsKey(num - 1))
                {
                    NewLen += LenMapRight[num - 1];
                    LeftBound = num - 1 - LenMapRight[num - 1] + 1;
                    LenMapRight.Remove(num - 1);
                    LenMapLeft.Remove(LeftBound);
                }

                if (LenMapLeft.ContainsKey(num + 1))
                {
                    NewLen += LenMapLeft[num + 1];
                    RightBound = num + 1 + LenMapLeft[num + 1] - 1;
                    LenMapLeft.Remove(num + 1);
                    LenMapRight.Remove(RightBound);
                }

                LenMapLeft.Add(LeftBound, NewLen);
                LenMapRight.Add(RightBound, NewLen);

                ans = Math.Max(ans, NewLen);
            }

            return ans;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().LongestConsecutive(new int[]{1,2,0,1});
            new Solution().LongestConsecutive(new int[]{100,4,200,1,3,2});
            Console.WriteLine("Hello World!");
        }
    }
}
