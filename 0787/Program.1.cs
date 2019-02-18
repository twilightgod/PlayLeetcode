using System;
using System.Collections.Generic;
using System.Linq;

namespace _0787_1
{
    // Bellman-Ford
    public class Solution
    {
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            var dis = new int[n];
            for (var i = 0; i < n; ++i)
            {
                dis[i] = Int32.MaxValue;
            }
            dis[src] = 0;
            for (var i = 0; i < K + 1; ++i)
            {
                var updated = false;
                var dis_next = new int[n];
                for (var j = 0; j < n; ++j)
                {
                    dis_next[j] = dis[j];
                }
                for (var j = 0; j < flights.GetLength(0); ++j)
                {
                    var from = flights[j][0];
                    var to = flights[j][1];
                    var w = flights[j][2];
                    if (dis[from] != Int32.MaxValue && dis_next[to] > dis[from] + w)
                    {
                        dis_next[to] = dis[from] + w;
                        updated = true;
                    }
                }
                if (!updated)
                {
                    break;
                }
                dis = dis_next;
            }
            return dis[dst] == Int32.MaxValue ? -1 : dis[dst];
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
