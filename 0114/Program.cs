using System;

namespace _0114
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
        public void Flatten(TreeNode root)
        {
            FlatternTree(root);
        }

        // call for left subtree
        // insert [left, last node of left subtree] to right
        // call for right subtree 
        // return last node        
        private TreeNode FlatternTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            // leaf
            if (root.left == null && root.right == null)
            {
                return root;
            }

            var lastNode = root;

            if (root.left != null)
            {
                var lastNodeOfLeft = FlatternTree(root.left);
                lastNodeOfLeft.right = root.right;
                root.right = root.left;
                root.left = null;
                lastNode = lastNodeOfLeft;
            }

            if (lastNode.right != null)
            {
                lastNode = FlatternTree(lastNode.right);
            }

            return lastNode;
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
