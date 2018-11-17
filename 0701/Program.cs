using System;

namespace _0701
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
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
            {
                return new TreeNode(val);
            }
            Insert(root, val);
            return root;
        }

        private void Insert(TreeNode root, int val)
        {
            if (val < root.val)
            {
                if (root.left == null)
                {
                    root.left = new TreeNode(val);
                }
                else
                {
                    Insert(root.left, val);
                }
            }
            else
            {
                if (root.right == null)
                {
                    root.right = new TreeNode(val);
                }
                else
                {
                    Insert(root.right, val);
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
