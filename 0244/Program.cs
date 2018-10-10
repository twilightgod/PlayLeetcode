using System;
using System.Collections.Generic;

namespace _0244
{
    public class WordDistance
    {
        private Dictionary<string, List<int>> posList = new Dictionary<string, List<int>>();
        private Dictionary<(string, string), int> answers= new Dictionary<(string, string), int>();

        public WordDistance(string[] words)
        {
            for (var i = 0; i < words.Length; ++i)
            {
                if (!posList.ContainsKey(words[i]))
                {
                    posList.Add(words[i], new List<int>());
                }
                posList[words[i]].Add(i);
            }
        }

        public int Shortest(string word1, string word2)
        {
            if (word1.CompareTo(word2) > 0)
            {
                var t = word1;
                word1 = word2;
                word2 = t;
            }

            if (answers.ContainsKey((word1, word2)))
            {
                return answers[(word1, word2)];
            }

            var p1 = 0;
            var p2 = 0;
            var answer = Int32.MaxValue;

            while (p1 < posList[word1].Count && p2 < posList[word2].Count)
            {
                answer = Math.Min(answer, Math.Abs(posList[word1][p1] - posList[word2][p2]));
                if (posList[word1][p1] < posList[word2][p2])
                {
                    p1++;
                }
                else
                {
                    p2++;
                }
            }

            answers.Add((word1, word2), answer);
            return answer;
        }
    }

    /**
     * Your WordDistance object will be instantiated and called as such:
     * WordDistance obj = new WordDistance(words);
     * int param_1 = obj.Shortest(word1,word2);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
