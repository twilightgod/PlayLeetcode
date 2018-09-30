using System;
using System.Collections.Generic;

namespace _0126
{
    public class Solution
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var steps = new Dictionary<string, int>();
            foreach (var word in wordList)
            {
                steps[word] = 0;
            }
            var answers = new List<IList<string>>();
            if (!steps.ContainsKey(endWord))
            {
                return answers;
            }
            steps[beginWord] = 1;
            
            var q = new Queue<(string word, List<string> answer)>();
            q.Enqueue((beginWord, new List<string>(){beginWord}));
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node.word == endWord)
                {
                    answers.Add(node.answer);
                    continue;
                }
                if (steps[endWord] > 0 && steps[node.word] >= steps[endWord])
                {
                    continue;
                }

                var charArray = node.word.ToCharArray();
                for (var i = 0; i < node.word.Length; ++i)
                {
                    var oldChar = charArray[i];
                    for (var c = 'a'; c <= 'z'; ++c)
                    {
                        charArray[i] = c;
                        var nextWord = new String(charArray);
                        if (steps.ContainsKey(nextWord) && (steps[nextWord] == 0 || steps[nextWord] == steps[node.word] + 1))
                        {
                            steps[nextWord] = steps[node.word] + 1;
                            var nextAnswer = new List<string>(node.answer);
                            nextAnswer.Add(nextWord);
                            q.Enqueue((nextWord, nextAnswer));
                        }
                    }
                    charArray[i] = oldChar;
                }
            }

            return answers;
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
