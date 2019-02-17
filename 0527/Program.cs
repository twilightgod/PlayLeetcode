using System;
using System.Collections.Generic;

namespace _0527
{
    public class TrieNode
    {
        public int WordCount = 0;
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    }

    public class Solution
    {
        public IList<string> WordsAbbreviation(IList<string> dict)
        {
            // word -> abb mapping, to make answer in order
            var mapping = new Dictionary<string, string>();

            // group by first char, last char and length
            var groups = new Dictionary<(char, char, int), List<string>>();
            foreach (var word in dict)
            {
                var key = (word[0], word[word.Length - 1], word.Length);
                if (!groups.ContainsKey(key))
                {
                    groups[key] = new List<string>();
                }
                groups[key].Add(word);
            }

            foreach (var wordList in groups.Values)
            {
                var root = BuildTrie(wordList);
                foreach (var word in wordList)
                {
                    var abb = GetAbb(root, word);
                    mapping[word] = abb;
                }
            }

            var answer = new List<string>();
            foreach (var word in dict)
            {
                answer.Add(mapping[word]);
            }

            return answer;
        }

        private TrieNode BuildTrie(List<string> wordList)
        {
            var root = new TrieNode();

            foreach (var word in wordList)
            {
                var node = root;
                foreach (var c in word)
                {
                    if (!node.Children.ContainsKey(c))
                    {
                        node.Children.Add(c, new TrieNode());
                    }
                    node = node.Children[c];
                    node.WordCount++;
                }
            }
            
            return root;
        }

        private string GetAbb(TrieNode root, string word)
        {
            var node = root;
            var len = word.Length;
            for (var i = 0; i < len; ++i)
            {
                node = node.Children[word[i]];
                if (node.WordCount == 1)
                {
                    var abb = word.Substring(0, i + 1) + (len - 1 - (i + 1)).ToString() + word[len - 1];
                    if (abb.Length >= len)
                    {
                        abb = word;
                    }
                    return abb;
                }
            }
            return word;
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
