using System;

namespace _0543
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
        public int DiameterOfBinaryTree(TreeNode root)
        {
            return GetMaxDepth(root).Diameter;
        }

        private (int MaxDepth, int Diameter) GetMaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return (0, 0);
            }

            var leftResult = GetMaxDepth(root.left);
            var rightResult = GetMaxDepth(root.right);

            var maxDepth = Math.Max(leftResult.MaxDepth, rightResult.MaxDepth) + 1;
            var diameter = Math.Max(Math.Max(leftResult.Diameter, rightResult.Diameter), leftResult.MaxDepth + rightResult.MaxDepth);

            return (maxDepth, diameter);
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
