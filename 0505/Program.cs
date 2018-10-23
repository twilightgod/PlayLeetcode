using System;
using System.Collections.Generic;
using System.Linq;

namespace _0505
{
    public class Solution
    {
        public int ShortestDistance(int[,] maze, int[] start, int[] destination)
        {
            var moves = new int[,] { { 0, 1 }, { 1, 0 }, { -1, 0 }, { 0, -1 } };
            var q = new SortedSet<(int d, int x, int y)>(Comparer<(int d, int x, int y)>.Create(
                (a, b) => 
                a.d == b.d ? 
                    a.x == b.x ? 
                        a.y.CompareTo(b.y)
                    : a.x.CompareTo(b.x)
                : a.d.CompareTo(b.d)
            ));
            var m = maze.GetLength(0);
            var n = maze.GetLength(1);
            var distance = new int[m, n];
            distance[start[0], start[1]] = 1;
            q.Add((1, start[0], start[1]));
            while (q.Count > 0)
            {
                var node = q.First();
                q.Remove(node);
                //Console.WriteLine(node.x + " " + node.y);
                if (node.x == destination[0] && node.y == destination[1])
                {
                    return node.d - 1;
                }
                if (node.d < distance[node.x, node.y])
                {
                    continue;
                }
                for (var i = 0; i < 4; ++i)
                {
                    var newx = node.x;
                    var newy = node.y;
                    var d = node.d;
                    while (true)
                    {
                        d++;
                        newx += moves[i, 0];
                        newy += moves[i, 1];
                        if (newx == -1 || newy == -1 || newx == m || newy == n || maze[newx, newy] == 1)
                        {
                            d--;
                            newx -= moves[i, 0];
                            newy -= moves[i, 1];
                            if (distance[newx, newy] == 0 || d < distance[newx, newy])
                            {
                                distance[newx, newy] = d;
                                q.Add((d, newx, newy));
                            }
                            break;
                        }
                    }
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
