using System;
using System.Collections.Generic;
using System.Linq;

namespace _0218
{
    public class Solution 
    {
        public IList<int[]> GetSkyline(int[,] buildings) 
        {
            var events = new List<(int x, int h)>();
            var n = buildings.GetLength(0);
            for (var i = 0; i < n; ++i)
            {
                events.Add((buildings[i, 0], -buildings[i, 2]));
                events.Add((buildings[i, 1], buildings[i, 2]));
            }

            events.Sort((a, b) =>
                a.x == b.x ?
                    a.h.CompareTo(b.h) :
                    a.x.CompareTo(b.x)
            );

            var answers = new List<int[]>();
            
            var bst = new SortedDictionary<int, int>
            (Comparer<int>.Create(
                (a, b) => 
                -a.CompareTo(b)
                )
            );
            bst[0] = 1;

            for (var i = 0; i < (n << 1); ++i)
            {
                var isEnterEvnet = events[i].h < 0;
                var h = Math.Abs(events[i].h);

                if (isEnterEvnet)
                {
                    if (!bst.ContainsKey(h))
                    {
                        if (h > bst.Keys.First())
                        {
                            answers.Add(new int[]{events[i].x, h});
                        }
                        bst[h] = 0;
                    }
                    bst[h]++;
                }
                else
                {
                    if (--bst[h] == 0)
                    {
                        bst.Remove(h);
                        if (h > bst.Keys.First())
                        {
                            answers.Add(new int[]{events[i].x, bst.Keys.First()});
                        }
                    }
                }
            }

            return answers;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1");
        }
    }
}
