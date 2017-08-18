using System;

namespace _0124
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
        public int best;

        public int MaxPathSum(TreeNode root)
        {
            best = Int32.MinValue;
            _MaxPathSum(root);
            return best;
        }

        public int _MaxPathSum(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var sumLeft = _MaxPathSum(root.left);
            var sumRight = _MaxPathSum(root.right);

            var sum = sumLeft + sumRight + root.val;

            best = Math.Max(best, sum);

            return Math.Max(0, Math.Max(sumLeft, sumRight) + root.val);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            Console.WriteLine(new Solution().MaxPathSum(root));
        }
    }
}
