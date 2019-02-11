using System;
using System.Collections.Generic;
using System.Linq;

namespace _0310
{
    public class Solution
    {
        public IList<int> FindMinHeightTrees(int n, int[,] edges_input)
        {
            var answer = new List<int>();
            if (edges_input == null || edges_input.GetLength(0) != n - 1)
            {
                return answer;
            }

            var edges = new List<List<int>>();
            var steps = new int[n];
            var degree = new int[n];
            for (var i = 0; i < n; ++i)
            {
                edges.Add(new List<int>());
            }

            for (var i = 0; i < edges_input.GetLength(0); ++i)
            {
                var v1 = edges_input[i, 0];
                var v2 = edges_input[i, 1];
                edges[v1].Add(v2);
                edges[v2].Add(v1);
                degree[v1]++;
                degree[v2]++;
            }

            // put all leaves in the q
            var q = new Queue<int>();
            for (var i = 0; i < n; ++i)
            {
                // need to be connected
                if (n > 1 && degree[i] == 0)
                {
                    return answer;
                }
                else if (degree[i] == 1)
                {
                    degree[i] = 0;
                    q.Enqueue(i);
                }
            }

            while (q.Count > 0)
            {
                var from = q.Dequeue();
                foreach (var to in edges[from])
                {
                    if (degree[to] > 0)
                    {
                        // put leaves in the q
                        if (--degree[to] == 1)
                        {
                            degree[to] = 0;
                            steps[to] = steps[from] + 1;
                            q.Enqueue(to);
                        }
                    }
                }
            }

            var maxStep = steps.Max();
            for (var i = 0; i < n; ++i)
            {
                if (steps[i] == maxStep)
                {
                    answer.Add(i);
                }
            }

            return answer;
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
