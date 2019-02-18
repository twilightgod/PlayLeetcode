using System;
using System.Collections.Generic;

namespace _0359_1
{
    // Circle Buffer, similar with Hit Counter
    public class Logger
    {
        const int size = 10;
        int[] ts = null;
        HashSet<string>[] set = null;

        /** Initialize your data structure here. */
        public Logger()
        {
            ts = new int[size];
            set = new HashSet<string>[size];
            for (var i = 0; i < size; ++i)
            {
                ts[i] = -1;
                set[i] = new HashSet<string>();
            }
        }

        /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
            If this method returns false, the message will not be printed.
            The timestamp is in seconds granularity. */
        public bool ShouldPrintMessage(int timestamp, string message)
        {
            // find message in valid buffer
            for (var i = 0; i < size; ++i)
            {
                if (timestamp - ts[i] < 10 && set[i].Contains(message))
                {
                    return false;
                }
            }
            // add in buffer
            var key = timestamp % size;
            if (ts[key] != timestamp)
            {
                // invalid buffer
                ts[key] = timestamp;
                // potentially creating a new object is faster than .Clear()
                set[key] = new HashSet<string>();
            }

            set[key].Add(message);
            return true;
        }
    }

    /**
     * Your Logger object will be instantiated and called as such:
     * Logger obj = new Logger();
     * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
