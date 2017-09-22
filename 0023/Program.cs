﻿using System;
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
            var pq = new SortedDictionary<int, Queue<ListNode>>();
            var n = lists.Length;
            var head = new ListNode(0);
            var current = head;

            // Init
            for (var i = 0; i < n; ++i)
            {
                if (lists[i] != null)
                {
                    var val = lists[i].val;
                    if (!pq.ContainsKey(val))
                    {
                        pq[val] = new Queue<ListNode>();    
                    }
                    
                    pq[val].Enqueue(lists[i]);
                }
            }

            // Loop
            while (pq.Count > 0)
            {
                var top = pq.First();
                current.next = new ListNode(top.Key);
                current = current.next;
                
                // Dequeue
                var topnode = top.Value.Dequeue();
                if (top.Value.Count == 0)
                {
                    pq.Remove(top.Key);
                }
                if (topnode.next != null)
                {
                    var val = topnode.next.val;
                    if (!pq.ContainsKey(val))
                    {
                        pq[val] = new Queue<ListNode>();    
                    }
                    
                    pq[val].Enqueue(topnode.next);
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