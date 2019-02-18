using System;
using System.Collections.Generic;

namespace _0359
{
    // dict
    public class Logger
    {
        // str -> timestamp
        Dictionary<string, int> lastTS = null;

        /** Initialize your data structure here. */
        public Logger()
        {
            lastTS = new Dictionary<string, int>();
        }

        /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
            If this method returns false, the message will not be printed.
            The timestamp is in seconds granularity. */
        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if (!lastTS.ContainsKey(message) || timestamp - lastTS[message] >= 10)
            {
                lastTS[message] = timestamp;
                return true;
            }
            else
            {
                return false;
            }
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
