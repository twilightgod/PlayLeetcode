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
            // precompute match chars between all pairs
            var n = wordlist.Length;
            var matchCount = new int[n, n];
            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    matchCount[i, j] = GetMatchCount(wordlist[i], wordlist[j]);
                }
            }

            // add all words to candidate list at begining 
            var candidateList = new List<int>();
            for (var i = 0; i < n; ++i)
            {
                candidateList.Add(i);
            }

            while (true)
            {
                // get candidate based on min zero match count to avoid worst case
                // think about choose one word with max zero match count 
                // if it's not the answer, we reduce the candidateList size slowly
                var candidate = -1;
                var minZeroMatchCount = Int32.MaxValue;
                foreach (var idx1 in candidateList)
                {
                    var zeroMatchCount = 0;
                    foreach (var idx2 in candidateList)
                    {
                        if (matchCount[idx1, idx2] == 0)
                        {
                            zeroMatchCount++;
                        }
                    }
                    if (minZeroMatchCount > zeroMatchCount)
                    {
                        minZeroMatchCount = zeroMatchCount;
                        candidate = idx1;
                    }
                }

                var result = master.guess(wordlist[candidate]);
                // found answer
                if (result == 6)
                {
                    break;
                }

                // didn't find answer, filter candidateList based on matched result
                var newCandidateList = new List<int>();
                foreach (var idx in candidateList)
                {
                    if (matchCount[idx, candidate] == result)
                    {
                        newCandidateList.Add(idx);
                    }
                }
                candidateList = newCandidateList;
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
