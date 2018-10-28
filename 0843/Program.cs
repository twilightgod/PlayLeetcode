using System;
using System.Collections.Generic;

namespace _0843
{
    /**
 * // This is the Master's API interface.
 * // You should not implement it, or speculate about its implementation
 * class Master {
 *     public int Guess(string word);
 * }
 */
    class Solution
    {
        public void FindSecretWord(string[] wordlist, Master master)
        {
            var candidateWords = new List<string>(wordlist);
            while (true)
            {
                var candidateWord = String.Empty;
                var candidateCount = Int32.MaxValue;
                foreach (var word in candidateWords)
                {
                    var zeroMatchCount = 0;
                    foreach (var word2 in candidateWords)
                    {
                        if (0 == GetMatchCount(word, word2))
                        {
                            zeroMatchCount++;
                        }
                    }
                    if (candidateCount > zeroMatchCount)
                    {
                        candidateCount = zeroMatchCount;
                        candidateWord = word;
                    }
                }
                var matchCount = master.guess(candidateWord);
                if (matchCount == 6)
                {
                    break;
                }
                var newCandidateWords = new List<string>();
                foreach (var word in candidateWords)
                {
                    if (GetMatchCount(word, candidateWord) == matchCount)
                    {
                        newCandidateWords.Add(word);
                    }
                }
                candidateWords = newCandidateWords;
            }
        }

        private int GetMatchCount(string s1, string s2)
        {
            var counter = 0;
            for (var i = 0; i < s1.Length; ++i)
            {
                if (s1[i] == s2[i])
                {
                    counter++;
                }
            }
            return counter;
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
