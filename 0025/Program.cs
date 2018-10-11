using System;

namespace _0025
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
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null)
            {
                return head;
            }

            // get total length
            var n = 0;
            var node = head;
            while (node != null)
            {
                n++;
                node = node.next;
            }

            var g = n / k;
            if (g == 0)
            {
                return head;
            }

            // add newhead to keep first group the same logic
            var newHead = new ListNode(0);
            newHead.next = head;
            var pre = newHead;
            node = head;

            for (var i = 0; i < g; ++i)
            {
                // save last node in previous group, it will link to last node in current group before reversing
                var lastNodeInPreviousGroup = pre;
                for (var j = 0; j < k; ++j)
                {
                    var next = node.next;
                    node.next = pre;
                    pre = node;
                    node = next;
                }
                // last node in current group after reversing, it's actual last node in previous group's next
                var lastNodeInCurrentGroup = lastNodeInPreviousGroup.next;
                // pre is now first node in current group after reversing
                lastNodeInPreviousGroup.next = pre;
                // set pre to last node in current group
                pre = lastNodeInCurrentGroup;
                // link pre to node
                pre.next = node;
            }

            return newHead.next;
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
            var node5 = new ListNode(5);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;

            new Solution().ReverseKGroup(node1, 2);
            Console.WriteLine("Hello World!");
        }
    }
}
