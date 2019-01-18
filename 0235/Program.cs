using System;

namespace _0235
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
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null)
            {
                return null;
            }

            var maxVal = Math.Max(p.val, q.val);
            var minVal = Math.Min(p.val, q.val);

            while (true)
            {
                if (root.val < minVal)
                {
                    root = root.right;
                }
                else if (root.val > maxVal)
                {
                    root = root.left;
                }
                else
                {
                    return root;
                }
            }
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
