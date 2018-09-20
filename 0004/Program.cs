using System;

namespace _0004
{
    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var n1 = nums1.Length;
            var n2 = nums2.Length;

            if (n1 > n2)
            {
                // make sure nums1 is not longer than nums2, so that r boundry is n1 to avoid negtive index in nums2
                return FindMedianSortedArrays(nums2, nums1);
            }

            var n3 = n1 + n2;

            var l = 0;
            var r = n1 + 1;

            while (l < r)
            {
                // m1 means take m1 elements from nums1
                var m1 = l + (r - l) / 2;
                // n3 + 1 here to unify odd and even, m2 means take m2 elements from nums2
                var m2 = (n3 + 1) / 2 - m1;
                // use m1 and m2 as boundry to devide nums1 and nums2 into left and right parts
                // these 4 elements will be at the middle of merged array
                var nums1_left = m1 == 0 ? Int32.MinValue : nums1[m1 - 1];
                var nums1_right = m2 == 0 ? Int32.MinValue : nums2[m2 - 1];
                var nums2_left = m1 == n1 ? Int32.MaxValue : nums1[m1];
                var nums2_right = m2 == n2 ? Int32.MaxValue : nums2[m2];
                // get the two elements near the boundry
                var maxBoundrym1_1 = Math.Max(nums1_left, nums1_right);
                var minBoundrym1 = Math.Min(nums2_left, nums2_right);

                // meet condition, = is for identical elements
                if (maxBoundrym1_1 <= minBoundrym1)
                {
                    if (n3 % 2 == 1)
                    {
                        // for odd, return max of left boundry
                        return maxBoundrym1_1;
                    }
                    else
                    {
                        // for even, return avg of left and right boundry
                        return (maxBoundrym1_1 + minBoundrym1) / 2.0;
                    }
                }
                // if left boundry from nums1 is bigger than right boundry from nums2, it means we take too many elements from nums1, need to search left half
                if (nums1_left > nums2_right)
                {
                    r = m1;
                }
                else
                {
                    l = m1 + 1;
                }
            }

            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().FindMedianSortedArrays(new int[]{1}, new int[]{1});
            //new Solution().FindMedianSortedArrays(new int[]{1, 4, 7}, new int[]{2, 5, 6, 8});
            Console.WriteLine("Hello World!");
        }
    }
}
