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
            // item2 is to break tie
            var pq = new SortedSet<(ListNode, int)>(Comparer<(ListNode, int)>.Create((x, y) => x.Item1.val == y.Item1.val ? x.Item2.CompareTo(y.Item2) : x.Item1.val.CompareTo(y.Item1.val)));
            var n = lists.Length;
            var head = new ListNode(0);
            var current = head;

            var ts = 0;

            // Init
            for (var i = 0; i < n; ++i)
            {
                if (lists[i] != null)
                {
                    var val = lists[i].val;
                    pq.Add((lists[i], ts++));
                }
            }

            // Loop
            while (pq.Count > 0)
            {
                var top = pq.First();
                pq.Remove(top);
                
                current.next = top.Item1;
                current = current.next;
                
                if (current.next != null)
                {
                    pq.Add((current.next, ts++));
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
