using System;
using System.Collections.Generic;

namespace _0146
{
    public class ListNode
    {
        public ListNode Previous;
        public ListNode Next;
        public int Key;
        public int Value;
    }

    public class LRUCache
    {

        int size = 0;
        int capacity = 0;
        ListNode head = null;
        ListNode tail = null;

        Dictionary<int, ListNode> hash = null;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            size = 0;
            head = new ListNode();
            tail = new ListNode();
            head.Previous = null;
            head.Next = tail;
            tail.Previous = head;
            tail.Next = null;
            hash = new Dictionary<int, ListNode>();
        }

        public int Get(int key)
        {
            if (hash.ContainsKey(key))
            {
                var node = hash[key];
                // remove node
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
                // insert node after head
                head.Next.Previous = node;
                node.Next = head.Next;
                head.Next = node;
                node.Previous = head;
                return node.Value;
            }
            else
            {
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            if (hash.ContainsKey(key))
            {
                // update value
                var node = hash[key];
                node.Value = value;
                // remove node
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
                // insert node after head
                head.Next.Previous = node;
                node.Next = head.Next;
                head.Next = node;
                node.Previous = head;
            }
            else
            {
                size++;
                var node = new ListNode();
                node.Key = key;
                node.Value = value;
                // insert node after head
                head.Next.Previous = node;
                node.Next = head.Next;
                head.Next = node;
                node.Previous = head;
                hash[key] = node;
                //remove last
                if (size > capacity)
                {
                    node = tail.Previous;
                    node.Previous.Next = tail;
                    tail.Previous = node.Previous;
                    hash.Remove(node.Key);
                }
            }
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
