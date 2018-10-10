using System;
using System.Collections.Generic;

namespace _0245
{
    public class Solution
    {
        public int ShortestWordDistance(string[] words, string word1, string word2)
        {
            var posList1 = new List<int>();
            var posList2 = new List<int>();

            for (var i = 0; i < words.Length; ++i)
            {
                if (word1 == words[i])
                {
                    posList1.Add(i);
                }
                if (word2 == words[i])
                {
                    posList2.Add(i);
                }
            }

            var p1 = 0;
            var p2 = 0;
            var answer = Int32.MaxValue;

            while (p1 < posList1.Count && p2 < posList2.Count)
            {
                var t = Math.Abs(posList1[p1] - posList2[p2]);
                if (t > 0)
                {
                    answer = Math.Min(answer, t);
                }

                if (posList1[p1] < posList2[p2])
                {
                    p1++;
                }
                else
                {
                    p2++;
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
