using System;

namespace _0111
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
        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                return 1;
            }
            var depth = Int32.MaxValue;
            if (root.left != null)
            {
                depth = MinDepth(root.left) + 1;
            }
            if (root.right != null)
            {
                depth = Math.Min(depth, MinDepth(root.right) + 1);
            }

            return depth;
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
