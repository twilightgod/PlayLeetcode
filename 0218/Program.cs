using System;
using System.Collections.Generic;
using System.Linq;

namespace _0218
{
    public class Solution
    {
        public IList<int[]> GetSkyline(int[,] buildings)
        {
            var events = new List<(int x, int h, int idx)>();
            var n = buildings.GetLength(0);

            // enter event comes first when we have some events with same x coodination
            for (var i = 0; i < n; ++i)
            {
                events.Add((buildings[i, 0], -buildings[i, 2], i));
                events.Add((buildings[i, 1], buildings[i, 2], i));
            }

            events.Sort();

            var answers = new List<int[]>();

            // SorterSet doesn't support duplicate elements, use (height, index) to walk around
            // h is -height to leverage default comparer 
            var bst = new SortedSet<(int h, int idx)>();

            // ground
            bst.Add((0, -1));

            for (var i = 0; i < (n << 1); ++i)
            {
                var (x, h, idx) = events[i];
                var isEnterEvnet = h < 0;
                h = Math.Abs(h);

                // if it's entering a new building
                if (isEnterEvnet)
                {
                    // if new height is higher than current highest, generate one answer
                    if (h > -bst.First().h)
                    {
                        answers.Add(new int[] { x, h });
                    }

                    // add 
                    bst.Add((-h, idx));
                }
                // leaving a building
                else
                {
                    // remove first
                    bst.Remove((-h, idx));

                    // if the removed one is higher than current highest, generate one answer
                    if (h > -bst.First().h)
                    {
                        answers.Add(new int[] { x, -bst.First().h });
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
