using System;
using System.Collections.Generic;

namespace _0318
{
    public class Solution
    {
        public int MaxProduct(string[] words)
        {
            var bins = new int[26];
            bins[0] = 1;
            for (var i = 1; i < 26; ++i)
            {
                bins[i] = bins[i - 1] << 1;
            }

            var wordList = new List<(int len, int hash)>();
            foreach (var word in words)
            {
                var hash = 0;
                foreach (var c in word)
                {
                    hash |= bins[(int)c - (int)'a'];
                }
                wordList.Add((word.Length, hash));
            }

            var answer = 0;
            for (var i = 0; i < wordList.Count; ++i)
            {
                for (var j = i + 1; j < wordList.Count; ++j)
                {
                    if ((wordList[i].hash & wordList[j].hash) == 0)
                    {
                        answer = Math.Max(answer, wordList[i].len * wordList[j].len);
                    }
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
