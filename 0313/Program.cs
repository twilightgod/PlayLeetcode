using System;
using System.Collections.Generic;
using System.Linq;

namespace _0313
{
    public class PQNode
    {
        public int Prime;

        public int UglyIndex;
    }

    public class Solution
    {
        public int NthSuperUglyNumber(int n, int[] primes)
        {
            if (n == 1)
            {
                return 1;
            }

            var ugly = new int[n + 1];
            ugly[1] = 1;

            var pq = new SortedDictionary<int, List<PQNode>>();
            foreach (var p in primes)
            {
                pq.Add(p,
                    new List<PQNode>()
                    {
                        new PQNode()
                        {
                            Prime = p,
                            UglyIndex = 1,
                        }
                    }
                );
            }

            for (int i = 2; i <= n; ++i)
            {
                var kvp = pq.First();

                if (i == n)
                {
                    return kvp.Key;
                }

                ugly[i] = kvp.Key;

                while (kvp.Value.Count > 0)
                {
                    var node = kvp.Value.First();
                    kvp.Value.RemoveAt(0);
                    var val = node.Prime * ugly[++node.UglyIndex];
                    if (!pq.ContainsKey(val))
                    {
                        pq.Add(val, new List<PQNode>());
                    }
                    pq[val].Add(node);
                }
                
                pq.Remove(kvp.Key);
            }

            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().NthSuperUglyNumber(7, new int[]{2,3,5}));
        }
    }
}
