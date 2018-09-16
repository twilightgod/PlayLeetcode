using System;
using System.Collections.Generic;

namespace _0138
{
    /**
 * Definition for singly-linked list with a random pointer. */
    public class RandomListNode
    {
        public int label;
        public RandomListNode next, random;
        public RandomListNode(int x) { this.label = x; }
    };

    public class Solution
    {
        public RandomListNode CopyRandomList(RandomListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var q = new Queue<RandomListNode>();
            var listNodeMapping = new Dictionary<RandomListNode, RandomListNode>();
            var newHead = new RandomListNode(head.label);
            listNodeMapping[head] = newHead;
            q.Enqueue(head);

            while (q.Count > 0)
            {
                var node = q.Dequeue();
                var newNode = listNodeMapping[node];

                if (node.next != null)
                {
                    if (listNodeMapping.ContainsKey(node.next))
                    {
                        newNode.next = listNodeMapping[node.next];
                    }
                    else
                    {
                        var newNext = new RandomListNode(node.next.label);
                        newNode.next = newNext;
                        listNodeMapping[node.next] = newNext;
                        q.Enqueue(node.next);
                    } 
                }
                if (node.random != null)
                {
                    if (listNodeMapping.ContainsKey(node.random))
                    {
                        newNode.random = listNodeMapping[node.random];
                    }
                    else
                    {
                        var newRandom = new RandomListNode(node.random.label);
                        newNode.random = newRandom;
                        listNodeMapping[node.random] = newRandom;
                        q.Enqueue(node.random);
                    }
                }
            }

            return newHead;
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
