using System;

namespace _0510
{
    /*
// Definition for a Node.
*/
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node parent;
    }

    public class Solution
    {
        public Node InorderSuccessor(Node x)
        {
            var root = x;
            while (root?.parent != null)
            {
                root = root.parent;
            }

            Node answer = null;

            while (root != null)
            {
                if (x.val < root.val)
                {
                    answer = root;
                    root = root.left;
                }
                else
                {
                    root = root.right;
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
