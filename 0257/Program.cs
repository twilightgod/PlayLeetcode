using System;
using System.Collections.Generic;

namespace _0257
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
            var path = new List<int>();
            DFS(root, path, ans);
            return ans;
        }

        private void DFS(TreeNode root, List<int> path, List<string> ans)
        {
            if (root == null)
            {
                return;
            }

            path.Add(root.val);
            if (root.left == null && root.right == null)
            {
                ans.Add(String.Join("->", path));
            }
            DFS(root.left, path, ans);
            DFS(root.right, path, ans);
            path.RemoveAt(path.Count - 1);
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
