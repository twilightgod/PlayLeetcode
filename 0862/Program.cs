using System;
using System.Collections.Generic;
using System.Linq;

namespace _0862
{
    public class Solution
    {
        public int ShortestSubarray(int[] A, int K)
        {
            if (A == null || A.Length == 0)
            {
                return -1;
            }

            var answer = Int32.MaxValue;
    
            // padding
            var n = A.Length;
            var sum = new int[n + 1];
            sum[0] = 0;
            for (var i = 1; i <= n; ++i)
            {
                sum[i] = sum[i - 1] + A[i - 1];
            }

            // sort by sum asc, index desc
            var heap = new SortedSet<(int s, int idx)>();

            var l = 0;
            heap.Add((0, 0));
            for (var r = 1; r <= n; ++r)
            {
                // if we already found an answer, we can keep heap size to match it
                if (answer < Int32.MaxValue && r - l > answer)
                {
                    heap.Remove((sum[l], -l));
                    l++;
                }

                // find the min node in sequence before
                while (heap.Count > 0)
                {
                    var minNode = heap.First();
                    // can't find an answer
                    if (sum[r] - minNode.s < K)
                    {
                        break;
                    }
                    else
                    {
                        // remove [l, -minNode.idx] from heap
                        for (var i = l; i <= -minNode.idx; ++i)
                        {
                            heap.Remove((sum[i], -i));
                        }
                        l = -minNode.idx;
                        // update answer
                        answer = r - l;
                        // move one more index, since -minNode.idx is already removed
                        l++;
                    }
                }

                heap.Add((sum[r], -r));
            }

            return answer == Int32.MaxValue ? -1 : answer;
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
