using System;

namespace _0920
{
    public class Solution
    {
        public int NumMusicPlaylists(int N, int L, int K)
        {
            var MOD = 1_000_000_000 + 7;
            // f[i, j] means listening to total i songs with j distinct songs, what's the total ways
            var f = new int[L + 1, N + 1];
            f[0, 0] = 1;
            for (var i = 1; i <= L; ++i)
            {
                for (var j = 1; j <= N; ++j)
                {
                    // new song, we already have j - 1 songs, so we have (N - (j - 1)) new songs to choose from
                    f[i, j] = (int)((f[i, j] + (long)f[i - 1, j - 1] * (N - (j - 1))) % MOD);
                    // old song, if K > j, that means we can't find a song to play here that appears earlier than K interval
                    // if K < j, we can find j - K songs to choose from, since rencet K songs can't be used here
                    f[i, j] = (int)((f[i, j] + Math.Max(0, (long)f[i - 1, j] * (j - K))) % MOD);
                }
            }
            return f[L, N];
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
