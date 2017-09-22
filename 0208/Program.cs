﻿using System;
using System.Collections.Generic;

namespace _0208
{
    public class Trie
    {

        /** Initialize your data structure here. */
        class Node
        {
            public Dictionary<char, Node> Children {set;get;} = new Dictionary<char, Node>();
            public bool IsWord {set;get;} = false;
        }

        private Node root = null;

        public Trie()
        {
            root = new Node();    
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var current = root;

            foreach (var c in word)
            {
                if (!current.Children.ContainsKey(c))
                {
                    current.Children.Add(c, new Node());
                }
                current = current.Children[c];
            }

            current.IsWord = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var current = root;

            foreach (var c in word)
            {
                if (!current.Children.ContainsKey(c))
                {
                    return false;
                }
                current = current.Children[c];
            }
            
            return current.IsWord;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var current = root;

            foreach (var c in prefix)
            {
                if (!current.Children.ContainsKey(c))
                {
                    return false;
                }
                current = current.Children[c];
            }

            return true;
        }
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */

    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Trie();
            tree.Insert("abc");
            tree.Insert("abc");
            tree.Insert("abc");
        }
    }
}
