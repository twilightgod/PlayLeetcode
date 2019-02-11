using System;

namespace _0923
{
    public class Solution
    {
        public int ThreeSumMulti(int[] A, int target)
        {
            var c = new long[101];
            foreach (var a in A)
            {
                c[a]++;
            }
            var answer = 0l;
            var MOD = 1000000007l;
            for (var i = 0; i <= 100; ++i)
            {
                for (var j = i; j <= 100; ++j)
                {
                    var k = target - i - j;
                    if (j <= k && k >= 0 && k <= 100 && c[i] > 0 && c[j] > 0 && c[k] > 0)
                    {
                        if (i == j && j == k)
                        {
                            answer += c[i] * (c[i] - 1) * (c[i] - 2) / 6;
                        }
                        else if (i == j && j != k)
                        {
                            answer += c[i] * (c[i] - 1) / 2 * c[k];
                        }
                        else if (i != j && j == k)
                        {
                            answer += c[j] * (c[j] - 1) / 2 * c[i];
                        }
                        else
                        {
                            answer += c[i] * c[j] * c[k];
                        }
                        answer %= MOD;
                    }
                }
            }
            return (int)answer;
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
