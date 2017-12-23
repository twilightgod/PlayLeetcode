using System;

namespace _0104
{
    /**
 * Definition for a binary tree node.*/
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public int MaxDepth(TreeNode root)
        {
            return ReturnMaxDepth(root, 0);
        }

        private int ReturnMaxDepth(TreeNode root, int depth)
        {
            if (root == null)
            {
                return depth;
            }

            return Math.Max(ReturnMaxDepth(root.left, depth + 1), ReturnMaxDepth(root.right, depth + 1));
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
