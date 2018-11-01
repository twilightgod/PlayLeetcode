using System;

namespace _0298
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

        private (int answer, int len) DFS(TreeNode root)
        {
            if (root == null)
            {
                return (0, 0);
            }
            var leftResult = DFS(root.left);
            var rightResult = DFS(root.right);
            var answer = Math.Max(leftResult.answer, rightResult.answer);
            var len = 1;
            if (root.val == root.left?.val - 1)
            {
                len = leftResult.len + 1;
            }
            if (root.val == root.right?.val - 1)
            {
                len = Math.Max(len, rightResult.len + 1);
            }
            answer = Math.Max(answer, len);
            return (answer, len);
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
