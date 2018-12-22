using System;
using System.Collections.Generic;
using System.Linq;

namespace _0103
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
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var answers = new List<IList<int>>();
            DFS(root, 0, answers);
            for (var i = 0; i < answers.Count; ++i)
            {
                if (i % 2 == 1)
                {
                    answers[i] = answers[i].Reverse().ToList();
                }
            }
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
