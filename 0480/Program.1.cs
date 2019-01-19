using System;
using System.Collections.Generic;
using System.Linq;

namespace _0480_1
{
    public class Solution
    {
        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            if (nums == null)
            {
                return null;
            }
            
            /* Hard to implement BST solution in C#, since thers's no Enumerator.MovePrevious 
            var bst = new SortedSet<(int, int)>();
            // insert first k
            for (var i = 0; i < k; ++i)
            {
                bst.Add((nums[i], i));
            }
            // get left-median, it's before first element at begining
            var mid = bst.GetEnumerator();
            for (var i = 0; i <= (k - 1) / 2; ++i)
            {
                mid.MoveNext();
            }
            var answer = new List<double>();
            // generate answer
            for (var i = k; i <= nums.Length; ++i)
            {
                // loop one more time in order to make code clean
                answer.Add(k % 2 == 0 ? mid.Current.Item1
            }
            */
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
