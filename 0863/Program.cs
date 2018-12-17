using System;
using System.Collections.Generic;

namespace _0863
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
        public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {
            if (K == 0)
            {
                return new List<int>{target.val};
            }
            var edges = new Dictionary<int, HashSet<int>>();
            DFS(root, null, edges);
            var q = new Queue<(int, int)>();
            var visited = new HashSet<int>();
            q.Enqueue((target.val, 0));
            visited.Add(target.val);
            var answers = new List<int>();
            while (q.Count > 0)
            {
                var (v, s) = q.Dequeue();
                foreach (var nextv in edges[v])
                {
                    if (!visited.Contains(nextv))
                    {
                        visited.Add(nextv);
                        if (s + 1 == K)
                        {
                            answers.Add(nextv);
                        }
                        else
                        {
                            q.Enqueue((nextv, s + 1));
                        }
                    }
                }
            }
            return answers;
        }

        private void DFS(TreeNode root, TreeNode parent, Dictionary<int, HashSet<int>> edges)
        {
            if (root == null)
            {
                return;
            }

            if (!edges.ContainsKey(root.val))
            {
                edges.Add(root.val, new HashSet<int>());
            }

            if (parent != null)
            {
                edges[root.val].Add(parent.val);
                edges[parent.val].Add(root.val);
            }
            
            DFS(root.left, root, edges);
            DFS(root.right, root, edges);
        }
    }
}