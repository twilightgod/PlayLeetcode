using System;
using System.Collections.Generic;
using System.Linq;

namespace _0315
{
    public class SegmentTreeNode
    {
        public int L;
        public int R;
        public int Count = 0;
        public SegmentTreeNode LeftChild = null;
        public SegmentTreeNode RightChild = null;
    }

    public class Solution
    {
        public IList<int> CountSmaller(int[] nums)
        {
            var answers = new List<int>();
            if (nums.Length == 0)
            {
                return answers; 
            }

            var segmentTreeRoot = new SegmentTreeNode();
            segmentTreeRoot.L = nums.Min();
            segmentTreeRoot.R = nums.Max();

            for (var i = nums.Length - 1; i >= 0; --i)
            {
                answers.Add(TotalPointsInRange(segmentTreeRoot, segmentTreeRoot.L, nums[i] - 1));
                InsertPoint(segmentTreeRoot, nums[i]);
            }

            answers.Reverse();
            return answers;
        }

        private void InsertPoint(SegmentTreeNode root, int num)
        {
            root.Count++;

            // leaf
            if (num == root.L && num == root.R)
            {
                return;
            }
            
            var mid = (root.L + root.R) >> 1;
            if (num <= mid)
            {
                if (root.LeftChild == null)
                {
                    root.LeftChild = new SegmentTreeNode();
                    root.LeftChild.L = root.L;
                    root.LeftChild.R = mid;
                }
                InsertPoint(root.LeftChild, num);
            }
            else
            {
                if (root.RightChild == null)
                {
                    root.RightChild = new SegmentTreeNode();
                    root.RightChild.L = mid + 1;
                    root.RightChild.R = root.R;
                }
                InsertPoint(root.RightChild, num);
            }
        }

        private int TotalPointsInRange(SegmentTreeNode root, int l, int r)
        {
            if (root == null || r < root.L || l > root.R)
            {
                return 0;
            }

            if (l <= root.L && root.R <= r)
            {
                return root.Count;
            }

            return TotalPointsInRange(root.LeftChild, l, r) + TotalPointsInRange(root.RightChild, l, r);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //new Solution().CountSmaller(new int[]{5, 2, 6, 1});
            Console.WriteLine("Hello World!");
        }
    }
}
