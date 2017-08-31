using System;

namespace _0112
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
        public bool HasPathSum(TreeNode root, int sum)
        {
            return DFS(root, sum, 0);
        }

        private bool DFS(TreeNode root, int target, int sum)
        {
            if (root == null)
            {
                return false;
            }

            sum += root.val;
            if (root.left == null && root.right == null)
            {
                if (target == sum)
                {
                    return true;
                }
            }
            else
            {
                return DFS(root.left, target, sum) || DFS(root.right, target, sum);
            }
            // don't have to revert it here: sum -= root.val;

            return false;
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
