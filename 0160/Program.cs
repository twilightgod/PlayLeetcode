using System;

namespace _0160
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
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var p1 = headA;
            var p2 = headB;

            // Get length of A
            var lenA = 0;
            while (p1 != null)
            {
                lenA++;
                p1 = p1.next;
            }
            
            // Get length of B
            var lenB = 0;
            while (p2 != null)
            {
                lenB++;
                p2 = p2.next;
            }

            // skip the difference
            p1 = headA;
            p2 = headB;

            if (lenA > lenB)
            {
                for (var i = 0; i < lenA - lenB; ++i)
                {
                    p1 = p1.next;
                }
            }
            else
            {
                for (var i = 0; i < lenB - lenA; ++i)
                {
                    p2 = p2.next;
                }
            }

            // find intersection
            while (p1 != null)
            {
                if (p1 == p2)
                {
                    return p1;
                }
                p1 = p1.next;
                p2 = p2.next;
            }

            return null;
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
