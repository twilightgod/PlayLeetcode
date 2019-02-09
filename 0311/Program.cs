using System;
using System.Collections.Generic;

namespace _0311
{
    public class Solution
    {
        public int[,] Multiply(int[,] A, int[,] B)
        {
            var sparseA = new Dictionary<int, Dictionary<int, int>>();
            var sparseB = new Dictionary<int, Dictionary<int, int>>();

            var m = A.GetLength(0);
            var n = A.GetLength(1);
            var k = B.GetLength(1);

            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (A[i, j] != 0)
                    {
                        sparseA.TryAdd(i, new Dictionary<int, int>());
                        sparseA[i][j] = A[i, j];
                    }
                }
            }

            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < k; ++j)
                {
                    if (B[i, j] != 0)
                    {
                        sparseB.TryAdd(j, new Dictionary<int, int>());
                        sparseB[j][i] = B[i, j];
                    }
                }
            }

            var sparseC = new Dictionary<int, Dictionary<int, int>>();

            foreach (var kvpA in sparseA)
            {
                foreach (var kvpB in sparseB)
                {
                    sparseC.TryAdd(kvpA.Key, new Dictionary<int, int>());
                    var sum = 0;
                    foreach (var innerKvpA in kvpA.Value)
                    {
                        if (kvpB.Value.ContainsKey(innerKvpA.Key))
                        {
                            sum += innerKvpA.Value * kvpB.Value[innerKvpA.Key];
                        }
                    }
                    sparseC[kvpA.Key][kvpB.Key] = sum;
                }
            }

            var C = new int[m, k];
            foreach (var kvpC in sparseC)
            {
                foreach (var innerKvpC in kvpC.Value)
                {
                    C[kvpC.Key, innerKvpC.Key] = innerKvpC.Value;
                }
            }

            return C;
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
