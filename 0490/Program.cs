using System;
using System.Collections.Generic;

namespace _0490
{
    public class Solution
    {
        public bool HasPath(int[,] maze, int[] start, int[] destination)
        {
            var moves = new int[,] {{0, 1}, {1, 0}, {-1, 0}, {0, -1}};
            var q = new Queue<(int x, int y)>();
            var m = maze.GetLength(0);
            var n = maze.GetLength(1);
            var visited = new bool[m, n];
            visited[start[0], start[1]] = true;
            q.Enqueue((start[0], start[1]));
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                Console.WriteLine(node.x + " " + node.y);
                if (node.x == destination[0] && node.y == destination[1])
                {
                    return true;
                }
                for (var i = 0; i < 4; ++i)
                {
                    var newx = node.x;
                    var newy = node.y;
                    while (true)
                    {
                        newx += moves[i, 0];
                        newy += moves[i, 1];
                        if (newx < -1 || newy < -1 || newx > m || newy > n)
                        {
                            break;
                        }
                        else if (newx == -1 || newy == -1 || newx == m || newy == n || maze[newx, newy] == 1)
                        {
                            newx -= moves[i, 0];
                            newy -= moves[i, 1];
                            if (!visited[newx, newy])
                            {
                                visited[newx, newy] = true;
                                q.Enqueue((newx, newy));
                            }
                            break;
                        }
                    }
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
