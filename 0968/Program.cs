using System;
using System.Collections.Generic;

namespace _0968
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
        public int MinCameraCover(TreeNode root)
        {
            var covered = new HashSet<TreeNode>();
            covered.Add(null);
            return DFS(root, null, covered);
        }

        private int DFS(TreeNode root, TreeNode parent, HashSet<TreeNode> covered)
        {
            if (root == null)
            {
                return 0;
            }

            var answer = DFS(root.left, root, covered) + DFS(root.right, root, covered);
            if (!covered.Contains(root) && parent == null || !covered.Contains(root.left) || !covered.Contains(root.right))
            {
                covered.Add(parent);
                covered.Add(root);
                covered.Add(root.left);
                covered.Add(root.right);
                answer++;
            }

            return answer;
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
