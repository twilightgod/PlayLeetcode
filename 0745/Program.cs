using System;
using System.Collections.Generic;

namespace _0745
{
    public class TrieNode
    {
        public List<int> WeightList = new List<int>();
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    }

    public class WordFilter
    {
        TrieNode suffixTree = new TrieNode();
        TrieNode prefixTree = new TrieNode();

        public WordFilter(string[] words)
        {
            for (var i = 0; i < words.Length; ++i)
            {
                var node = prefixTree;
                node.WeightList.Add(i);
                foreach (var c in words[i])
                {
                    if (!node.Children.ContainsKey(c))
                    {
                        node.Children.Add(c, new TrieNode());
                    }
                    node = node.Children[c];
                    node.WeightList.Add(i);
                }
                node = suffixTree;
                node.WeightList.Add(i);
                for (var j = words[i].Length - 1; j >= 0; --j)
                {
                    var c = words[i][j];
                    if (!node.Children.ContainsKey(c))
                    {
                        node.Children.Add(c, new TrieNode());
                    }
                    node = node.Children[c];
                    node.WeightList.Add(i);
                }
            }
        }

        public int F(string prefix, string suffix)
        {
            List<int> prefixWordList = null;
            List<int> suffixWordList = null;
            var node = prefixTree;
            foreach (var c in prefix)
            {
                if (!node.Children.ContainsKey(c))
                {
                    return -1;
                }
                node = node.Children[c];
            }
            prefixWordList = node.WeightList;

            node = suffixTree;
            for (var i = suffix.Length - 1; i >= 0; --i)
            {
                var c = suffix[i];
                if (!node.Children.ContainsKey(c))
                {
                    return -1;
                }
                node = node.Children[c];
            }
            suffixWordList = node.WeightList;

            if (suffixWordList.Count == 0 || prefixWordList.Count == 0)
            {
                return -1;
            }

            var p1 = prefixWordList.Count - 1;
            var p2 = suffixWordList.Count - 1;
            while (p1 >= 0 && p2 >= 0)
            {
                if (prefixWordList[p1] == suffixWordList[p2])
                {
                    return prefixWordList[p1];
                }
                else if (prefixWordList[p1] > suffixWordList[p2])
                {
                    p1--;
                }
                else
                {
                    p2--;
                }
            }

            return -1;
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
