using System;

namespace _0142
{
    /**
 * Definition for singly-linked list.
 */
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }

    public class Solution
    {
        public ListNode DetectCycle(ListNode head)
        {
            var start = head;
            var slow = head;
            var fast = head;

            while (true)
            {
                slow = slow?.next;
                fast = fast?.next?.next;
                if (fast == null)
                {
                    return null;
                }
                else if (fast == slow)
                {
                    // foudn cycle
                    while (start != slow)
                    {
                        start = start.next;
                        slow = slow.next;
                    }
                    return start;
                }
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
