using System;

namespace _0951
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
        public bool FlipEquiv(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
            {
                return true;
            }
            if (root1 == null || root2 == null || root1.val != root2.val)
            {
                return false;
            }
            return FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right)
            || FlipEquiv(root1.left, root2.right) && FlipEquiv(root1.right, root2.left);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            [0,3,1,null,null,null,2]
[0,3,1,2]
 */
            Console.WriteLine("Hello World!");
        }
    }
}
