using System;
using System.Collections.Generic;
using System.Linq;

namespace _0332
{
    public class Solution
    {
        public IList<string> FindItinerary(string[,] tickets)
        {
            var answer = new List<string>();
            var edges = new Dictionary<string, SortedSet<(string, int)>>();
            for (var i = 0; i < tickets.GetLength(0); ++i)
            {
                var from = tickets[i, 0];
                var to = tickets[i, 1];
                edges.TryAdd(from, new SortedSet<(string, int)>());
                edges[from].Add((to, i));
            }
            DFS("JFK", edges, answer);
            answer.Reverse();
            return answer;
        }

        private void DFS(string from, Dictionary<string, SortedSet<(string, int)>> edges, List<string> answer)
        {
            if (edges.ContainsKey(from))
            {
                var edgeSet = edges[from];
                while (edgeSet.Count > 0)
                {
                    var (to, idx) = edgeSet.First();
                    edgeSet.Remove((to, idx));
                    DFS(to, edges, answer);
                }
            }

            answer.Add(from);
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
