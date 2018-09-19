using System;
using System.Collections.Generic;

namespace _0742
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
        public int FindClosestLeaf(TreeNode root, int k)
        {
            var edge = new Dictionary<TreeNode, List<TreeNode>>();
            var q = new Queue<TreeNode>();
            var visited = new HashSet<TreeNode>();
            var kNode = DFS(root, null, k, edge);

            q.Enqueue(kNode);
            visited.Add(kNode);

            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node.left == null && node.right == null)
                {
                    return node.val;
                }
                
                foreach (var nextNode in edge[node])
                {
                    if (!visited.Contains(nextNode))
                    {
                        visited.Add(nextNode);
                        q.Enqueue(nextNode);
                    }
                }
            }

            return -1;
        }

        private TreeNode DFS(TreeNode root, TreeNode parent, int k, Dictionary<TreeNode, List<TreeNode>> edge)
        {
            if (root == null)
            {
                return null;
            }

            if (parent != null)
            {
                if (!edge.ContainsKey(parent))
                {
                    edge[parent] = new List<TreeNode>();
                }
                edge[parent].Add(root);
                
                if (!edge.ContainsKey(root))
                {
                    edge[root] = new List<TreeNode>();
                }
                edge[root].Add(parent);
            }

            var leftResult = DFS(root.left, root, k, edge);
            var rightResult = DFS(root.right, root, k, edge);

            if (root.val == k)
            {
                return root;
            }
            else
            {
                return leftResult == null ? rightResult : leftResult;
            }
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
