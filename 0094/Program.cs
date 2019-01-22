using System;
using System.Collections.Generic;

namespace _0094
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
        public IList<int> InorderTraversal(TreeNode root)
        {
            var nodeStack = new Stack<TreeNode>();
            var inorderList = new List<int>();

            PushLeftNodes(root, nodeStack);
            while (nodeStack.Count > 0)
            {
                var node = nodeStack.Pop();
                inorderList.Add(node.val);
                PushLeftNodes(node.right, nodeStack);
            }

            return inorderList;
        }
        
        private void PushLeftNodes(TreeNode root, Stack<TreeNode> nodeStack)
        {
            while (root != null)
            {
                nodeStack.Push(root);
                root = root.left;
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
