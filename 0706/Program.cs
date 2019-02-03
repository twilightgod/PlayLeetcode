using System;
using System.Collections.Generic;

namespace _0706
{
    public class MyHashMap
    {
        List<LinkedList<(int, int)>> hashMap = new List<LinkedList<(int, int)>>(size);
        const int size = 50000;

        /** Initialize your data structure here. */
        public MyHashMap()
        {
            for (var i = 0; i < size; ++i)
            {
                // lazy init
                hashMap.Add(null);
            }
        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            var hashKey = key % size;
            if (hashMap[hashKey] == null)
            {
                hashMap[hashKey] = new LinkedList<(int, int)>();
            }
            var lList = hashMap[hashKey];
            for (var it = lList.First; it != null; it = it.Next)
            {
                // update
                if (it.Value.Item1 == key)
                {
                    it.Value = (key, value);
                    return;
                }
            }
            // add
            lList.AddLast((key, value));
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            var hashKey = key % size;
            if (hashMap[hashKey] == null)
            {
                return -1;
            }
            foreach (var node in hashMap[hashKey])
            {
                if (node.Item1 == key)
                {
                    return node.Item2;
                }
            }
            return -1;
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            var hashKey = key % size;
            if (hashMap[hashKey] == null)
            {
                return;
            }
            var lList = hashMap[hashKey];
            for (var it = lList.First; it != null; it = it.Next)
            {
                // remove
                if (it.Value.Item1 == key)
                {
                    lList.Remove(it);
                    return;
                }
            }
        }
    }

    /**
     * Your MyHashMap object will be instantiated and called as such:
     * MyHashMap obj = new MyHashMap();
     * obj.Put(key,value);
     * int param_2 = obj.Get(key);
     * obj.Remove(key);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
