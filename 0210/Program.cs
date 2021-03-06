﻿using System;
using System.Collections.Generic;

namespace _0210
{
    public class Solution
    {
        public int[] FindOrder(int numCourses, int[,] prerequisites)
        {
            var indegree = new int[numCourses];
            var edge = new HashSet<int>[numCourses];
            for (var i = 0; i < numCourses; ++i)
            {
                edge[i] = new HashSet<int>();
            }

            for (var i = 0; i < prerequisites.GetLength(0); ++i)
            {
                var c1 = prerequisites[i, 1];
                var c2 = prerequisites[i, 0];
                if (edge[c1].Add(c2))
                {
                    indegree[c2]++;
                }
            }

            var learned = 0;
            var order = new int[numCourses];
            var zeroIndegree = new Queue<int>();
            for (var i = 0; i < numCourses; ++i)
            {
                if (indegree[i] == 0)
                {
                    zeroIndegree.Enqueue(i);
                }
            }

            while (zeroIndegree.Count > 0)
            {
                var c = zeroIndegree.Dequeue();
                order[learned++] = c;
                foreach (var c2 in edge[c])
                {
                    if (--indegree[c2] == 0)
                    {
                        zeroIndegree.Enqueue(c2);
                    }
                }
            }

            return learned == numCourses ? order : new int[0];
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
