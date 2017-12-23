using System;

namespace _0101
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
        public bool IsSymmetric(TreeNode root)
        {
            return IsSymmetric(root, root);
        }

        public bool IsSymmetric(TreeNode node1, TreeNode node2)
        {
            if (node1 == null && node2 == null)
            {
                return true;
            }

            return node1?.val == node2?.val && IsSymmetric(node1?.left, node2?.right) && IsSymmetric(node1?.right, node2?.left);
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
