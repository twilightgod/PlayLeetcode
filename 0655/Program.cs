using System;
using System.Collections.Generic;

namespace _0655
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
        public IList<IList<string>> PrintTree(TreeNode root)
        {
            var answer = new List<IList<string>>();
            if (root == null)
            {
                return answer;
            }
            var h = GetHeight(root);
            var w = (1 << h) - 1;

            // place holder
            for (var i = 0; i < h; ++i)
            {
                answer.Add(new List<string>());
                for (var j = 0; j < w; ++j)
                {
                    answer[i].Add("");
                }
            }

            Print(root, w >> 1, answer, 0, w >> 1);

            return answer;
        }

        private int GetHeight(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return Math.Max(GetHeight(root.left), GetHeight(root.right)) + 1;
        }

        private void Print(TreeNode root, int w, IList<IList<string>> answer, int row, int col)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine($"{w}, {row}, {col}, {root.val}");
            answer[row][col] = root.val.ToString();
            Print(root.left, w >> 1, answer, row + 1, col - 1 - (w >> 1));
            Print(root.right, w >> 1, answer, row + 1, col + 1 + (w >> 1));
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
