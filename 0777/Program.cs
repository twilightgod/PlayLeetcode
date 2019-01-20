using System;
using System.Collections.Generic;

namespace _0777
{
    public class Solution
    {
        public bool CanTransform(string start, string end)
        {
            if (start.Replace("X", "") != end.Replace("X", ""))
            {
                return false;
            }

            var L1 = new List<int>();
            var L2 = new List<int>();
            var R1 = new List<int>();
            var R2 = new List<int>();

            for (var i = 0; i < start.Length; ++i)
            {
                if (start[i] == 'L')
                {
                    L1.Add(i);
                }
                else if (start[i] == 'R')
                {
                    R1.Add(i);
                }
            }

            for (var i = 0; i < end.Length; ++i)
            {
                if (end[i] == 'L')
                {
                    L2.Add(i);
                }
                else if (end[i] == 'R')
                {
                    R2.Add(i);
                }
            }

            for (var i = 0; i < L1.Count; ++i)
            {
                if (L1[i] < L2[i])
                {
                    return false;
                }
            }

            for (var i = 0; i < R1.Count; ++i)
            {
                if (R1[i] > R2[i])
                {
                    return false;
                }
            }

            return true;
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
