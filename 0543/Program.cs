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
            return DFS(root).maxDiameter;
        }

        private (int depth, int maxDiameter) DFS(TreeNode root)
        {
            if (root == null)
            {
                return (0, 0);
            }

            var leftResult = DFS(root.left);
            var rightResult = DFS(root.right);

            var depth = Math.Max(leftResult.depth, rightResult.depth) + 1;
            var maxDiameter = Math.Max(Math.Max(leftResult.maxDiameter, rightResult.maxDiameter), leftResult.depth + rightResult.depth);

            return (depth, maxDiameter);
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
