using System;

namespace _0234
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
        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true;
            }

            var p1 = head;
            var p2 = head;
            var mid = head;
            var rhead = head;

            // find middle point
            while(true)
            {
                if (p2.next == null)
                {
                    // odd
                    mid = p1;
                    rhead = mid.next;
                    break;
                }
                else if (p2.next.next == null)
                {
                    // even
                    mid = p1.next;
                    rhead = mid;
                    break;
                }
                else
                {
                    p1 = p1.next;
                    p2 = p2.next.next;
                }
            }

            // reverse [head, mid)
            p1 = head;
            p2 = head.next;
            while (p2 != mid)
            {
                var p3 = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = p3;
            }

            var lhead = p1;

            p1 = lhead;
            p2 = rhead;
            while (p2 != null)
            {
                if (p1.val != p2.val)
                {
                    return false;
                }
                p1 = p1.next;
                p2 = p2.next;
            }

            // reverse [head, mid) again if necessary

            return true;
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
