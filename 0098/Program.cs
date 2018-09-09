using System;

namespace _0098
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
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBSTNode(root, Int64.MinValue, Int64.MaxValue);
        }

        private bool IsValidBSTNode(TreeNode root, long minValue, long maxValue)
        {
            if (root == null)
            {
                return true;
            }

            if (root.val <= minValue || root.val >= maxValue)
            {
                return false;
            }

            return IsValidBSTNode(root.left, minValue, root.val) && IsValidBSTNode(root.right, root.val, maxValue);
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
