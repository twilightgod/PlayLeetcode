using System;
using System.Collections.Generic;
using System.Linq;

namespace _0215
{
    public class Solution
    {
        public int FindKthLargest(int[] nums, int k)
        {
            var pq = new SortedDictionary<int, int>();
            var size = 0;

            foreach (var num in nums)
            {
                if (size < k)
                {
                    if (!pq.ContainsKey(num))
                    {
                        pq.Add(num, 0);
                    }
                    pq[num]++;
                    size++;
                }
                else
                {
                    var first = pq.First();
                    if (first.Key < num)
                    {
                        if (--pq[first.Key] == 0)
                        {
                            pq.Remove(first.Key);
                        }
                        if (!pq.ContainsKey(num))
                        {
                            pq.Add(num, 0);
                        }
                        pq[num]++;
                    }
                }
            }

            return pq.First().Key;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
