using System;
using System.Collections.Generic;


namespace _0399
{
    public class UnionFindData
    {
        public string Root{get;set;}
        public int Size{get;set;}
        public double Value{get;set;}
    }

    public class UnionFind
    {
        private Dictionary<string, UnionFindData> data = new Dictionary<string, UnionFindData>();

        public void TryCreateEntry(string entry)
        {
            if (!data.ContainsKey(entry))
            {
                data.Add(entry, new UnionFindData
                {
                    Root = entry,
                    Size = 1,
                    Value = 1d
                });
            }
        }

        public bool ContainsEntry(string entry)
        {
            return data.ContainsKey(entry);
        }

        public (string Root, double TotalValue) Find(string entry)
        {
            var current = entry;
            var totalValue = 1d;

            while (data[current].Root != current)
            {
                // path compression
                data[current].Value *= data[data[current].Root].Value;
                data[current].Root = data[data[current].Root].Root;
                current = data[current].Root;
                totalValue *= data[current].Value;
            }

            return (current, totalValue);
        }

        public void Union(string entry1, string entry2, double value_1_to_2)
        {
            var findResult1 = Find(entry1);
            var findResult2 = Find(entry2);

            if (findResult1.Root != findResult2.Root)
            {
                if (data[findResult1.Root].Size > data[findResult2.Root].Size)
                {
                    // merge 2 to 1
                    data[findResult1.Root].Size = data[findResult1.Root].Size + data[findResult2.Root].Size;
                    data[findResult2.Root].Root = findResult1.Root;
                    data[findResult2.Root].Value = findResult1.TotalValue / findResult2.TotalValue / value_1_to_2;
                }
                else
                {
                    // merge 1 to 2
                    data[findResult2.Root].Size = data[findResult1.Root].Size + data[findResult2.Root].Size;
                    data[findResult1.Root].Root = findResult2.Root;
                    data[findResult1.Root].Value = findResult2.TotalValue * value_1_to_2 / findResult1.TotalValue;
                }
            }
        }
    }

    public class Solution
    {
        public double[] CalcEquation(string[,] equations, double[] values, string[,] queries)
        {
            var uf = new UnionFind();

            for (var i = 0; i < equations.GetLength(0); ++i)
            {
                var entry1 = equations[i, 0];
                var entry2 = equations[i, 1];
                var value_1_to_2 = values[i];

                uf.TryCreateEntry(entry1);
                uf.TryCreateEntry(entry2);

                uf.Union(entry1, entry2, value_1_to_2);
            }

            var answers = new List<double>();

            for (var i = 0; i < queries.GetLength(0); ++i)
            {
                var entry1 = queries[i, 0];
                var entry2 = queries[i, 1];

                var answer = -1d;
                if (!uf.ContainsEntry(entry1) || !uf.ContainsEntry(entry2))
                {
                    
                }
                else
                {
                    var findResult1 = uf.Find(entry1);
                    var findResult2 = uf.Find(entry2);

                    if (findResult1.Root == findResult2.Root)
                    {
                        answer = findResult1.TotalValue / findResult2.TotalValue;
                    }
                }

                answers.Add(answer);
            }

            return answers.ToArray();
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
