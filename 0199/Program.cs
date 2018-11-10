using System;
using System.Collections.Generic;

namespace _0199
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
        public IList<int> RightSideView(TreeNode root)
        {
            var answer = new List<int>();
            if (root == null)
            {
                return answer;
            }
            var q = new Queue<(TreeNode root, int depth)>();
            q.Enqueue((root, 1));
            while (q.Count > 0)
            {
                var (node, depth) = q.Dequeue();
                if (depth > answer.Count)
                {
                    answer.Add(node.val);
                }
                if (node.right != null)
                {
                    q.Enqueue((node.right, depth + 1));
                }
                if (node.left != null)
                {
                    q.Enqueue((node.left, depth + 1));
                }
            }
            return answer;
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
