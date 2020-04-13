using System;
using System.Collections.Generic;

namespace _0133
{
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public class Solution
    {
        public Node CloneGraph(Node node)
        {
            if (node == null)
            {
                return null;
            }

            var clonedNodeDictionary = new Dictionary<int, Node>();

            return CloneNode(node, clonedNodeDictionary);
        }

        private Node CloneNode(Node node, Dictionary<int, Node> clonedNodeDictionary)
        {
            if (clonedNodeDictionary.ContainsKey(node.val))
            {
                return clonedNodeDictionary[node.val];
            }

            var clonedNode = new Node(node.val);
            clonedNodeDictionary[node.val] = clonedNode;

            foreach (var neighbor in node.neighbors)
            {
                clonedNode.neighbors.Add(CloneNode(neighbor, clonedNodeDictionary));
            }

            return clonedNode;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var node0 = new Node(0);
            var node1 = new Node(1);
            var node2 = new Node(2);
            node0.neighbors.Add(node1);
            node0.neighbors.Add(node2);
            node1.neighbors.Add(node2);
            node2.neighbors.Add(node2);
            new Solution().CloneGraph(node0);
            Console.WriteLine("Hello World!");
        }
    }
}
