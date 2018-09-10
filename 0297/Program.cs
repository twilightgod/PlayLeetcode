using System;
using System.Collections.Generic;
using System.Text;

namespace _0297
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
            var q = new Queue<TreeNode>();
            var resultList = new List<string>();

            q.Enqueue(root);
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node == null)
                {
                    resultList.Add("N");
                }
                else
                {
                    resultList.Add(node.val.ToString());
                    q.Enqueue(node.left);
                    q.Enqueue(node.right);
                }
            }
            
            return String.Join(",", resultList);            
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return null;
            }

            var resultList = data.Split(',');
            var q = new Queue<TreeNode>();
            

            TreeNode root = null;
            if (resultList[0] == "N")
            {
                root = null;
            }
            else
            {
                root = new TreeNode(Convert.ToInt32(resultList[0]));
            }
            if (root != null)
            {
                q.Enqueue(root);
            }
            var index = 1;

            while (q.Count > 0)
            {
                var node = q.Dequeue();

                if (resultList[index] != "N")
                {
                    var leftChild = new TreeNode(Convert.ToInt32(resultList[index]));
                    node.left = leftChild;
                    q.Enqueue(leftChild);
                }
                index++;
                if (resultList[index] != "N")
                {
                    var rightChild = new TreeNode(Convert.ToInt32(resultList[index]));
                    node.right = rightChild;
                    q.Enqueue(rightChild);
                }
                index++;
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
