using System;
using System.Collections.Generic;

namespace _0102
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
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var answers = new List<IList<int>>();
            DFS(root, 0, answers);
            return answers;
        }

        private void DFS(TreeNode root, int depth, List<IList<int>> answers)
        {
            if (root == null)
            {
                return;
            }
            if (depth == answers.Count)
            {
                answers.Add(new List<int>());
            }
            answers[depth].Add(root.val);
            DFS(root.left, depth + 1, answers);
            DFS(root.right, depth + 1, answers);
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
