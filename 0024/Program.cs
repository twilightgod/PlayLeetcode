using System;

namespace _0024
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
        public ListNode SwapPairs(ListNode head)
        {
            var newHead = new ListNode(0);
            newHead.next = head;

            var p1 = newHead;
            var p2 = p1?.next;
            var p3 = p2?.next;

            while (p1 != null && p2 != null & p3 != null)
            {
                p2.next = p3.next;
                p1.next = p3;
                p3.next = p2;

                p1 = p2;
                p2 = p1?.next;
                p3 = p2?.next;
            }

            return newHead.next;
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
