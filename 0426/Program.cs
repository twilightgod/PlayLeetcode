using System;

namespace _0426
{
    /*
// Definition for a Node.
*/
    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node() { }
        public Node(int _val, Node _left, Node _right)
        {
            val = _val;
            left = _left;
            right = _right;
        }
        public class Solution
        {
            public Node TreeToDoublyList(Node root)
            {
                if (root == null)
                {
                    return null;
                }
                var result = ConvertBST(root);
                result.LeftMost.left = result.RightMost;
                result.RightMost.right = result.LeftMost;
                return result.LeftMost;
            }

            private (Node LeftMost, Node RightMost) ConvertBST(Node root)
            {
                if (root == null)
                {
                    return (null, null);
                }

                var leftResult = ConvertBST(root.left);
                var rightResult = ConvertBST(root.right);

                var leftMost = leftResult.LeftMost;
                var rightMost = rightResult.RightMost;

                if (leftMost == null)
                {
                    // no left subtree
                    leftMost = root;
                    //root.left = root;
                }
                else
                {
                    leftResult.RightMost.right = root;
                    root.left = leftResult.RightMost;
                }

                if (rightMost == null)
                {
                    // no right subtree
                    rightMost = root;
                    //root.right = root;
                }
                else
                {
                    rightResult.LeftMost.left = root;
                    root.right = rightResult.LeftMost;
                }

                return (leftMost, rightMost);
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
