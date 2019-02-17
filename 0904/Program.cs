using System;
using System.Collections.Generic;

namespace _0904
{
    public class Solution
    {
        public int TotalFruit(int[] tree)
        {
            var limit = 2;
            var l = 0;
            var fruitMap = new Dictionary<int, int>();
            var answer = 0;

            for (var r = 0; r < tree.Length; ++r)
            {
                fruitMap[tree[r]] = fruitMap.GetValueOrDefault(tree[r], 0) + 1;
                while (fruitMap.Count > limit)
                {
                    if (--fruitMap[tree[l]] == 0)
                    {
                        fruitMap.Remove(tree[l]);
                    }
                    l++;
                }
                answer = Math.Max(answer, r - l + 1);
            }

            return answer;
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
