using System;
using System.Collections.Generic;

namespace _0118
{
    public class Solution
    {
        public IList<IList<int>> Generate(int numRows)
        {
            var ans = new List<IList<int>>();

            for (var i = 0; i < numRows; ++i)
            {
                ans.Add(new List<int>());
                for (var j = 0; j <= i; ++j)
                {
                    if (j == 0 || j == i)
                    {
                        ans[i].Add(1);
                    }
                    else
                    {
                        ans[i].Add(ans[i - 1][j - 1] + ans[i - 1][j]);
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
