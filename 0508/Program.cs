using System;
using System.Collections.Generic;
using System.Linq;

namespace _0508
{
    /**
 * Definition for a binary tree node. */
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public int[] FindFrequentTreeSum(TreeNode root)
        {
            if (root == null)
            {
                return new int[0];
            }
            var dict = new Dictionary<int, int>();
            GetSubTreeSum(root, dict);
            var max = dict.Values.Max();
            return dict.Where(x => x.Value == max).Select(x => x.Key).ToArray();
        }

        private int GetSubTreeSum(TreeNode root, Dictionary<int, int> dict)
        {
            if (root == null)
            {
                return 0;
            }

            var sum = root.val + GetSubTreeSum(root.left, dict) + GetSubTreeSum(root.right, dict);
            if (!dict.ContainsKey(sum))
            {
                dict.Add(sum, 0);
            }
            dict[sum]++;

            return sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
