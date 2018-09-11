using System;
using System.Collections.Generic;

namespace _0815
{
    public class Solution
    {
        public int NumBusesToDestination(int[][] routes, int S, int T)
        {
            var steps = new Dictionary<int, int>();
            var routeByStop = new Dictionary<int, List<int>>();

          for (var i = 0; i < routes.Length; ++i)
            {
               foreach (var stop in routes[i])
                {
                    steps[stop] = -1;
                    if (!routeByStop.ContainsKey(stop))
                    {
                        routeByStop.Add(stop, new List<int>());
                    }
                    routeByStop[stop].Add(i);
                }
            }

            var q = new Queue<int>();
            q.Enqueue(S);
            steps[S] = 0;

            while (q.Count > 0)
            {
                var stop = q.Dequeue();
                if (stop == T)
                {
                    break;
                }

                foreach (var route in routeByStop[stop])
                {
                    foreach (var destinationStop in routes[route])
                    {
                        if (steps[destinationStop] == -1)
                        {
                            steps[destinationStop] = steps[stop] + 1;
                            q.Enqueue(destinationStop);
                        }
                    }
                    // one route will only be checked once, since all stops in this route will be added to queue at the same time, huge performance improve here
                    routes[route] = new int[]{};
                }
            }

            return steps[T];
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
