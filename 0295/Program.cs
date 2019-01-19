using System;
using System.Collections.Generic;
using System.Linq;

namespace _0295
{
    // Handmade PQ
    public class PriorityQueue<T>
    {
        private IComparer<T> comp = Comparer<T>.Default;
        private List<T> data = new List<T>();

        public PriorityQueue()
        {

        }

        public PriorityQueue(IComparer<T> comp)
        {
            this.comp = comp;
        }

        public void Push(T val)
        {
            data.Add(val);
            var i = data.Count - 1;
            while (i > 0 && comp.Compare(data[i], data[GetParent(i)]) < 0)
            {
                (data[i], data[GetParent(i)]) = (data[GetParent(i)], data[i]);
                i = GetParent(i);
            }
        }

        public T Pop()
        {
            var ret = data[0];
            var i = 0;
            data[0] = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            while (true)
            {
                var left = GetLeftChild(i);
                var right = GetRightChild(i);
                var chosen = -1;
                if (left < data.Count)
                {
                    chosen = left;
                }
                if (right < data.Count && comp.Compare(data[right], data[left]) < 0)
                {
                    chosen = right;
                }
                if (chosen != -1 && comp.Compare(data[i], data[chosen]) > 0)
                {
                    var t = data[i];
                    data[i] = data[chosen];
                    data[chosen] = t;
                    i = chosen;
                }
                else
                {
                    break;
                }
            }

            return ret;
        }

        public T Peek()
        {
            return data[0];
        }

        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        private int GetParent(int child)
        {
            return ((child + 1) >> 1) - 1;
        }

        private int GetLeftChild(int parent)
        {
            return (parent << 1) + 1;
        }

        private int GetRightChild(int parent)
        {
            return (parent << 1) + 2;
        }
    }

    public class MedianFinder
    {

        /** initialize your data structure here. */
        // pq1 has same size as pq2 (even numbers) or pq1 has 1 more (odd numbers)
        PriorityQueue<int> pq1 = null;
        PriorityQueue<int> pq2 = null;

        public MedianFinder()
        {
            pq1 = new PriorityQueue<int>(Comparer<int>.Create((x, y) => -x.CompareTo(y)));
            pq2 = new PriorityQueue<int>();
        }

        public void AddNum(int num)
        {
            pq1.Push(num);
            pq2.Push(pq1.Pop());

            if (pq2.Count > pq1.Count)
            {
                pq1.Push(pq2.Pop());
            }
        }

        public double FindMedian()
        {
            if (pq1.Count == pq2.Count)
            {
                return (pq1.Peek() + pq2.Peek()) * 0.5;
            }
            else
            {
                return pq1.Peek();
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
