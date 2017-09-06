using System;

namespace _0404
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
        public int SumOfLeftLeaves(TreeNode root)
        {
            return DFS(root, false);
        }

        private int DFS(TreeNode root, bool left)
        {
            if (root == null)
            {
                return 0;
            }

            var sum = 0;

            if (root.left == null && root.right == null && left)
            {
                sum += root.val;
            }

            sum += DFS(root.left, true);
            sum += DFS(root.right, false);

            return sum;
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
