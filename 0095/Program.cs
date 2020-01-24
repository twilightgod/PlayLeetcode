using System;

namespace _0095
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
        private TreeNode DeepCopy(TreeNode root, int delta)
        {
            if (root == null)
            {
                return null;
            }

            var newRoot = new TreeNode(root.val + delta);
            newRoot.left = DeepCopy(root.left, delta);
            newRoot.right = DeepCopy(root.right, delta);

            return newRoot;
        }

        public IList<TreeNode> GenerateTrees(int n)
        {
            // answers[i] means answer list for total i nodes
            var answers = new List<IList<TreeNode>>();
            answers.Add(new List<TreeNode>());
            answers.Add(new List<TreeNode>());
            answers[0].Add(null);
            answers[1].Add(new TreeNode(1));

            for (var i = 2; i <= n; ++i)
            {
                answers.Add(new List<TreeNode>());
                // j is the root
                for (var j = 1; j <= i; ++j)
                {
                    // left has j - 1 nodes
                    // right has i - j nodes
                    // combination
                    foreach (var lnode in answers[j - 1])
                    {
                        foreach (var rnode in answers[i - j])
                        {
                            var root = new TreeNode(j);
                            // actually, we don't need DeepCopy on left since delta is 0,
                            // it just refers to nodes in other answers[]
                            // root.left = DeepCopy(lnode, 0);
                            root.left = lnode;
                            root.right = DeepCopy(rnode, j);
                            answers[i].Add(root);
                        }
                    }
                }
            }

            // special case for 0, empty list is expected instead of null
            answers[0] = new List<TreeNode>();
            return answers[n];
        }
    }
}
