using System;

namespace _0236
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
            return FindNode(root, p, q);
        }

        private TreeNode FindNode(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return null;
            }

            // if current node is p or q, we have 2 cases:
            // 1. other node is in subtree of root, root is LCA
            // 2. other node is not in subtree of root, return root as an indicator of finding, LCA will be adjusted in following code
            if (root == p || root == q)
            {
                return root;
            }

            var LeftResult = FindNode(root.left, p, q);
            var RightResult = FindNode(root.right, p, q);
            
            if (LeftResult != null && RightResult != null)
            {
                // p and q in left and right subtrees, root is LCA
                return root;
            }

            if (LeftResult != null)
            {
                // pass result from subtree to upper level
                return LeftResult;
            }

            if (RightResult != null)
            {
                // pass result from subtree to upper level
                return RightResult;
            }

            // not found
            return null;
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
