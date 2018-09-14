using System;

namespace _0686
{
    public class Solution
    {
        public int RepeatedStringMatch(string A, string B)
        {
            var answer = -1;

            for (var i = 0; i < A.Length; ++i)
            {
                var times = 1;
                var p = i;
                var isMatch = true;
                for (var j = 0; j < B.Length; ++j, ++p)
                {
                    if (p == A.Length)
                    {
                        p = 0;
                        times++;
                    }
                    if (A[p] != B[j])
                    {
                        isMatch = false;
                        break;
                    }
                }
                if (isMatch)
                {
                    answer = answer == -1 ? times : Math.Min(answer, times);
                }
            }

            return answer;
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
