using System;
using System.Collections.Generic;
using System.Linq;

namespace _0264
{
    public class Solution
    {
        public int NthUglyNumber(int n)
        {
            var pq = new SortedSet<int>();
            pq.Add(1);

            for (int i = 1; i <= n; ++i)
            {
                var num = pq.First();

                if (i == n)
                {
                    return num;
                }

                pq.Remove(num);

                checked
                {
                    try
                    {
                        pq.Add(2 * num);
                    }
                    catch (OverflowException ex)
                    {

                    }
                    try
                    {
                        pq.Add(3 * num);
                    }
                    catch (OverflowException ex)
                    {

                    }
                    try
                    {
                        pq.Add(5 * num);
                    }
                    catch (OverflowException ex)
                    {

                    }
                }
            }

            return 0;
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
