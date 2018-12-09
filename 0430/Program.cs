using System;

namespace _0430
{
    /*
// Definition for a Node.
*/
    public class Node
    {
        public int val;
        public Node prev;
        public Node next;
        public Node child;

        public Node() { }
        public Node(int _val, Node _prev, Node _next, Node _child)
        {
            val = _val;
            prev = _prev;
            next = _next;
            child = _child;
        }
        public class Solution
        {
            public Node Flatten(Node head)
            {
                DFS(head);
                return head;
            }

            // return last node of current list
            private Node DFS(Node head)
            {
                var pre = head;
                var cur = head;
                while (cur != null)
                {
                    if (cur.child != null)
                    {
                        var lastNodeInChild = DFS(cur.child);
                        var t_pre = lastNodeInChild;
                        var t_cur = cur.next;
                        if (cur.next != null)
                        {
                            cur.next.prev = lastNodeInChild;
                        }
                        lastNodeInChild.next = cur.next;
                        cur.next = cur.child;
                        cur.child.prev = cur;
                        cur.child = null;
                        pre = t_pre;
                        cur = t_cur;
                    }
                    else
                    {
                        pre = cur;
                        cur = cur.next;
                    }
                }
                // cur is null
                return pre;
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
