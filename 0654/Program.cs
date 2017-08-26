using System;

namespace _0654
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

    public class Solution
    {
        int n;
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            n = nums.Length;

            return _ConstructMaximumBinaryTree(nums, 0, n);
        }

        private TreeNode _ConstructMaximumBinaryTree(int[] nums, int l, int r)
        {
            int mid = 0;
            bool found = false;

            for (int i = l; i < r; ++i)
            {
                if (!found)
                {
                    found = true;
                    mid = i;
                }
                else if (nums[mid] < nums[i])
                {
                    mid = i;
                }
            }

            if (!found)
            {
                return null;
            }
            else
            {
                var node = new TreeNode(nums[mid]);
                node.left = _ConstructMaximumBinaryTree(nums, l, mid);
                node.right = _ConstructMaximumBinaryTree(nums, mid + 1, r);
                return node;
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
