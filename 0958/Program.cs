using System;
using System.Collections.Generic;
using System.Linq;

namespace _0958
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
        public bool IsCompleteTree(TreeNode root)
        {
            var idSet = new HashSet<int>();
            DFS(root, 1, idSet);
            return idSet.Max() == idSet.Count;
        }

        private void DFS(TreeNode root, int id, HashSet<int> idSet)
        {
            if (root == null)
            {
                return;
            }
            idSet.Add(id);
            DFS(root.left, id << 1, idSet);
            DFS(root.right, (id << 1) + 1, idSet);
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
