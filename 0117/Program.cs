using System;

namespace _0117
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
                // Previous level nodes already have next pointer built
                var preLevel = root;
                while (preLevel != null)
                {
                    Node curLevel = null;
                    Node curLevelFirst = null;
                    while (preLevel != null)
                    {
                        if (preLevel.left != null)
                        {
                            if (curLevel == null)
                            {
                                curLevel = preLevel.left;
                                curLevelFirst = curLevel;
                            }
                            else
                            {
                                curLevel.next = preLevel.left;
                                curLevel = curLevel.next;
                            }
                        }

                        if (preLevel.right != null)
                        {
                            if (curLevel == null)
                            {
                                curLevel = preLevel.right;
                                curLevelFirst = curLevel;
                            }
                            else
                            {
                                curLevel.next = preLevel.right;
                                curLevel = curLevel.next;
                            }
                        }
                        preLevel = preLevel.next;
                    }
                    preLevel = curLevelFirst;
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
