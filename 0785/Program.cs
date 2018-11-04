using System;
using System.Collections.Generic;

namespace _0785
{
    public class Solution
    {
        public bool IsBipartite(int[][] graph)
        {
            var n = graph.Length;
            // 0: unassigned
            // 1, -1 two groups
            var g = new int[n];
            for (var i = 0; i < n; ++i)
            {
                var q = new Queue<int>();
                if (g[i] == 0)
                {
                    g[i] = 1;
                    q.Enqueue(i);
                    while (q.Count > 0)
                    {
                        var cur = q.Dequeue();
                        for (var j = 0; j < graph[cur].Length; ++j)
                        {
                            var next = graph[cur][j];
                            if (g[next] == 0)
                            {
                                g[next] = g[cur] * -1;
                                q.Enqueue(next);
                            }
                            else if (g[next] != g[cur] * -1)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
    }

    class Program
    {
        /*
        [[1,3],[0,2],[1,3],[0,2]]
[[1,2,3], [0,2], [0,1,3], [0,2]]
[[4],[],[4],[4],[0,2,3]]
[[],[3],[],[1],[]]
[[],[2,4,6],[1,4,8,9],[7,8],[1,2,8,9],[6,9],[1,5,7,8,9],[3,6,9],[2,3,4,6,9],[2,4,5,6,7,8]]
 */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
