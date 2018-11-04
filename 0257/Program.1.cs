using System;
using System.Collections.Generic;

namespace _0257_1
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
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var ans = new List<string>();
            DFS(root, String.Empty, ans);
            return ans;
        }

        // return true means it's leaf node
        private bool DFS(TreeNode root, string path, List<string> ans)
        {
            if (root == null)
            {
                return true;
            }
            if (!String.IsNullOrEmpty(path))
            {
                path += "->";
            }
            path += root.val.ToString();
            var isLeftLeaf = DFS(root.left, path, ans);
            var isRightLeaf = DFS(root.right, path, ans);
            if (isLeftLeaf && isRightLeaf)
            {
                ans.Add(path);
            }
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
