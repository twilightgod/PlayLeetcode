using System;
using System.Collections.Generic;

namespace _0699_1
{

    public class SegmentTreeNode
    {
        public int L { set; get; }
        public int R { set; get; }
        public int Max { set; get; } = 0;
        public SegmentTreeNode Left { set; get; } = null;
        public SegmentTreeNode Right { set; get; } = null;
    }

    public class SegmentTree
    {
        SegmentTreeNode root = null;

        // build tree in range [L, R]
        public SegmentTree(int l, int r)
        {
            root = BuildTree(l, r);
        }

        private SegmentTreeNode BuildTree(int l, int r)
        {
            if (l == r)
            {
                return new SegmentTreeNode() { L = l, R = r };
            }
            var m = (l + r) >> 1;
            return new SegmentTreeNode() { L = l, R = r, Left = BuildTree(l, m), Right = BuildTree(m + 1, r) };
        }

        // TODO: bulk update
        public void Update(SegmentTreeNode node, int l, int r, int val)
        {
            if (l == r)
            {
                node.Max = val;
                return;
            }
            var m = (l + r) >> 1;
            if (r <= m)
            {
                Update(node.Left, l, r, val);
            }
            else if (m + 1 <= l)
            {
                Update(node.Right, l, r, val);
            }
            else
            {
                Update(node.Left, l, m, val);
                Update(node.Right, m + 1, r, val);
            }
            node.Max = Math.Max(node.Left.Max, node.Right.Max);
        }

        public int Query(SegmentTreeNode node, int l, int r)
        {
            if (l == r)
            {
                return node.Max;
            }

        }
    }

    // segmenttree
    public class Solution
    {
        public IList<int> FallingSquares(int[,] positions)
        {
            // n is 1000, positions can be 10^8, build a map to speed up and save memory
            var n = positions.GetLength(0);
            var xSet = new SortedSet<int>();
            var xMap = new Dictionary<int, int>();
            for (var i = 0; i < n; ++i)
            {
                xSet.Add(positions[i, 0]);
                xSet.Add(positions[i, 0] + positions[i, 1] - 1);
            }
            foreach (var x in xSet)
            {
                xMap[x] = xMap.Count;
            }
            var m = xMap.Count;
            // mapped range is [0, m)

            var answer = new List<int>();
            var h = new int[m];
            for (var i = 0; i < n; ++i)
            {
                var start = xMap[positions[i, 0]];
                var end = xMap[positions[i, 0] + positions[i, 1] - 1];
                // get existing height
                var maxH = -1;
                for (var j = start; j <= end; ++j)
                {
                    maxH = Math.Max(maxH, h[j]);
                }
                // update height
                for (var j = start; j <= end; ++j)
                {
                    h[j] = positions[i, 1] + maxH;
                }
                maxH = -1;
                for (var j = 0; j < m; ++j)
                {
                    maxH = Math.Max(maxH, h[j]);
                }
                answer.Add(maxH);
            }

            return answer;
        }
    }

    public class Solution
    {
        public IList<int> FallingSquares(int[,] positions)
        {

        }
    }
}
