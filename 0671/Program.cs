using System;
using System.Collections.Generic;

namespace _0671
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
        public int FindSecondMinimumValue(TreeNode root)
        {
            if (root == null)
            {
                return -1;
            }

            return DFS(root, root.val, -1);
        }

        // return 2nd smallest value
        private int DFS(TreeNode root, int smallest, int secondsmallest)
        {
            if (root == null)
            {
                return -1;
            }

            if (secondsmallest > -1 && root.val > secondsmallest)
            {
                return -1;
            }

            var ans = -1;
            if (root.val > smallest)
            {
                ans = root.val;
            }

            var ansleft = DFS(root.left, smallest, ans);
            
            if (ansleft != -1)
            {
                if (ans != -1)
                {
                    ans = Math.Min(ans, ansleft);
                }
                else
                {
                    ans = ansleft;
                }
            }

            var ansright = DFS(root.right, smallest, ans);
            if (ansright != -1)
            {
                if (ans != -1)
                {
                    ans = Math.Min(ans, ansright);
                }
                else
                {
                    ans = ansright;
                }
            }

            return ans;
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
