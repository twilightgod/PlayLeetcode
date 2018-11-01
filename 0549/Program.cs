using System;

namespace _0549
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
        public int LongestConsecutive(TreeNode root)
        {
            return DFS(root).answer;
        }

        private (int answer, int len1, int len2) DFS(TreeNode root)
        {
            if (root == null)
            {
                return (0, 0, 0);
            }
            var leftR = DFS(root.left);
            var rightR = DFS(root.right);
            // len1 means root is 1 larger than child
            var lLen1 = root.val + 1 == root.left?.val ? leftR.len1 : 0;
            var rLen1 = root.val + 1 == root.right?.val ? rightR.len1 : 0;
            // len2 means root is 1 smaller than child
            var lLen2 = root.val - 1 == root.left?.val ? leftR.len2 : 0;
            var rLen2 = root.val - 1 == root.right?.val ? rightR.len2 : 0;

            var answer = Math.Max(leftR.answer, Math.Max(rightR.answer, Math.Max(lLen1 + rLen2 + 1, lLen2 + rLen1 + 1)));
            var len1 = Math.Max(lLen1, rLen1) + 1;
            var len2 = Math.Max(lLen2, rLen2) + 1;

            return (answer, len1, len2);
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
