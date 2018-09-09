using System;
using System.Collections.Generic;

namespace _0230
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
        public int KthSmallest(TreeNode root, int k)
        {
            var TreeSize = new Dictionary<TreeNode, int>();
            while (k > 0)
            {
                var leftCount = CountNodes(root.left, TreeSize);
                if (leftCount == k - 1)
                {
                    return root.val;
                }
                else if (k <= leftCount)
                {
                    root = root.left;
                }
                else
                {
                    k -= (leftCount + 1);
                    root = root.right;
                }
            }

            return -1;
        }

        private int CountNodes(TreeNode root, Dictionary<TreeNode, int> TreeSize)
        {
            if (root == null)
            {
                return 0;
            }

            if (TreeSize.ContainsKey(root))
            {
                return TreeSize[root];
            }
            
            var count = CountNodes(root.left, TreeSize) + CountNodes(root.right, TreeSize) + 1;
            TreeSize[root] = count;

            return count;
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
