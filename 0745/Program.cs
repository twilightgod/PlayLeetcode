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
                    node.Children.TryAdd(c, new TrieNode());
                    node = node.Children[c];
                    node.WeightList.Add(i);
                }
                node = suffixTree;
                node.WeightList.Add(i);
                for (var j = words[i].Length - 1; j >= 0; --j)
                {
                    var c = words[i][j];
                    node.Children.TryAdd(c, new TrieNode());
                    node = node.Children[c];
                    node.WeightList.Add(i);
                }
            }
        }

        public int F(string prefix, string suffix)
        {
            var node = prefixTree;
            foreach (var c in prefix)
            {
                if (!node.Children.ContainsKey(c))
                {
                    return -1;
                }
                node = node.Children[c];
            }
            var prefixWeightList = node.WeightList;

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
            var suffixWeightList = node.WeightList;
            
            // weights are already sorted in asc
            for (int i1 = prefixWeightList.Count - 1, i2 = suffixWeightList.Count - 1; i1 >=0 && i2 >= 0;)
            {
                if (prefixWeightList[i1] == suffixWeightList[i2])
                {
                    return prefixWeightList[i1];
                }
                else if (prefixWeightList[i1] > suffixWeightList[i2])
                {
                    i1--;
                }
                else
                {
                    i2--;
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
