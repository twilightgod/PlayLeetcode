using System;

namespace _0250
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
        public int CountUnivalSubtrees(TreeNode root)
        {
            return CountUnival(root).Total;
        }

        private (bool IsUnival, int Total) CountUnival(TreeNode root)
        {
            if (root == null)
            {
                return (true, 0);
            }
            var leftResult = CountUnival(root.left);
            var rightResult = CountUnival(root.right);

            var total = leftResult.Total + rightResult.Total;
            var isUnival = leftResult.IsUnival && rightResult.IsUnival && (root.left == null || root.left.val == root.val) && (root.right == null || root.right.val == root.val);
            if (isUnival)
            {
                total++;
            }

            return (isUnival, total);
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
