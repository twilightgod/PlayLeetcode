using System;

namespace _0298_1
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
        public int LongestConsecutive(TreeNode root)
        {
            return DFS(root, null, 0);
        }

        private int DFS(TreeNode root, TreeNode parent, int len)
        {
            if (root == null)
            {
                return 0;
            }
            len = parent != null && parent.val + 1 == root.val ? len + 1 : 1;
            return Math.Max(len, Math.Max(DFS(root.left, root, len), DFS(root.right, root, len)));
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
