using System;

namespace _0708
{
    /*
// Definition for a Node.
*/
    public class Node
    {
        public int val;
        public Node next;

        public Node() { }
        public Node(int _val, Node _next)
        {
            val = _val;
            next = _next;
        }
    }

    public class Solution
    {
        public Node Insert(Node head, int insertVal)
        {
            // handle empty list
            var newNode = new Node(insertVal, null);
            newNode.next = newNode;
            if (head == null)
            {
                return newNode;
            }

            // find min/max node
            var cur = head;
            var maxNode = head;
            do
            {
                cur = cur.next;
                if (cur.val >= maxNode.val)
                {
                    maxNode = cur;
                }
            } while (cur != head);

            // edge case
            var minNode = maxNode.next;
            if (newNode.val <= minNode.val || newNode.val >= maxNode.val)
            {
                InsertNode(newNode, maxNode, minNode);
            }
            else
            {
                var pre = minNode;
                cur = minNode.next;

                while (cur != minNode)
                {
                    if (pre.val <= newNode.val && newNode.val <= cur.val)
                    {
                        InsertNode(newNode, pre, cur);
                        break;
                    }
                    cur = cur.next;
                    pre = pre.next;
                }
            }

            return head;
        }

        private void InsertNode(Node newNode, Node pre, Node cur)
        {
            newNode.next = cur;
            pre.next = newNode;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var node = new Node(1, null);
            node.next = node;
            new Solution().Insert(node, 1);
            Console.WriteLine("Hello World!");
        }
    }
}
