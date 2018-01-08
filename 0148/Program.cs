using System;

namespace _0148
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
        public ListNode SortList(ListNode head)
        {
            QSort(head, null);
            return head;
        }

        // Sort [begin, end)
        private void QSort(ListNode begin, ListNode end)
        {
            if (begin == end)
            {
                return;
            }

            var p1 = begin;
            var p2 = begin.next;

            while (p2 != end)
            {
                if (p2.val < begin.val)
                {
                    p1 = p1.next;
                    Swap(p1, p2);
                }
                p2 = p2.next;
            }

            Swap(begin, p1);

            QSort(begin, p1);
            QSort(p1.next, end);
        }

        private void Swap(ListNode node1, ListNode node2)
        {
            var t = node1.val;
            node1.val = node2.val;
            node2.val = t;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n1 = new ListNode(4);
            var n2 = new ListNode(2);
            var n3 = new ListNode(1);
            var n4 = new ListNode(3);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;

            new Solution().SortList(n1);
            Console.WriteLine("Hello World!");
        }
    }
}
