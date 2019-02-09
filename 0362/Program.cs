using System;
using System.Threading;

namespace _0362
{
    public class HitCounter
    {
        int size = 300;
        int[] counters = null;
        int[] timestamps = null;

        /** Initialize your data structure here. */
        public HitCounter()
        {
            counters = new int[size];
            timestamps = new int[size];
        }

        /** Record a hit.
            @param timestamp - The current timestamp (in seconds granularity). */
        public void Hit(int timestamp)
        {
            var key = timestamp % size;
            if (timestamps[key] != timestamp)
            {
                Interlocked.Exchange(ref timestamps[key], timestamp);
                Interlocked.Exchange(ref counters[key], 0);
            }
            Interlocked.Increment(ref counters[key]);
        }

        /** Return the number of hits in the past 5 minutes.
            @param timestamp - The current timestamp (in seconds granularity). */
        public int GetHits(int timestamp)
        {
            var count = 0;
            for (var i = 0; i < size; ++i)
            {
                if (timestamp - timestamps[i] < size)
                {
                    count += counters[i];
                }
            }
            return count;
        }
    }

    /**
     * Your HitCounter object will be instantiated and called as such:
     * HitCounter obj = new HitCounter();
     * obj.Hit(timestamp);
     * int param_2 = obj.GetHits(timestamp);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
