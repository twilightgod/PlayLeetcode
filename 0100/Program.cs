using System;

namespace _0100
{
    /**
Definition for a binary tree node.*/
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
             
            return p?.val == q?.val && IsSameTree(p?.left, q?.left) && IsSameTree(p?.right, q?.right);
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
