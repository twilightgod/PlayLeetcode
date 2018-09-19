using System;
using System.Collections.Generic;

namespace _0346
{
    public class MovingAverage
    {
        int capacity = 0;
        double sum = 0;
        Queue<int> cache = new Queue<int>();

        /** Initialize your data structure here. */
        public MovingAverage(int size)
        {
            capacity = size;
        }

        public double Next(int val)
        {
            sum += val;
            cache.Enqueue(val);

            if (cache.Count > capacity)
            {
                sum -= cache.Dequeue();
            }

            return sum / cache.Count;
        }
    }

    /**
     * Your MovingAverage object will be instantiated and called as such:
     * MovingAverage obj = new MovingAverage(size);
     * double param_1 = obj.Next(val);
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
