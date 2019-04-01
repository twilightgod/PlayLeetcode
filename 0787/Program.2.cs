using System;
using System.Collections.Generic;
using System.Linq;

namespace _0787_2
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
            K++;
            while (K-- > 0)
            {
                var updated = false;
                var new_dis = new int[n];
                for (var i = 0; i < n; ++i)
                {
                    new_dis[i] = dis[i];
                }

                for (var i = 0; i < flights.Length; ++i)
                {
                    var from = flights[i][0];
                    var to = flights[i][1];
                    var cost = flights[i][2];
                    if (dis[from] != Int32.MaxValue && new_dis[to] > dis[from] + cost)
                    {
                        new_dis[to] = dis[from] + cost;
                        updated = true;
                    }
                }
                if (!updated)
                {
                    break;
                }
                dis = new_dis;
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
