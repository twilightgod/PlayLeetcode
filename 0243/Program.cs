using System;
using System.Collections.Generic;

namespace _0243
{
    public class Solution
    {
        public int ShortestDistance(string[] words, string word1, string word2)
        {
            var posList1 = new List<int>();
            var posList2 = new List<int>();

            for (var i = 0; i < words.Length; ++i)
            {
                if (words[i] == word1)
                {
                    posList1.Add(i);
                }
                else if (words[i] == word2)
                {
                    posList2.Add(i);
                }
            }

            var p1 = 0;
            var p2 = 0;
            var answer = Int32.MaxValue;
            while (p1 < posList1.Count && p2 < posList2.Count)
            {
                answer = Math.Min(answer, Math.Abs(posList1[p1] - posList2[p2]));
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
