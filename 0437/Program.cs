using System;

namespace _0437
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
        public int PathSum(TreeNode root, int sum)
        {
            return Traverse(root, sum);
        }

        private int Traverse(TreeNode root, int target)
        {
            if (root == null)
            {
                return 0;
            }

            return DFS(root, target, 0) + Traverse(root.left, target) + Traverse(root.right, target);
        }

        private int DFS(TreeNode root, int target, int sum)
        {
            if (root == null)
            {
                return 0;
            }

            var ans = 0;

            sum += root.val;
            if (sum == target)
            {
                ans++;
            }

            ans += DFS(root.left, target, sum);
            ans += DFS(root.right, target, sum);

            return ans;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n1 = new TreeNode(1);
            var n2 = new TreeNode(2);
            var n3 = new TreeNode(3);
            var n4 = new TreeNode(4);
            var n5 = new TreeNode(5);
            n1.right = n2;
            n2.right = n3;
            n3.right = n4;
            n4.right = n5;

            Console.WriteLine(new Solution().PathSum(n1, 3));
        }
    }
}
