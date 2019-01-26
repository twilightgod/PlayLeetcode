using System;
using System.Collections.Generic;

namespace _0146
{
    public class LRUCache
    {

        int size = 0;
        int capacity = 0;
        LinkedList<KeyValuePair<int, int>> list = null;
        Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> hash = null;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            size = 0;
            list = new LinkedList<KeyValuePair<int, int>>();
            hash = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
        }

        public int Get(int key)
        {
            if (hash.ContainsKey(key))
            {
                var node = hash[key];
                // remove node
                list.Remove(node);
                // insert node after head
                list.AddFirst(node);
                return node.Value.Value;
            }
            else
            {
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            var kvp = new KeyValuePair<int, int>(key, value);
            if (hash.ContainsKey(key))
            {
                // update value
                var node = hash[key];
                node.Value = kvp;
                // remove node
                list.Remove(node);
                // insert node after head
                list.AddFirst(node);
            }
            else
            {
                var node = new LinkedListNode<KeyValuePair<int, int>>(kvp);
                hash[key] = node;
                list.AddFirst(node);
                //remove last
                if (++size > capacity)
                {
                    hash.Remove(list.Last.Value.Key);
                    list.RemoveLast();
                    size--;
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
