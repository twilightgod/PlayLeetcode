using System;

namespace _0079
{
    public class Solution
    {
        public bool Exist(char[,] board, string word)
        {
            var len0 = board.GetLength(0);
            var len1 = board.GetLength(1);
            var visited = new bool[len0, len1];

            return FindWord(len0, len1, 0, 0, board, visited, word, 0);
        }

        private bool FindWord(int len0, int len1, int x, int y, char[,] board, bool[,] visited, string word, int depth)
        {
            if (depth == 0)
            {
                for (var nx = 0; nx < len0; ++nx)
                {
                    for (var ny = 0; ny < len1; ++ny)
                    {
                        if (FindWordInternal(len0, len1, nx, ny, board, visited, word, depth))
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                var moves = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
                for (var i = 0; i < 4; ++i)
                {
                    var nx = x + moves[i, 0];
                    var ny = y + moves[i, 1];

                    if (FindWordInternal(len0, len1, nx, ny, board, visited, word, depth))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool FindWordInternal(int len0, int len1, int nx, int ny, char[,] board, bool[,] visited, string word, int depth)
        {
            if (nx >= 0 && nx < len0 && ny >= 0 && ny < len1)
            {
                if (!visited[nx, ny] && word[depth] == board[nx, ny])
                {
                    if (depth == word.Length - 1)
                    {
                        return true;
                    }

                    visited[nx, ny] = true;
                    if (FindWord(len0, len1, nx, ny, board, visited, word, depth + 1))
                    {
                        return true;
                    }
                    visited[nx, ny] = false;
                }
            }

            return false;
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
