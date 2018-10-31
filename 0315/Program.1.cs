using System;
using System.Collections.Generic;
using System.Linq;

namespace _0315_1
{
    // start with 0
    public class BIT
    {
        int[] data = null;
        int capacity;
        
        public BIT(int capacity)
        {
            this.capacity = capacity;
            data = new int[capacity + 1];
        }

        public void Update(int x, int delta)
        {
            while (x <= capacity)
            {
                data[x] += delta;
                x += LowBit(x);
            }
        }

        public int Query(int x)
        {
            var sum = 0;
            while (x > 0)
            {
                sum += data[x];
                x -= LowBit(x);
            }
            return sum;
        }

        private int LowBit(int x)
        {
            return x & (-x);
        }
    }

    public class Solution
    {
        public IList<int> CountSmaller(int[] nums)
        {
            var numMap = new Dictionary<int, int>();
            var numSet = new HashSet<int>();
            var answers = new List<int>();
            var n = nums.Length;
            if (n == 0)
            {
                return answers; 
            }
            // map num to smaller range
            foreach (var num in nums)
            {
                numSet.Add(num);
            }
            var numList = new List<int>(numSet);
            numList.Sort();
            var idx = 1;
            foreach (var num in numList)
            {
                numMap[num] = idx++;
            }
            var bit = new BIT(n);
            for (var i = n - 1; i >= 0; --i)
            {
                answers.Add(bit.Query(numMap[nums[i]] - 1));
                bit.Update(numMap[nums[i]], 1);
            }
            answers.Reverse();
            return answers;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //new Solution().CountSmaller(new int[]{5, 2, 6, 1});
            Console.WriteLine("Hello World!");
        }
    }
}
