using System;

namespace _0206
{
    /**
 * Definition for singly-linked list. */
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        /*
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
            {
                return head;
            
            }
            ListNode p1 = head;
            ListNode p2 = head.next;
            p1.next = null;

            while(p2 != null)
            {
                var p3 = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = p3;
            }

            return p1;
        }
        */

        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
            {
                return head;
            
            }
            
            var newhead = ReverseList_Recursive(head.next, head);
            head.next = null;
            return newhead;
        }

        private ListNode ReverseList_Recursive(ListNode current, ListNode previous)
        {
            if (current == null)
            {
                return previous;
            }

            var newhead = ReverseList_Recursive(current.next, current);

            current.next = previous;

            return newhead;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);

            node1.next = node2;
            node2.next = node3;

            new Solution().ReverseList(node1);

            Console.WriteLine("Hello World!");
        }
    }
}
