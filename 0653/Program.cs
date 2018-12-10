using System;
using System.Collections.Generic;

namespace _0653
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
        public bool FindTarget(TreeNode root, int k)
        {
            var valSet  = new HashSet<int>();
            return DFS(root, k, valSet);
        }

        private bool DFS(TreeNode root, int k, HashSet<int> valSet)
        {
            if (root == null)
            {
                return false;
            }
            if (valSet.Contains(k - root.val))
            {
                return true;
            }
            valSet.Add(root.val);
            return DFS(root.left, k, valSet) || DFS(root.right, k, valSet);
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
