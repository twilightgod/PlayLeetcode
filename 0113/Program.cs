using System;
using System.Collections.Generic;

namespace _0113
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
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            var ans = new List<IList<int>>();
            var path = new List<int>();
            DFS(root, sum, 0, path, ans);
            return ans;
        }

        private void DFS(TreeNode root, int target, int sum, List<int> path, List<IList<int>> ans)
        {
            if (root == null)
            {
                return;
            }

            path.Add(root.val);
            sum += root.val;
            if (root.left == null && root.right == null)
            {
                if (target == sum)
                {
                    ans.Add(new List<int>(path));
                }
            }
            else
            {
                DFS(root.left, target, sum, path, ans);
                DFS(root.right, target, sum, path, ans);
            }
            path.RemoveAt(path.Count - 1);
            // don't have to revert it here: sum -= root.val;
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
