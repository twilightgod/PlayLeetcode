using System;
using System.Collections.Generic;
using System.Linq;

namespace _0381
{
    public class RandomizedCollection
    {
        private List<int> vals = new List<int>();
        private Dictionary<int, HashSet<int>> val2idx = new Dictionary<int, HashSet<int>>();
        private Random random = new Random();


        /** Initialize your data structure here. */
        public RandomizedCollection()
        {

        }

        /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
        public bool Insert(int val)
        {
            var ret = false;
            if (!val2idx.ContainsKey(val))
            {
                val2idx.Add(val, new HashSet<int>());
                ret = true;
            }
            val2idx[val].Add(vals.Count);
            vals.Add(val);
            return ret;
        }

        /** Removes a value from the collection. Returns true if the collection contained the specified element. */
        public bool Remove(int val)
        {
            if (val2idx.ContainsKey(val))
            {
                var firstIdx = val2idx[val].First();
                if (firstIdx != vals.Count - 1)
                {
                    // swap firstIdx and vals.Count - 1
                    vals[firstIdx] = vals[vals.Count - 1];
                    val2idx[vals[vals.Count - 1]].Remove(vals.Count - 1);
                    val2idx[val].Remove(firstIdx);
                    val2idx[vals[vals.Count - 1]].Add(firstIdx);
                    val2idx[val].Add(vals.Count - 1);
                    firstIdx = vals.Count - 1;
                }
                val2idx[val].Remove(firstIdx);
                if (val2idx[val].Count == 0)
                {
                    val2idx.Remove(val);
                }
                vals.RemoveAt(vals.Count - 1);
                return true;
            }
            else
            {
                return false;
            }
        }

        /** Get a random element from the collection. */
        public int GetRandom()
        {
            return vals[random.Next(vals.Count)];
        }
    }

    /**
     * Your RandomizedCollection object will be instantiated and called as such:
     * RandomizedCollection obj = new RandomizedCollection();
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
