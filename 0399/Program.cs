using System;
using System.Collections.Generic;


namespace _0399
{
    public class UnionFind
    {
        Dictionary<string, string> parent = null;
        Dictionary<string, int> rank = null;
        
        // value from current node to its parent
        Dictionary<string, double> value = null;

        public UnionFind()
        {
            parent = new Dictionary<string, string>();
            rank = new Dictionary<string, int>();
            value = new Dictionary<string, double>();
        }

        public bool Contains(string x)
        {
            return parent.ContainsKey(x);
        }

        public string Find(string x)
        {
            if (!Contains(x))
            {
                parent[x] = x;
                rank[x] = 0;
                value[x] = 1d;
            }

            // compression
            if (parent[x] != x)
            {
                var prepx = parent[x];
                parent[x] = Find(parent[x]);
                value[x] *= value[prepx];
            }

            return parent[x];
        }

        
        public void Union(string x, string y, double val)
        {
            var px = Find(x);
            var py = Find(y);

            if (px == py)
            {
                throw new Exception("duplicate relationship");
            }

            val = val * value[y] / value[x];

            // merge by rank
            if (rank[px] < rank[py])
            {
                parent[px] = py;
                value[px] = val;
            }
            else if (rank[px] > rank[py])
            {
                parent[py] = px;
                value[py] = 1 / val;
            }
            else
            {
                parent[px] = py;
                value[px] = val;
                rank[py]++;
            }
        }

        public double GetValue(string x, string y)
        {
            // don't exist
            if (!Contains(x) || !Contains(y))
            {
                return -1d;
            }

            var px = Find(x);
            var py = Find(y);
            
            // not in same set
            if (px != py)
            {
                return -1d;
            }

            return value[x] / value[y];
        }
    }

    public class Solution
    {
        public double[] CalcEquation(string[,] equations, double[] values, string[,] queries)
        {
            var uf = new UnionFind();

            for (var i = 0; i < equations.GetLength(0); ++i)
            {
                uf.Union(equations[i, 0], equations[i, 1], values[i]);
            }

            var answers = new List<double>();

            for (var i = 0; i < queries.GetLength(0); ++i)
            {
                answers.Add(uf.GetValue(queries[i, 0], queries[i, 1]));
            }

            return answers.ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().CalcEquation(new string[,]{{"a", "b"}, {"b", "c"}}, new double[]{2, 3}, new string[,]{{"a","c"}});
            Console.WriteLine("Hello World!");
        }
    }
}
