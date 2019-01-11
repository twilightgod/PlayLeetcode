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
            var cnt = new List<int>();
            var sum = new List<long>();
            DFS(root, 0, sum, cnt);
            var ans = new List<double>();
            for (var i = 0; i < sum.Count; ++i)
            {
                ans.Add(sum[i] * 1.0 / cnt[i]);
            }
            return ans;
        }

        private void DFS(TreeNode root, int depth, List<long> sum, List<int> cnt)
        {
            if (root == null)
            {
                return;
            }

            if (depth == sum.Count)
            {
                sum.Add(0);
                cnt.Add(0);
            }
            sum[depth] += root.val;
            cnt[depth]++;
            
            DFS(root.left, depth + 1, sum, cnt);
            DFS(root.right, depth + 1, sum, cnt);
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
