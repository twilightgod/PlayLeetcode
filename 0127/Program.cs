using System;
using System.Collections.Generic;
using System.Linq;

namespace _0127
{
    public class Solution
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var wordSet = new HashSet<string>();
            foreach (var word in wordList)
            {
                wordSet.Add(word);
            }
            if (!wordSet.Contains(endWord))
            {
                return 0;
            }
            var steps = new Dictionary<string, int>();
            var q = new Queue<string>();

            steps.Add(beginWord, 1);
            q.Enqueue(beginWord);

            while (q.Count > 0)
            {
                var word = q.Dequeue();
                if (word == endWord)
                {
                    return steps[word];
                }

                var charArray = word.ToCharArray();
                for (var i = 0; i < word.Length; ++i)
                {
                    var oldChar = charArray[i];
                    for (var c = 'a'; c <= 'z'; ++c)
                    {
                        charArray[i] = c;
                        var nextWord = new String(charArray);
                        if (!steps.ContainsKey(nextWord) && wordSet.Contains(nextWord))
                        {
                            steps[nextWord] = steps[word] + 1;
                            q.Enqueue(nextWord);
                            wordSet.Remove(nextWord);
                        }
                    }
                    charArray[i] = oldChar;
                }
            }

            return 0;
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
