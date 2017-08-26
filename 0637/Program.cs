using System;
using System.Collections.Generic;

namespace _0637
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
        public IList<double> AverageOfLevels(TreeNode root)
        {
            var cnt = new SortedDictionary<int, int>();
            var sum = new SortedDictionary<int, long>();
            Traverse(root, 0, sum, cnt);
            var ans = new List<double>();
            foreach (var key in sum.Keys)
            {
                ans.Add(sum[key] * 1.0 / cnt[key]);
            }
            return ans;
        }

        private void Traverse(TreeNode root, int depth, SortedDictionary<int, long> sum, SortedDictionary<int, int> cnt)
        {
            if (root == null)
            {
                return;
            }

            if (sum.ContainsKey(depth))
            {
                sum[depth] += root.val;
            }
            else
            {
                sum[depth] = root.val;
            }

            if (cnt.ContainsKey(depth))
            {
                cnt[depth]++;
            }
            else
            {
                cnt[depth] = 1;
            }
            Traverse(root.left, depth + 1, sum, cnt);
            Traverse(root.right, depth + 1, sum, cnt);
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
