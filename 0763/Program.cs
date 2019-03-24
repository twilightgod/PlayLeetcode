using System;
using System.Collections.Generic;

namespace _0763
{
    public class Solution
    {
        public IList<int> PartitionLabels(string S)
        {
            var answer = new List<int>();
            var lastPos = new Dictionary<char, int>();
            
            for (var i = 0; i < S.Length; ++i)
            {
                lastPos[S[i]] = i;
            }

            var start = 0;
            var end = 0;
            for (var i = 0; i < S.Length; ++i)
            {
                end = Math.Max(end, lastPos[S[i]]);
                if (i == end)
                {
                    answer.Add(end - start + 1);
                    start = i + 1;
                }
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
