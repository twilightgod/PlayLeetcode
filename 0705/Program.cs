using System;
using System.Collections.Generic;

namespace _0705
{
    public class MyHashSet
    {
        List<LinkedList<int>> hashMap = new List<LinkedList<int>>(size);
        const int size = 50000;

        /** Initialize your data structure here. */
        public MyHashSet()
        {
            for (var i = 0; i < size; ++i)
            {
                // lazy init
                hashMap.Add(null);
            }
        }

        public void Add(int key)
        {
            var hashKey = key % size;
            if (hashMap[hashKey] == null)
            {
                hashMap[hashKey] = new LinkedList<int>();
            }
            var lList = hashMap[hashKey];
            foreach (var node in lList)
            {
                // already exists
                if (node == key)
                {
                    return;
                }
            }
            lList.AddLast(key);
        }

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
                if (it.Value == key)
                {
                    lList.Remove(it);
                    return;
                }
            }
        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key)
        {
            var hashKey = key % size;
            if (hashMap[hashKey] == null)
            {
                return false;
            }
            var lList = hashMap[hashKey];
            foreach (var node in lList)
            {
                if (node == key)
                {
                    return true;
                }
            }
            return false;
        }
    }

    /**
     * Your MyHashSet object will be instantiated and called as such:
     * MyHashSet obj = new MyHashSet();
     * obj.Add(key);
     * obj.Remove(key);
     * bool param_3 = obj.Contains(key);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
