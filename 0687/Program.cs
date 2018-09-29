using System;

namespace _0687
{
    /**
 * Definition for a binary tree node.
 */
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class Solution
    {
        public int LongestUnivaluePath(TreeNode root)
        {
            return DFS(root).bestMax;
        }

        private (int bestMax, int currentMax) DFS(TreeNode root)
        {
            if (root == null)
            {
                return (0, 0);
            }

            var leftResult = DFS(root.left);
            var rightResult = DFS(root.right);

            var leftMax = root.left?.val == root.val ? leftResult.currentMax + 1 : 0; 
            var rightMax = root.right?.val == root.val ? rightResult.currentMax + 1 : 0;
            var currentMax = Math.Max(leftMax, rightMax);
            var bestMax = Math.Max(Math.Max(leftResult.bestMax, rightResult.bestMax), leftMax + rightMax);

            return (bestMax, currentMax);
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
