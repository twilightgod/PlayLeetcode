using System;
using System.Collections.Generic;

namespace _0662
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
        public int WidthOfBinaryTree(TreeNode root)
        {
            var max = new List<long>();
            var min = new List<long>();

            Traverse(root, 0, 0, min, max);

            long ans = 0;
            // potentialy overflow, this solution is not perfect
            for (var i = 0; i < max.Count; ++i)
            {
                ans = Math.Max(ans, max[i] - min[i] + 1);
            }

            return (int)ans;
        }

        private void Traverse(TreeNode root, int depth, int nodenum, List<long> min, List<long> max)
        {
            if (root == null)
            {
                return;
            }

            if (min.Count == depth)
            {
                min.Add(Int64.MaxValue);
                max.Add(Int64.MinValue);
            }
            min[depth] = Math.Min(min[depth], nodenum);
            max[depth] = Math.Max(max[depth], nodenum);

            Traverse(root.left, depth + 1, nodenum << 1, min, max);
            Traverse(root.right, depth + 1, (nodenum << 1) + 1, min, max);
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
