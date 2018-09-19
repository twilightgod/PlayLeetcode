using System;
using System.Collections.Generic;

namespace _0460
{
    public class LFUNode
    {
        public int Frequency;
        public int Key;
        public int Value;
    }

    public class LFUCache
    {
        int capacity = 0;
        int minFrequency = 0;
        // key -> LinkedListNode
        Dictionary<int, LinkedListNode<LFUNode>> hash = new Dictionary<int, LinkedListNode<LFUNode>>();
        // frequency -> linkedlist, nodes near head means been visited more recently
        Dictionary<int, LinkedList<LFUNode>> linkedLists = new Dictionary<int, LinkedList<LFUNode>>();

        public LFUCache(int capacity)
        {
            this.capacity = capacity;
        }

        public int Get(int key)
        {
            if (!hash.ContainsKey(key))
            {
                return -1;
            }

            hash[key].Value.Frequency++;
            UpdateFrequencyLinkedLists(hash[key]);
            return hash[key].Value.Value;
        }

        public void Put(int key, int value)
        {
            // special handle for 0 capacity, can't remove node in this case
            if (capacity == 0)
            {
                return;
            }

            if (hash.ContainsKey(key))
            {
                hash[key].Value.Value = value;
                hash[key].Value.Frequency++;
            }
            else
            {
                if (hash.Count == capacity)
                {
                    RemoveMinFrequency();
                }
                hash[key] = new LinkedListNode<LFUNode>(new LFUNode(){Frequency = 1, Key = key, Value = value});
            }
            UpdateFrequencyLinkedLists(hash[key]);
        }

        private void RemoveMinFrequency()
        {
            var lastNode = linkedLists[minFrequency].Last;
            hash.Remove(lastNode.Value.Key);
            linkedLists[minFrequency].RemoveLast();
            if (linkedLists[minFrequency].Count == 0)
            {
                linkedLists.Remove(minFrequency);
                // don't need to update minFrequency here, since we will add new element before next remove, it will set minFrequency = 1
            }
        }

        private void UpdateFrequencyLinkedLists(LinkedListNode<LFUNode> node)
        {
            var preFrequency = node.Value.Frequency - 1;
            if (preFrequency > 0)
            {
                linkedLists[preFrequency].Remove(node);
                if (linkedLists[preFrequency].Count == 0)
                {
                    linkedLists.Remove(preFrequency);
                    // if previous linkedlist is the min frequency list, and now it's empty, increase minFrequency
                    if (minFrequency == preFrequency)
                    {
                        minFrequency = node.Value.Frequency;
                    }
                }
            }
            else
            {
                // reset minFrequency = 1 for new element
                minFrequency = 1;
            }

            if (!linkedLists.ContainsKey(node.Value.Frequency))
            {
                linkedLists[node.Value.Frequency] = new LinkedList<LFUNode>();
            }
            linkedLists[node.Value.Frequency].AddFirst(node);
        }
    }

    /**
     * Your LFUCache object will be instantiated and called as such:
     * LFUCache obj = new LFUCache(capacity);
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
