using System;
using System.Collections.Generic;

namespace _0099
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
        public void RecoverTree(TreeNode root)
        {
            var orders = new List<TreeNode>();
            orders.Add(new TreeNode(Int32.MinValue));
            InOrderTraverse(root, orders);
            orders.Add(new TreeNode(Int32.MaxValue));

            TreeNode n1 = null;
            TreeNode n2 = null;

            for (var i = 1; i < orders.Count - 1; ++i)
            {
                if (n1 == null && orders[i].val > orders[i + 1].val)
                {
                    n1 = orders[i];
                }
                else if (n1 != null && orders[i].val < orders[i - 1].val)
                {
                    n2 = orders[i];
                }
            }

            var t = n1.val;
            n1.val = n2.val;
            n2.val = t;
        }

        private void InOrderTraverse(TreeNode root, List<TreeNode> orders)
        {
            if (root == null)
            {
                return;
            }

            InOrderTraverse(root.left, orders);
            orders.Add(root);
            InOrderTraverse(root.right, orders);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(3);
            var node3 = new TreeNode(2);
            node1.left = node2;
            node2.right = node3;
            new Solution().RecoverTree(node1);
            Console.WriteLine("Hello World!");
        }
    }
}
