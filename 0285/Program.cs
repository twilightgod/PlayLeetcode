using System;

namespace _0285
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
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            return Traverse(root, null, p).answer;
        }

        private (TreeNode leftMostNode, TreeNode answer) Traverse(TreeNode root, TreeNode pre, TreeNode p)
        {
            if (root == null)
            {
                return (null, null);
            }

            var leftResult = Traverse(root.left, root, p);
            // pass current root's pre to call of right subtree
            var rightResult = Traverse(root.right, pre, p);

            if (leftResult.answer != null)
            {
                return (null, leftResult.answer);
            }
            if (rightResult.answer != null)
            {
                return (null, rightResult.answer);
            }

            if (root == p)
            {
                if (root.right != null)
                {
                    return (null, rightResult.leftMostNode);
                }
                else
                {
                    return (null, pre);
                }
            }
            else
            {
                return (leftResult.leftMostNode ?? root, null);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // [3, 1, 4, null, 2], 2
            Console.WriteLine("Hello World!");
        }
    }
}
