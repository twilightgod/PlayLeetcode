using System;
using System.Collections.Generic;
using System.Linq;

namespace _0499
{
    public class Solution
    {
        public string FindShortestWay(int[,] maze, int[] ball, int[] hole)
        {
            var moves = new int[,] { { 0, 1 }, { 1, 0 }, { -1, 0 }, { 0, -1 } };
            var directions = new char[] { 'r', 'd', 'u', 'l' };
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
            var sequence = new string[m, n];
            distance[ball[0], ball[1]] = 1;
            q.Add((1, ball[0], ball[1]));
            sequence[ball[0], ball[1]] = String.Empty;
            while (q.Count > 0)
            {
                var node = q.First();
                q.Remove(node);
                //Console.WriteLine("pop" + node.x + " " + node.y);
                if (node.x == hole[0] && node.y == hole[1])
                {
                    return sequence[hole[0], hole[1]];
                }
                // optimization, if current node has a better distance (found a better way to get here after pushing this node in), just ignore it
                if (node.d > distance[node.x, node.y])
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
                        if (newx == -1 || newy == -1 || newx == m || newy == n || maze[newx, newy] == 1 || newx == hole[0] && newy == hole[1])
                        {
                            // if it's not hole (wall), move back 1 step
                            if (!(newx == hole[0] && newy == hole[1]))
                            {
                                d--;
                                newx -= moves[i, 0];
                                newy -= moves[i, 1];
                            }
                            //Console.WriteLine(newx + " " + newy);

                            // if it's never visited or can be improved
                            if (distance[newx, newy] == 0 || d <= distance[newx, newy])
                            {
                                // check if it's same distance but with better (smaller in dictionary order) sequence, update the sequence
                                // don't need to push it again, since it's still in the heap
                                var newSequence = sequence[node.x, node.y] + directions[i];
                                if (d == distance[newx, newy])
                                {
                                    if (newSequence.CompareTo(sequence[newx, newy]) < 0)
                                    {
                                        sequence[newx, newy] = newSequence;
                                    }
                                }
                                // push the node into heap
                                else
                                {
                                    distance[newx, newy] = d;
                                    sequence[newx, newy] = newSequence;
                                    q.Add((d, newx, newy));
                                }
                            }
                            break;
                        }
                    }
                }
            }
            return "impossible";
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
