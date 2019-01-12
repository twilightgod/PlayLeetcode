using System;
using System.Collections.Generic;

namespace _0437
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
        public int PathSum(TreeNode root, int target)
        {
            // key: sum  value: # of ways
            var ways = new Dictionary<int, int>();
            ways[0] = 1;
            return DFS(root, target, 0, ways);
        }

        private int DFS(TreeNode root, int target, int sum, Dictionary<int, int> ways)
        {
            if (root == null)
            {
                return 0;
            }

            sum += root.val;
            var ans = ways.GetValueOrDefault(sum - target);
            ways[sum] = ways.GetValueOrDefault(sum) + 1;

            ans += DFS(root.left, target, sum, ways) + DFS(root.right, target, sum, ways);

            ways[sum]--;
            return ans;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n1 = new TreeNode(1);
            var n2 = new TreeNode(2);
            var n3 = new TreeNode(3);
            var n4 = new TreeNode(4);
            var n5 = new TreeNode(5);
            n1.right = n2;
            n2.right = n3;
            n3.right = n4;
            n4.right = n5;

            Console.WriteLine(new Solution().PathSum(n1, 3));
        }
    }
}
