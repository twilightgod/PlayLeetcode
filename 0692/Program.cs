using System;
using System.Collections.Generic;
using System.Linq;

namespace _0692
{
    public class Solution
    {
        public IList<string> TopKFrequent(string[] words, int k)
        {
            var freq = new Dictionary<string, int>();
            // min heap of size k
            var pq = new SortedSet<(int f, string s)>(Comparer<(int f, string s)>.Create((a, b) => a.f == b.f ? -a.s.CompareTo(b.s) : a.f.CompareTo(b.f)));
            foreach (var s in words)
            {
                freq[s] = freq.GetValueOrDefault(s, 0) + 1;
                var oldKey = (freq[s] - 1, s);
                if (pq.Contains(oldKey))
                {
                    pq.Remove(oldKey);
                }
                var key = (freq[s], s);
                if (pq.Count < k)
                {
                    pq.Add(key);
                }
                else
                {
                    pq.Add(key);
                    pq.Remove(pq.First());
                }
            }
            var answer = pq.ToList().Select(a => a.s).ToList();
            answer.Reverse();
            return answer;
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
