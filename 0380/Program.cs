using System;
using System.Collections.Generic;

namespace _0380
{
    public class RandomizedSet
    {
        private List<int> vals = new List<int>();
        private Dictionary<int, int> val2idx = new Dictionary<int, int>();
        private Random random = new Random();

        /** Initialize your data structure here. */
        public RandomizedSet()
        {

        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (val2idx.ContainsKey(val))
            {
                return false;
            }
            else
            {
                val2idx[val] = vals.Count;
                vals.Add(val);
                return true;
            }
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (val2idx.ContainsKey(val))
            {
                if (val2idx[val] != vals.Count - 1)
                {
                    vals[val2idx[val]] = vals[vals.Count - 1];
                    val2idx[vals[vals.Count - 1]] = val2idx[val];
                }
                val2idx.Remove(val);
                vals.RemoveAt(vals.Count - 1);
                return true;
            }
            else
            {
                return false;
            }
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            return vals[random.Next(vals.Count)];
        }
    }

    /**
     * Your RandomizedSet object will be instantiated and called as such:
     * RandomizedSet obj = new RandomizedSet();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
