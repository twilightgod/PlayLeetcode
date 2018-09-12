using System;
using System.Collections.Generic;

namespace _0305
{
    public class UnionFindData
    {
        public Point Root { get; set; }
        public int Size { get; set; }
    }

    public class Point
    {
        public int X {get;set;}
        public int Y {get;set;}

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        override public bool Equals(object obj)
        {
            var p = (Point)obj;
            return this.X == p.X && this.Y == p.Y;
        }

        override public int GetHashCode()
        {
            return X ^ Y;
        }
    }

    public class UnionFind
    {
        private Dictionary<Point, UnionFindData> data = new Dictionary<Point, UnionFindData>();
        public int SetsCount {get;private set;} = 0;

        public void TryCreateEntry(Point entry)
        {
            if (!data.ContainsKey(entry))
            {
                data.Add(entry, new UnionFindData
                {
                    Root = entry,
                    Size = 1,
                });

                SetsCount++;
            }
        }

        public bool ContainsEntry(Point entry)
        {
            return data.ContainsKey(entry);
        }

        public Point Find(Point entry)
        {
            var current = entry;

            while (data[current].Root != current)
            {
                // path compression
                data[current].Root = data[data[current].Root].Root;
                current = data[current].Root;
            }

            return current;
        }

        public void Union(Point entry1, Point entry2)
        {
            var findResult1 = Find(entry1);
            var findResult2 = Find(entry2);

            if (findResult1 != findResult2)
            {
                if (data[findResult1].Size > data[findResult2].Size)
                {
                    // merge 2 to 1
                    data[findResult1].Size = data[findResult1].Size + data[findResult2].Size;
                    data[findResult2].Root = findResult1;
                }
                else
                {
                    // merge 1 to 2
                    data[findResult2].Size = data[findResult1].Size + data[findResult2].Size;
                    data[findResult1].Root = findResult2;
                }
                
                SetsCount--;
            }
        }
    }

    public class Solution
    {
        public IList<int> NumIslands2(int m, int n, int[,] positions)
        {
            var move = new int[,] {{0, 1}, {1, 0}, {-1, 0}, {0, -1}};
            var answers = new List<int>();
            var uf = new UnionFind();

            for (var i = 0; i < positions.GetLength(0); ++i)
            {
                var p = new Point(positions[i, 0], positions[i, 1]);
                uf.TryCreateEntry(p);
                for (var j = 0; j < 4; ++j)
                {
                    var p2 = new Point(p.X + move[j, 0], p.Y + move[j, 1]);

                    if (p2.X >= 0 && p2.Y >= 0 && p2.X < m && p2.Y < n)
                    {
                        if (uf.ContainsEntry(p2))
                        {
                            uf.Union(p, p2);
                        }
                    }
                }

                answers.Add(uf.SetsCount);
            }

            return answers;
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
