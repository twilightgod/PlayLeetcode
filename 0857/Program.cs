using System;
using System.Collections.Generic;
using System.Linq;

namespace _0857
{
    public class Worker : IComparable<Worker>
    {
        public int Quality;
        public int Wage;
        public double Ratio
        {
            get
            {
                return Wage * 1.0 / Quality;
            }
        }

        public int CompareTo(Worker other)
        {
            return this.Ratio.CompareTo(other.Ratio);
        }
    }
    public class Solution
    {
        public double MincostToHireWorkers(int[] quality, int[] wage, int K)
        {
            var n = quality.Length;
            var workers = new Worker[n];
            for (var i = 0; i < n; ++i)
            {
                workers[i] = new Worker() { Quality = quality[i], Wage = wage[i]};
            }

            Array.Sort(workers);

            var answer = double.MaxValue;
            // keep smallest top K
            // add index for possible duplication in quality
            var maxHeap = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((a, b) => a.Item1 == b.Item1 ? a.Item2.CompareTo(b.Item2) : -a.Item1.CompareTo(b.Item1)));
            var heapSum = 0;
            for (var i = 0; i < n; ++i)
            {
                if (maxHeap.Count < K)
                {
                    heapSum += workers[i].Quality;
                    maxHeap.Add((workers[i].Quality, i));
                }
                else
                {
                    var top = maxHeap.First();
                    if (workers[i].Quality < top.Item1)
                    {
                        heapSum -= top.Item1;
                        heapSum += workers[i].Quality;
                        maxHeap.Remove(top);
                        maxHeap.Add((workers[i].Quality, i));
                    }
                }

                if (maxHeap.Count == K)
                {
                    answer = Math.Min(answer, heapSum * workers[i].Ratio);
                }
            }

            return answer;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().MincostToHireWorkers(new int[]{3,1,10,10,1}, new int[]{4,8,2,2,7}, 3);
            Console.WriteLine("Hello World!");
        }
    }
}
