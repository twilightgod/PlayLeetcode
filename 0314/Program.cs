using System;
using System.Collections.Generic;
using System.Linq;

namespace _0314
{
    /**
 * Definition for a binary tree node. */
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class QueueNode
    {
        public TreeNode Node;
        public int Column;
    }

    public class Solution
    {
        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            var answer = new SortedDictionary<int, IList<int>>();
            var nodeQueue = new Queue<QueueNode>();

            nodeQueue.Enqueue(new QueueNode(){Node = root, Column = 0});

            while (nodeQueue.Count > 0)
            {
                var node = nodeQueue.Dequeue();
                if (node.Node == null)
                {
                    continue;
                }

                if (!answer.ContainsKey(node.Column))
                {
                    answer.Add(node.Column, new List<int>());
                }
                answer[node.Column].Add(node.Node.val);
                
                nodeQueue.Enqueue(new QueueNode(){Node = node.Node.left, Column = node.Column - 1});
                nodeQueue.Enqueue(new QueueNode(){Node = node.Node.right, Column = node.Column + 1});
            }

            return answer.Values.ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().VerticalOrder(new TreeNode(1));
            Console.WriteLine("Hello World!");
        }
    }
}
