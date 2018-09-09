using System;
using System.Collections.Generic;

namespace _0133
{
    /**
 * Definition for undirected graph. */
    public class UndirectedGraphNode
    {
        public int label;
        public IList<UndirectedGraphNode> neighbors;
        public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
    };

    public class Solution
    {
        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null)
            {
                return null;
            }
            
            var clonedNodeDictionary = new Dictionary<int, UndirectedGraphNode>();

            return CloneNode(node, clonedNodeDictionary);
        }

        private UndirectedGraphNode CloneNode(UndirectedGraphNode node, Dictionary<int, UndirectedGraphNode> clonedNodeDictionary)
        {
            var clonedNode = new UndirectedGraphNode(node.label);
            clonedNodeDictionary[node.label] = clonedNode;

            foreach (var neighbor in node.neighbors)
            {
                if (clonedNodeDictionary.ContainsKey(neighbor.label))
                {
                    clonedNode.neighbors.Add(clonedNodeDictionary[neighbor.label]);
                }
                else
                {
                    clonedNode.neighbors.Add(CloneNode(neighbor, clonedNodeDictionary));
                }
            }

            return clonedNode;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var node0 = new UndirectedGraphNode(0);
            var node1 = new UndirectedGraphNode(1);
            var node2 = new UndirectedGraphNode(2);
            node0.neighbors.Add(node1);
            node0.neighbors.Add(node2);
            node1.neighbors.Add(node2);
            node2.neighbors.Add(node2);
            new Solution().CloneGraph(node0);
            Console.WriteLine("Hello World!");
        }
    }
}
