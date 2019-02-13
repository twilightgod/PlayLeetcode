using System;
using System.Collections.Generic;
using System.Linq;

namespace _0379
{
    public class PhoneDirectory
    {
        HashSet<int> pool = null;

        /** Initialize your data structure here
            @param maxNumbers - The maximum numbers that can be stored in the phone directory. */
        public PhoneDirectory(int maxNumbers)
        {
            pool = new HashSet<int>();
            for (var i = 0; i < maxNumbers; ++i)
            {
                pool.Add(i);
            }
        }

        /** Provide a number which is not assigned to anyone.
            @return - Return an available number. Return -1 if none is available. */
        public int Get()
        {
            if (pool.Count == 0)
            {
                return -1;
            }
            else
            {
                var ret = pool.First();
                pool.Remove(ret);
                return ret;
            }
        }

        /** Check if a number is available or not. */
        public bool Check(int number)
        {
            return pool.Contains(number);
        }

        /** Recycle or release a number. */
        public void Release(int number)
        {
            pool.Add(number);
        }
    }

    /**
     * Your PhoneDirectory object will be instantiated and called as such:
     * PhoneDirectory obj = new PhoneDirectory(maxNumbers);
     * int param_1 = obj.Get();
     * bool param_2 = obj.Check(number);
     * obj.Release(number);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
