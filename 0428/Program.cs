using System;
using System.Collections.Generic;
using System.Linq;

namespace _0428
{
    /*
// Definition for a Node.
*/
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }
        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

    public class Codec
    {

        // Encodes a tree to a single string.
        public string serialize(Node root)
        {
            var answer = String.Empty;
            DFS_serialize(root, ref answer);
            return answer;    
        }

        private void DFS_serialize(Node root, ref string answer)
        {
            if (root == null)
            {
                return;
            }

            answer += $"{root.val} {root.children.Count} ";
            foreach (var child in root.children)
            {
                DFS_serialize(child, ref answer);
            }
        }

        // Decodes your encoded data to tree.
        public Node deserialize(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return null;
            }
            var q = new Queue<int>(data.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries).Select(a => Int32.Parse(a)));
            return DFS_deserialize(q);
        }

        private Node DFS_deserialize(Queue<int> q)
        {
            // read 2 int
            var val = q.Dequeue();
            var childrenCount = q.Dequeue();
            var root = new Node(val, new List<Node>());
            for (var i = 0; i < childrenCount; ++i)
            {
                root.children.Add(DFS_deserialize(q));
            }
            return root;
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
