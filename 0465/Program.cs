using System;
using System.Collections.Generic;

namespace _0465
{
    public class Solution
    {
        public int MinTransfers(int[,] transactions)
        {
            var balance = new Dictionary<int, int>();
            for (var i = 0; i < transactions.GetLength(0); ++i)
            {
                balance[transactions[i, 0]] = balance.GetValueOrDefault(transactions[i, 0], 0) + transactions[i, 2];
                balance[transactions[i, 1]] = balance.GetValueOrDefault(transactions[i, 1], 0) - transactions[i, 2];
            }
            var debt = new List<int>();
            foreach (var b in balance.Values)
            {
                if (b != 0)
                {
                    debt.Add(b);
                }
            }
            debt.Sort();
            
            return DFS(0, debt);
        }

        private int DFS(int depth, List<int> debt)
        {
            // end
            if (depth == debt.Count)
            {
                return 0;
            }
            // depth-th already paid off
            if (debt[depth] == 0)
            {
                return DFS(depth + 1, debt);
            }
            // try to let i-th pay off depth-th
            var times = Int32.MaxValue;
            for (var i = depth + 1; i < debt.Count; ++i)
            {
                if (debt[i] != 0 && Math.Sign(debt[depth]) * Math.Sign(debt[i]) < 0)
                {
                    debt[i] += debt[depth];
                    times = Math.Min(times, DFS(depth + 1, debt) + 1);
                    debt[i] -= debt[depth];
                }
            }
            return times;
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
