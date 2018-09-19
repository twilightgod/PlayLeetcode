using System;

namespace _0270
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
        public int ClosestValue(TreeNode root, double target)
        {
            return (int)ClosestValueInternal(root, target);
        }

        public long ClosestValueInternal(TreeNode root, double target)
        {
            if (root == null)
            {
                return Int64.MaxValue;
            }

            var childResult = Int64.MaxValue;
            if (target < root.val)
            {
                childResult = ClosestValueInternal(root.left, target);
            }
            else
            {
                childResult = ClosestValueInternal(root.right, target);
            }

            return Math.Abs(root.val - target) < Math.Abs(childResult - target) ? root.val : childResult;
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
