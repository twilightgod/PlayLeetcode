using System;

namespace _0092
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
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (m == n)
            {
                return head;
            }

            var vHead = new ListNode(0);
            vHead.next = head;
            var p_pre_m = vHead;
            for (var i = 0; i < m - 1; ++i)
            {
                p_pre_m = p_pre_m.next;
            }

            // reverse n - m edges
            var p1 = p_pre_m.next;
            var p2 = p1.next;
            var p3 = p2.next;
            for (var i = 0; i < n - m; ++i)
            {
                p3 = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = p3;
            }

            p_pre_m.next.next = p3;
            p_pre_m.next = p1;

            return vHead.next;
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
