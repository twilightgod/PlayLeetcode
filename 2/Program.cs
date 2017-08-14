
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
//Definition for singly-linked list.
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            var head = new ListNode(0);
            var current = head;
            int left = 0;
            while (l1 != null || l2 != null || left > 0)
            {
                var sum = 0;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }
                sum += left;

                current.next = new ListNode(sum%10);
                current = current.next;
                left = sum/10;
            }
            return head.next;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}