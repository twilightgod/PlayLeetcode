using System;
using System.Collections.Generic;
using System.Linq;

namespace _0212
{
    public class TrieNode
    {
        public string Word = null;
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>(); 
    }

    public class Solution
    {
        public IList<string> FindWords(char[,] board, string[] words)
        {
            // build Trie
            var root = new TrieNode();
            foreach (var word in words)
            {
                var p = root;
                foreach (var c in word)
                {
                    if (!p.Children.ContainsKey(c))
                    {
                        p.Children.Add(c, new TrieNode());
                    }
                    p = p.Children[c];
                }
                p.Word = word;
            }

            var answers = new HashSet<string>();
            var m = board.GetLength(0);
            var n = board.GetLength(1);

            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (root.Children.ContainsKey(board[i, j]))
                    {
                        var visited = new bool[m, n];
                        visited[i, j] = true;
                        DFS(board, m, n, i, j, visited, root.Children[board[i, j]], answers);
                    }
                }
            }
            return answers.ToList();
        }

        int[,] moves = new int[,]{{0,1}, {1,0}, {0, -1}, {-1, 0}};

        void DFS(char[,] board, int m, int n, int x, int y, bool[,] visited, TrieNode root, HashSet<string> answers)
        {
            if (root.Word != null)
            {
                answers.Add(root.Word);
            }

            for (var i = 0; i < 4; ++i)
            {
                var nextx = x + moves[i, 0];
                var nexty = y + moves[i, 1];
                if (nextx >= 0 && nextx < m && nexty >= 0 && nexty < n && !visited[nextx, nexty] && root.Children.ContainsKey(board[nextx, nexty]))
                {
                    visited[nextx, nexty] = true;
                    DFS(board, m, n, nextx, nexty, visited, root.Children[board[nextx, nexty]], answers);
                    visited[nextx, nexty] = false;
                }
            }
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
