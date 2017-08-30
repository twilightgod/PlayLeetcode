using System;

namespace _0222
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
        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var LHeight = GetLeftHeight(root.left);
            var RHeight = GetLeftHeight(root.right);
            var sum = 0;

            // Left tree is full
            if (LHeight == RHeight)
            {
                sum += (1 << LHeight) - 1;
                sum += CountNodes(root.right);
            }
            // Right tree is full
            else
            {
                sum += (1 << RHeight) - 1;
                sum += CountNodes(root.left);
            }

            // plus one for root itself
            return sum + 1;
        }

        private int GetLeftHeight(TreeNode root)
        {
            var height = 0;

            while (root != null)
            {
                height++;
                root = root.left;
            }

            return height;
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
