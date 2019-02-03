using System;

namespace _0105
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
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var n = preorder.Length;
            return DFS(preorder, 0, n - 1, inorder, 0, n - 1);
        }

        private TreeNode DFS(int[] preorder, int pl, int pr, int[] inorder, int il, int ir)
        {
            if (pl > pr)
            {
                return null;
            }
            var root = new TreeNode(preorder[pl]);
            var pos = 0;
            for (pos = il; pos <= ir; ++pos)
            {
                if (inorder[pos] == root.val)
                {
                    break;
                }
            }
            var leftTreeSize = pos - il;
            root.left = DFS(preorder, pl + 1, pl + leftTreeSize, inorder, il, pos - 1);
            root.right = DFS(preorder, pl + leftTreeSize + 1, pr, inorder, pos + 1, ir);
            return root;
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
