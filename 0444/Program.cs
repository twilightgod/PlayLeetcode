using System;
using System.Collections.Generic;

namespace _0444
{
    public class Solution
    {
        public bool SequenceReconstruction(int[] org, IList<IList<int>> seqs)
        {
            var n = org.Length;
            var indegree = new int[n + 1];
            var edge = new HashSet<int>[n + 1];
            var seen = new HashSet<int>();
            for (var i = 1; i <= n; ++i)
            {
                edge[i] = new HashSet<int>();
                seen.Add(i);
            }
            
            foreach (var seq in seqs)
            {
                if (seq.Count == 1)
                {
                    if (seq[0] < 1 || seq[0] > n)
                    {
                        return false;
                    }
                    seen.Remove(seq[0]);
                }
                for (var i = 0; i < seq.Count - 1; ++i)
                {
                    var n1 = seq[i];
                    var n2 = seq[i + 1];
                    if (n1 < 1 || n1 > n || n2 < 1 || n2 > n)
                    {
                        return false;
                    }
                    if (edge[n1].Add(n2))
                    {
                        indegree[n2]++;
                    }
                    seen.Remove(n1);
                    seen.Remove(n2);
                }
            }

            if (seen.Count > 0)
            {
                return false;
            }

            var zeroQ = new Queue<int>();
            for (var i = 1; i <= n; ++i)
            {
                if (indegree[i] == 0)
                {
                    zeroQ.Enqueue(i);
                }
            }
            var idx = 0;
            while (zeroQ.Count > 0)
            {
                if (zeroQ.Count > 1)
                {
                    return false;
                }
                var n1 = zeroQ.Dequeue();
                if (n1 != org[idx])
                {
                    return false;
                }
                else
                {
                    idx++;
                }
                foreach (var n2 in edge[n1])
                {
                    if (--indegree[n2] == 0)
                    {
                        zeroQ.Enqueue(n2);
                    }
                }
            }

            return idx == n;
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
