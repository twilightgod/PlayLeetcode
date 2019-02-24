using System;

namespace _0116
{
    /*
// Definition for a Node.
*/
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }
        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }

        public class Solution
        {
            public Node Connect(Node root)
            {
                var leftMost = root;
                while (leftMost?.left != null)
                {
                    var nextLeftMost = leftMost.left;
                    var node = leftMost;
                    Node pre = null;
                    while (node != null)
                    {
                        if (pre != null)
                        {
                            pre.next = node.left;
                        }
                        node.left.next = node.right;
                        pre = node.right;
                        node = node.next;
                    }
                    leftMost = nextLeftMost;
                }

                return root;
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
