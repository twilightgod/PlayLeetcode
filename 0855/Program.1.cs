using System;
using System.Collections.Generic;
using System.Linq;

namespace _0855_1
{
    // it's very similar as normal one, but with more condition checkings to avoid invalid interval, it's not so obvious to read, but a little faster
    public class ExamRoom
    {
        // priority queue for intervals
        private SortedSet<(int l, int r)> bst = null;
        // key: left of interval   value: right of interval   and opposite one
        private Dictionary<int, int> lMap, rMap = null; 
        private int N;

        public ExamRoom(int N)
        {
            this.N = N;
            bst = new SortedSet<(int, int)>
            (
                Comparer<(int l, int r)>.Create
                (
                    (x, y) => 
                        (-GetPri(x.l, x.r), x.l, x.r).CompareTo((-GetPri(y.l, y.r), y.l, y.r))
                )
            );
            lMap = new Dictionary<int, int>();
            rMap = new Dictionary<int, int>();

            bst.Add((0, N - 1));
        }

        public int Seat()
        {
            var (l, r) = bst.First();
            bst.Remove(bst.First());
            lMap.Remove(l);
            rMap.Remove(r);

            var pos = 0;
            if (l == 0)
            {
                
            }
            else if (r == N - 1)
            {
                pos = N - 1;
            }
            else
            {
                pos = l + (r - l) / 2;
            }

            if (l <= pos - 1)
            {
                bst.Add((l, pos - 1));
                lMap[l] = pos - 1;
                rMap[pos - 1] = l;
            }

            if (pos + 1 <= r)
            {
                bst.Add((pos + 1, r));
                lMap[pos + 1] = r;
                rMap[r] = pos + 1;
            }

            return pos;
        }

        public void Leave(int p)
        {
            var newInterval = (l: p, r: p);
            
            if (rMap.ContainsKey(p - 1))
            {
                newInterval.l = rMap[p - 1];
                bst.Remove((rMap[p - 1], p - 1));
                rMap.Remove(p - 1);
            }

            if (lMap.ContainsKey(p + 1))
            {
                newInterval.r = lMap[p + 1];
                bst.Remove((p + 1, lMap[p + 1]));
                lMap.Remove(p + 1);
            }

            lMap[newInterval.l] = newInterval.r;
            rMap[newInterval.r] = newInterval.l;
            bst.Add(newInterval);
        }

        private int GetPri(int l, int r)
        {
            // if we could use 0 or N - 1, it's not sitting in the middle
            if (l == 0 || r == N - 1)
            {
                return r - l;
            }
            else
            {
                return (r - l) / 2;
            }
        }
    }

    /**
     * Your ExamRoom object will be instantiated and called as such:
     * ExamRoom obj = new ExamRoom(N);
     * int param_1 = obj.Seat();
     * obj.Leave(p);
     */

    class Program
    {
        static void Main(string[] args)
        {
            /*
            ["ExamRoom","seat","seat","seat","seat","leave","seat"]
[[10],[],[],[],[],[4],[]]
["ExamRoom","seat","seat","seat","seat","leave","leave","seat"]
[[4],[],[],[],[],[1],[3],[]]
["ExamRoom","seat","seat","seat","seat","leave","seat"]
[[10],[],[],[],[],[4],[]]
             */
            var er = new ExamRoom(10);
            er.Seat();
            er.Seat();
            er.Seat();
            er.Seat();
            er.Leave(4);
            er.Seat();
            Console.WriteLine("Hello World!");
        }
    }
}
