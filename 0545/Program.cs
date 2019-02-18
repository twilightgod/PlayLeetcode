using System;
using System.Collections.Generic;

namespace _0545
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
        public IList<int> BoundaryOfBinaryTree(TreeNode root)
        {
            var lResult = GetLeftBoundary(root);
            var rResult = GetRightBoundary(root);
            var leavesResult = GetLeaves(root);
            if (lResult.Count == 1 && rResult.Count == 1)
            {
                // single node
                return leavesResult;
            }
            var finalResult = new List<int>(lResult);
            for (var i = 0; i < leavesResult.Count; ++i)
            {
                if (i == 0 && lResult.Count > 1)
                {
                    continue;
                }
                else
                {
                    finalResult.Add(leavesResult[i]);
                }
            }
            for (var i = rResult.Count - 2; i >= 1; --i)
            {
                finalResult.Add(rResult[i]);
            }
            return finalResult;
        }

        private List<int> GetLeftBoundary(TreeNode root)
        {
            var result = new List<int>();
            if (root != null && root.left == null)
            {
                result.Add(root.val);
            }
            else
            {
                GetLeftBoundaryDFS(root, result);
            }
            return result;
        }

        private void GetLeftBoundaryDFS(TreeNode root, List<int> result)
        {
            if (root == null)
            {
                return;
            }

            result.Add(root.val);
            if (root.left == null && root.right == null)
            {
                return;
            }
            else if (root.left != null)
            {
                GetLeftBoundaryDFS(root.left, result);
            }
            else
            {
                GetLeftBoundaryDFS(root.right, result);
            }
        }

        private List<int> GetRightBoundary(TreeNode root)
        {
            var result = new List<int>();
            if (root != null && root.right == null)
            {
                result.Add(root.val);
            }
            else
            {
                GetRightBoundaryDFS(root, result);
            }
            return result;
        }

        private void GetRightBoundaryDFS(TreeNode root, List<int> result)
        {
            if (root == null)
            {
                return;
            }

            result.Add(root.val);
            if (root.left == null && root.right == null)
            {
                return;
            }
            else if (root.right != null)
            {
                GetRightBoundaryDFS(root.right, result);
            }
            else
            {
                GetRightBoundaryDFS(root.left, result);
            }
        }

        private List<int> GetLeaves(TreeNode root)
        {
            var result = new List<int>();

            GetLeavesDFS(root, result);

            return result;
        }

        private void GetLeavesDFS(TreeNode root, List<int> result)
        {
            if (root == null)
            {
                return;
            }

            if (root.left == null && root.right == null)
            {
                result.Add(root.val);
            }
            GetLeavesDFS(root.left, result);
            GetLeavesDFS(root.right, result);
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
