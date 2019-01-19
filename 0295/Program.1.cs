using System;
using System.Collections.Generic;
using System.Linq;

namespace _0295_1
{
    // Use SortedSet
    public class PriorityQueue<T>
    {
        private SortedSet<T> data = null;

        public PriorityQueue() : this(null)
        {
        }

        public PriorityQueue(IComparer<T> comp)
        {
            if (comp != null)
            {
                data = new SortedSet<T>(comp);
            }
            else
            {
                data = new SortedSet<T>();
            }
        }

        public void Push(T val)
        {
            data.Add(val);
        }

        public T Pop()
        {
            var ret = data.First();
            data.Remove(ret);
            return ret;
        }

        public T Peek()
        {
            return data.First();
        }

        public int Count
        {
            get
            {
                return data.Count;
            }
        }
    }

    public class MedianFinder
    {

        /** initialize your data structure here. */
        // pq1 has same size as pq2 (even numbers) or pq1 has 1 more (odd numbers)
        // Item1 in tuple is the actual value, Item2 is used to avoid duplicate
        PriorityQueue<(int, int)> pq1 = null;
        PriorityQueue<(int, int)> pq2 = null;

        // SortedSet doesn't allow duplicate elements, we need additional information to bind with actual data, it could also be random value/GUID
        int idx;

        public MedianFinder()
        {
            pq1 = new PriorityQueue<(int, int)>(Comparer<(int, int)>.Create((x, y) => -x.CompareTo(y)));
            pq2 = new PriorityQueue<(int, int)>();
            idx = 0;
        }

        public void AddNum(int num)
        {
            pq1.Push((num, idx));
            pq2.Push(pq1.Pop());

            if (pq2.Count > pq1.Count)
            {
                pq1.Push(pq2.Pop());
            }

            idx++;
        }

        public double FindMedian()
        {
            if (pq1.Count == pq2.Count)
            {
                return (pq1.Peek().Item1 + pq2.Peek().Item1) * 0.5;
            }
            else
            {
                return pq1.Peek().Item1;
            }
        }
    }

    /**
     * Your MedianFinder object will be instantiated and called as such:
     * MedianFinder obj = new MedianFinder();
     * obj.AddNum(num);
     * double param_2 = obj.FindMedian();
     */

    class Program
    {
        static void Main(string[] args)
        {
            var o = new MedianFinder();
            o.AddNum(6);
            o.AddNum(10);
            o.AddNum(2);
            o.AddNum(6);
            o.AddNum(5);
            o.AddNum(0);
            o.FindMedian();
            Console.WriteLine("Hello World!");
        }
    }
}
