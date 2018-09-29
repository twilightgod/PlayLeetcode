using System;
using System.Collections.Generic;
using System.Linq;

namespace _0681
{
    public class Solution
    {
        public string NextClosestTime(string time)
        {
            if (string.IsNullOrEmpty(time))
            {
                return time;
            }

            var digiset = new HashSet<int>();
            var digilist = new List<int>();
            var comboset = new HashSet<int>();
            var combolist = new List<int>();
            foreach (var c in time)
            {
                if (c != ':')
                {
                    digiset.Add((int)c - (int)'0');
                }
            }
            if (digiset.Count == 1)
            {
                return time;
            }
            digilist = digiset.ToList();
            foreach (var i in digilist)
            {
                foreach (var j in digilist)
                {
                    comboset.Add(i * 10 + j);
                }
            }
            combolist = comboset.ToList();
            combolist.Sort();

            var hh = time.Substring(0, 2);
            var mm = time.Substring(3, 2);
            // case1, get next larger minute
            var newmm = GetLarger(Int32.Parse(mm), 60, combolist);
            var newhh = String.Empty;
            if (!String.IsNullOrEmpty(newmm))
            {
                return hh + ":" + newmm;
            }
            else
            {
                // case2, get next larger hour, and smallest minute
                newhh = GetLarger(Int32.Parse(hh), 24, combolist);
                if (!String.IsNullOrEmpty(newhh))
                {
                    newmm = GetSmallest(60, combolist);
                    return newhh + ":" + newmm;
                }
                else
                {
                    // case3, get smallest hour (next day) and smallest minute
                    newhh = GetSmallest(24, combolist);
                    newmm = GetSmallest(60, combolist);
                    return newhh + ":" + newmm;
                }                
            }
        }

        private string GetLarger(int start, int limit, List<int> combolist)
        {
            foreach (var n in combolist)
            {
                if (n > start && n < limit)
                {
                    return n.ToString("D2");
                }
            }
            return null;
        }

        private string GetSmallest(int limit, List<int> combolist)
        {
            foreach (var n in combolist)
            {
                if (n < limit)
                {
                    return n.ToString("D2");
                }
            }
            return null;
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
