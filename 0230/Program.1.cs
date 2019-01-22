using System;
using System.Collections.Generic;

namespace _0230_1
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
        public int KthSmallest(TreeNode root, int k)
        {
            var kk = k;
            return DFS(root, ref k);
        }

        private int DFS(TreeNode root, ref int k)
        {
            if (root == null)
            {
                return -1;
            }

            var leftResult = DFS(root.left, ref k);
            if (k == 0)
            {
                return leftResult;
            }
            if (--k == 0)
            {
                return root.val;
            }
            var rightResult = DFS(root.right, ref k);
            if (k == 0)
            {
                return rightResult;
            }

            return -1;
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
