using System;
using System.Collections.Generic;

namespace _0300
{
    public class Solution
    {
        public int LengthOfLIS(int[] nums)
        {
            var f = new List<int>();
            foreach (var num in nums)
            {
                if (f.Count == 0)
                {
                    f.Add(num);
                }
                else
                {
                    var pos = f.BinarySearch(num);
                    if (pos < 0)
                    {
                        pos = ~pos;
                        if (pos == f.Count)
                        {
                            f.Add(num);
                        }
                        else
                        {
                            f[pos] = num;
                        }
                    }
                }
            }
            return f.Count;
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
