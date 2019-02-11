using System;
using System.Collections.Generic;

namespace _0699
{
    // brute force
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
