using System;
using System.Collections.Generic;
using System.Linq;

namespace _0119
{
    public class Solution
    {
        public IList<int> GetRow(int rowIndex)
        {
            var ans = Enumerable.Repeat(0, rowIndex + 1).ToList();

            for (var i = 0; i <= rowIndex; ++i)
            {
                for (var j = i; j >= 0; --j)
                {
                    if (j == 0 || j == i)
                    {
                        ans[j] = 1;
                    }
                    else
                    {
                        ans[j] += ans[j - 1];
                    }
                }
            }

            return ans;
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
