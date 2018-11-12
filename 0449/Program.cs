using System;
using System.Collections.Generic;
using System.Text;

namespace _0449
{
    /**
 * Definition for a binary tree node.
 */
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Codec
    {

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            var seq = new List<int>();
            SerializeDFS(root, seq);
            return String.Join(",", seq);
        }

        private void SerializeDFS(TreeNode root, List<int> seq)
        {
            if (root == null)
            {
                return;
            }
            seq.Add(root.val);
            SerializeDFS(root.left, seq);
            SerializeDFS(root.right, seq);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return null;
            }
            var seq_string = data.Split(',');
            var seq = new int[seq_string.Length];
            for (var i = 0; i < seq_string.Length; ++i)
            {
                seq[i] = Int32.Parse(seq_string[i]);
            }
            return DeserializeDFS(seq, 0, seq.Length);
        }

        //[l, r)
        private TreeNode DeserializeDFS(int[] seq, int l, int r)
        {
            if (l == r)
            {
                return null;
            }
            var root = new TreeNode(seq[l]);
            var m = Array.BinarySearch(seq, l + 1, r - l - 1, seq[l]);
            m = ~m;
            root.left = DeserializeDFS(seq, l + 1, m);
            root.right = DeserializeDFS(seq, m, r);
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
