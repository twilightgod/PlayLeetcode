using System;

namespace _0837
{
    public class Solution
    {
        public double New21Game(int N, int K, int W)
        {
            if (N >= K + W)
            {
                return 1d;
            }
            // f[i] means the probability to get point i
            // f[i] = (f[i - 1] + f[i - 2] + ... + f[i - W]) / W   when i <= K
            // f[i] = (f[K - 1] + f[K - 2] + ... + f[K - W]) / W   when i > K, since if we get K, we already win
            var f = new double[K + W];
            var sum = 0d;
            f[0] = 1;
            for (var i = 1; i < K + W; ++i)
            {
                if (i - 1 < K)
                {
                    sum += f[i - 1];
                }
                if (i - W - 1 >= 0)
                {
                    sum -= f[i - W - 1];
                }
                f[i] = sum / W;
            }

            // get probability for less or equals N after stopping, so we should at least reach K
            var answer = 0d;
            for (var i = K; i <= N; ++i)
            {
                answer += f[i];
            }
            return answer;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().New21Game(10, 1, 10);
            Console.WriteLine("Hello World!");
        }
    }
}
