using System;
using System.Collections.Generic;

namespace _0211
{
    public class TrieNode
    {
        public bool IsWord = false;
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    }

    public class WordDictionary
    {
        private TrieNode root = new TrieNode();

        /** Initialize your data structure here. */
        public WordDictionary()
        {

        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            var node = root;
            foreach (var c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children.Add(c, new TrieNode());
                }
                node = node.Children[c];
            }
            node.IsWord = true;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return DFS(word, 0, root);
        }

        private bool DFS(string s, int depth, TrieNode node)
        {
            if (depth == s.Length)
            {
                return node.IsWord;
            }
            if (s[depth] == '.')
            {
                foreach (var child in node.Children.Values)
                {
                    if (DFS(s, depth + 1, child))
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (!node.Children.ContainsKey(s[depth]))
                {
                    return false;
                }
                return DFS(s, depth + 1, node.Children[s[depth]]);
            }
            return false;
        }
    }

    /**
     * Your WordDictionary object will be instantiated and called as such:
     * WordDictionary obj = new WordDictionary();
     * obj.AddWord(word);
     * bool param_2 = obj.Search(word);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
