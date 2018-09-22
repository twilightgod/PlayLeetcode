using System;
using System.Collections.Generic;

namespace _0652
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
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            // (val, left_tid, right_tid) -> tid
            // key is very sparse, so can be expressed by int
            var tidMapping = new Dictionary<long, int>();
            // tree id -> counter
            var counter = new Dictionary<int, int>();
            var answers = new List<TreeNode>();

            GetTid(root, tidMapping, counter, answers);

            return answers;
        }

        private int GetTid(TreeNode root, Dictionary<long, int> tidMapping, Dictionary<int, int> counter, List<TreeNode> answers)
        {
            if (root == null)
            {
                return 0;
            }

            var treeFeature = (((long)root.val) << 32) | (GetTid(root.left, tidMapping, counter, answers) << 16) | GetTid(root.right, tidMapping, counter, answers);
            if (!tidMapping.ContainsKey(treeFeature))
            {
                tidMapping[treeFeature] = tidMapping.Count + 1;
            }
            var tid = tidMapping[treeFeature];
            if (!counter.ContainsKey(tid))
            {
                counter[tid] = 0;
            }
            if (++counter[tid] == 2)
            {
                answers.Add(root);
            }

            return tid;
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
