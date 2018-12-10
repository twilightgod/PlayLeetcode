using System;
using System.Collections.Generic;
using System.Linq;

namespace _0703
{
    public class KthLargest
    {
        private SortedDictionary<int, int> bst = new SortedDictionary<int, int>();
        private int k = 0;
        private int size = 0;

        public KthLargest(int k, int[] nums)
        {
            this.k = k;
            foreach (var val in nums)
            {
                InsertBST(val);
            }
        }

        public int Add(int val)
        {
            return InsertBST(val);
        }

        private int InsertBST(int val)
        {
            if (size < k)
            {
                if (!bst.ContainsKey(val))
                {
                    bst.Add(val, 0);
                }
                bst[val]++;
                size++;
            }
            else if (val > bst.Keys.First())
            {
                if (!bst.ContainsKey(val))
                {
                    bst.Add(val, 0);
                }
                bst[val]++;
                var min = bst.Keys.First();
                if (--bst[min] == 0)
                {
                    bst.Remove(min);
                }
            }
            return bst.Keys.First();
        }
    }

    /**
     * Your KthLargest object will be instantiated and called as such:
     * KthLargest obj = new KthLargest(k, nums);
     * int param_1 = obj.Add(val);
     */

    class Program
    {
        static void Main(string[] args)
        {
            var s = new KthLargest(3, new int[]{4, 5, 8, 2});
            s.Add(3);
            s.Add(5);
            s.Add(10);
            s.Add(9);
            s.Add(4);
            Console.WriteLine("Hello World!");
        }
    }
}
