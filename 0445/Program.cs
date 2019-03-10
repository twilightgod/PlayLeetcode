using System;
using System.Collections.Generic;

namespace _0445
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
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var s1 = new Stack<int>();
            var s2 = new Stack<int>();
            while (l1 != null)
            {
                s1.Push(l1.val);
                l1 = l1.next;
            }
            while (l2 != null)
            {
                s2.Push(l2.val);
                l2 = l2.next;
            }
            var l3 = new ListNode(0);
            while (s1.Count > 0 || s2.Count > 0)
            {
                if (s1.Count > 0)
                {
                    l3.val += s1.Pop();
                }
                if (s2.Count > 0)
                {
                    l3.val += s2.Pop();
                }
                var newl3 = new ListNode(l3.val / 10); 
                l3.val %= 10;
                newl3.next = l3;
                l3 = newl3;
            }

            // no leading 0
            if (l3.val == 0)
            {
                return l3.next;
            }
            else
            {
                return l3;
            }
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
