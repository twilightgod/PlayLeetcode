using System;
using System.Collections.Generic;
using System.Linq;

namespace _0432
{
    public class AllOne
    {
        Dictionary<string, int> key2val = new Dictionary<string, int>();
        Dictionary<int, HashSet<string>> val2key = new Dictionary<int, HashSet<string>>();
        LinkedList<int> valList = new LinkedList<int>();
        Dictionary<int, LinkedListNode<int>> val2node = new Dictionary<int, LinkedListNode<int>>();

        /** Initialize your data structure here. */
        public AllOne()
        {
        }

        /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
        public void Inc(string key)
        {
            var v = 0;
            LinkedListNode<int> preNode = null;
            if (!key2val.ContainsKey(key))
            {
                key2val[key] = 0;
            }
            else
            {
                v = key2val[key];
                val2key[v].Remove(key);
                preNode = val2node[v];
                if (val2key[v].Count == 0)
                {
                    val2key.Remove(v);
                    preNode = val2node[v].Previous;
                    valList.Remove(val2node[v]);
                    val2node.Remove(v);
                }
            }
            v = ++key2val[key];
            if (!val2key.ContainsKey(v))
            {
                val2key[v] = new HashSet<string>();
                val2node[v] = new LinkedListNode<int>(v);
                if (preNode == null)
                {
                    valList.AddFirst(val2node[v]);
                }
                else
                {
                    valList.AddAfter(preNode, val2node[v]);
                }

            }
            val2key[v].Add(key);
        }

        /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
        public void Dec(string key)
        {
            if (!key2val.ContainsKey(key))
            {
                return;
            }

            var v = key2val[key];
            LinkedListNode<int> preNode = val2node[v];
            val2key[v].Remove(key);
            if (val2key[v].Count == 0)
            {
                val2key.Remove(v);
                preNode = val2node[v].Next;
                valList.Remove(val2node[v]);
                val2node.Remove(v);
            }
            v = --key2val[key];
            if (v == 0)
            {
                key2val.Remove(key);
            }
            else
            {
                if (!val2key.ContainsKey(v))
                {
                    val2key[v] = new HashSet<string>();
                    val2node[v] = new LinkedListNode<int>(v);
                    if (preNode == null)
                    {
                        valList.AddLast(val2node[v]);
                    }
                    else
                    {
                        valList.AddBefore(preNode, val2node[v]);
                    }

                }
                val2key[v].Add(key);
            }
        }

        /** Returns one of the keys with maximal value. */
        public string GetMaxKey()
        {
            if (valList.Count == 0)
            {
                return String.Empty;
            }
            else
            {
                return val2key[valList.Last()].First();
            }
        }

        /** Returns one of the keys with Minimal value. */
        public string GetMinKey()
        {
            if (valList.Count == 0)
            {
                return String.Empty;
            }
            else
            {
                return val2key[valList.First()].First();
            }
        }
    }

    /**
     * Your AllOne object will be instantiated and called as such:
     * AllOne obj = new AllOne();
     * obj.Inc(key);
     * obj.Dec(key);
     * string param_3 = obj.GetMaxKey();
     * string param_4 = obj.GetMinKey();
     */

    class Program
    {
        static void Main(string[] args)
        {
            var s = new AllOne();
            s.Inc("a");
            s.Inc("b");
            s.Inc("b");
            s.Inc("b");
            s.Dec("b");
            s.Dec("b");
            s.GetMaxKey();
            s.GetMinKey();
            Console.WriteLine("Hello World!");
        }
    }
}
