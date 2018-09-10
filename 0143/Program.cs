using System;
using System.Collections.Generic;

namespace _0143
{
    /**
 * Definition for singly-linked list.
 */
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    public class Solution
    {
        public void ReorderList(ListNode head)
        {
            // O(1) Space

            if (head == null || head.next == null)
            {
                return;
            }

            // Find mid point
            var p_mid = head;
            var p_end = head.next;

            while(p_end != null && p_end.next != null)
            {
                p_mid = p_mid.next;
                p_end = p_end.next.next;
            }

            // Revese from p_mid.next to the end
            var p1 = p_mid.next;
            var p2 = p_mid.next?.next;
            // p1 will be last node of second lst
            p1.next = null;

            while(p2 != null)
            {
                var p3 = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = p3;
            }

            // break two linked list
            p_mid.next = null;

            // Merge head and p1 (new head for reversed list)
            var newHead = new ListNode(0);
            while(!(head == null && p1 == null))
            {
                if (head != null)
                {
                    newHead.next = head;
                    head = head.next;
                    newHead = newHead.next;
                }
                if (p1 != null)
                {
                    newHead.next = p1;
                    p1 = p1.next;
                    newHead = newHead.next;
                }
            }
        }

        public void ReorderList_withStack(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return;
            }

            var nodeStack = new Stack<ListNode>();
            var node = head;
            while (node != null)
            {
                nodeStack.Push(node);
                node = node.next;
            }

            var pre = head;
            node = head.next;
            var stackSize = nodeStack.Count;
            var numbersOfNodeToBeInserted = (stackSize - 1) / 2; 
            for (var i = 0; i < numbersOfNodeToBeInserted; ++i)
            {
                // insert back between pre and node
                var back = nodeStack.Pop();
                pre.next = back;
                back.next = node;
                pre = node;
                node = node.next;
            }

            if (stackSize % 2 == 0)
            {
                node.next = null;
            }
            else
            {
                pre.next = null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            new Solution().ReorderList(node1);
            Console.WriteLine("Hello World!");
        }
    }
}
