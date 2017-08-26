using System;

namespace _0617
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
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (!(t1 == null && t2 == null))
            {
                var node = new TreeNode((t1?.val ?? 0) + (t2?.val ?? 0));
                node.left = MergeTrees(t1?.left, t2?.left);
                node.right = MergeTrees(t1?.right, t2?.right);
                return node;
            }
            else
            {
                return null;
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
