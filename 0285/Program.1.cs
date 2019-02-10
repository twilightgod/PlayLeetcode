using System;

namespace _0285_1
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
            TreeNode answer = null;

            while (root != null)
            {
                if (p.val < root.val)
                {
                    answer = root;
                    root = root.left;
                }
                else
                {
                    root = root.right;
                }
            }

            return answer;
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
