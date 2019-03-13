using System;
using System.Collections.Generic;
using System.Linq;

namespace _0023
{
    /**
 * Definition for singly-linked list.*/
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            // O(n log k)
            // (val, list idx)
            var pq = new SortedSet<(int, int)>();
            var head = new ListNode(0);
            var current = head;

            // Init
            for (var i = 0; i < lists.Length; ++i)
            {
                if (lists[i] != null)
                {
                    pq.Add((lists[i].val, i));
                }
            }

            // Loop
            while (pq.Count > 0)
            {
                var top = pq.First();
                pq.Remove(top);
                
                var idx = top.Item2;
                current.next = lists[idx];
                lists[idx] = lists[idx].next;
                current = current.next;
                
                if (current.next != null)
                {
                    pq.Add((current.next.val, idx));
                }
            }

            return head.next;
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
