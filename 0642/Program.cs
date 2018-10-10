using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0642
{
    public class TrieNode
    {
        public SortedSet<(string s, int f)> TopSet = new SortedSet<(string s, int f)>(Comparer<(string s, int f)>.Create((a, b) => a.f == b.f ? a.s.CompareTo(b.s) : -a.f.CompareTo(b.f)));
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    }

    public class AutocompleteSystem
    {
        TrieNode root = null;
        TrieNode current = null;
        StringBuilder buffer = new StringBuilder();
        public Dictionary<string, int> Frequency = new Dictionary<string, int>();

        public AutocompleteSystem(string[] sentences, int[] times)
        {
            root = new TrieNode();
            for (var i = 0; i < sentences.Length; ++i)
            {
                InsertString(sentences[i], times[i]);
            }
        }

        public IList<string> Input(char c)
        {
            var answers = new List<string>();
            if (c == '#')
            {
                current = null;
                InsertString(buffer.ToString(), 1);
                buffer.Clear();
                return answers;
            }
            if (current == null)
            {
                current = root;
            }
            buffer.Append(c);
            if (!current.Children.ContainsKey(c))
            {
                current.Children.Add(c, new TrieNode());
            }
            current = current.Children[c];
            foreach (var pair in current.TopSet.Take(Math.Min(3, current.TopSet.Count)))
            {
                answers.Add(pair.s);
            }

            return answers;
        }

        private void InsertString(string s, int deltaf)
        {
            var node = root;
            var oldf = Frequency.GetValueOrDefault(s, 0);
            var f = oldf + deltaf;
            Frequency[s] = f;
            foreach (var c in s)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
                node.TopSet.Remove((s, oldf));
                node.TopSet.Add((s, f));
            }
        }
    }

    /**
     * Your AutocompleteSystem object will be instantiated and called as such:
     * AutocompleteSystem obj = new AutocompleteSystem(sentences, times);
     * IList<string> param_1 = obj.Input(c);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
