using System;

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
            int n = 1000;
            var max = Enumerable.Repeat(-1, n).ToArray();
            var min = Enumerable.Repeat(Int32.MaxValue, n).ToArray();

            Traverse(root, 0, 0, min, max);

            int ans = 0;
            for (var i = 0; i < n; ++i)
            {
                ans = Math.Max(ans, max[i] - min[i] + 1);
            }

            return ans;
        }

        private void Traverse(TreeNode root, int depth, int nodenum, int[] min, int[] max)
        {
            if (nodenum == Int32.MaxValue)
            {
                return;
            }
            if (root == null)
            {
                return;
            }

            min[depth] = Math.Min(min[depth], nodenum);
            max[depth] = Math.Max(max[depth], nodenum);

            Traverse(root.left, depth + 1, nodenum * 2, min, max);
            Traverse(root.right, depth + 1, nodenum * 2 + 1, min, max);
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
