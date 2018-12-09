using System;
using System.Collections.Generic;
using System.Linq;

namespace _0658
{
    public class Solution
    {
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            var input = arr.ToList();
            var pos = input.BinarySearch(x);
            if (pos < 0)
            {
                pos = ~pos;
                // if x is greater than all elements, decrease pos
                if (pos == input.Count)
                {
                    pos--;
                }
                // compare element smaller than x and larger than x, determind the starting point
                if (pos - 1 >= 0 && input[pos] - x >= x - input[pos - 1])
                {
                    pos--;
                }
            }

            var l = pos;
            var r = pos;
            while (r - l + 1 < k)
            {
                if (l == 0)
                {
                    r++;
                }
                else if (r == input.Count - 1)
                {
                    l--;
                }
                else if (x - input[l - 1] <= input[r + 1] - x)
                {
                    l--;
                }
                else
                {
                    r++;
                }
            }
            return input.GetRange(l, k);
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
