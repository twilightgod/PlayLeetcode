using System;
using System.Collections.Generic;

namespace _0337
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
        public int Rob(TreeNode root)
        {
            // f[i] means the max sum for subtree whose root is i
            var f = new Dictionary<TreeNode, int>();
            
            return DP(root, f);
        }

        private int DP(TreeNode root, Dictionary<TreeNode, int> f)
        {
            if (root == null)
            {
                return 0;
            }

            if (!f.ContainsKey(root))
            {
                f[root] = Math.Max(
                    // rob i
                    root.val + DP(root.left?.left, f) + DP(root.left?.right, f) + DP(root.right?.left, f) + DP(root.right?.right, f),
                    // don't rob i
                    DP(root.left, f) + DP(root.right, f)
                    );

            }

            return f[root];
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
