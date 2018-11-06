using System;

namespace _0845_1
{
    public class Solution
    {
        public int LongestMountain(int[] A)
        {
            if (A == null || A.Length == 0)
            {
                return 0;
            }

            var n = A.Length;
            var l = 0;
            var answer = 0;
            // 0 uphill, 1 downhill
            var phase = 0;
            for (var r = 1; r < n; ++r)
            {
                if (phase == 0)
                {
                    if (A[r] > A[r - 1])
                    {
                        // keep going
                    }
                    else if (A[r] == A[r - 1])
                    {
                        // no mountain
                        l = r;
                    }
                    else
                    {
                        if (l + 1 == r)
                        {
                            // too short, no mountain
                            l = r;
                        }
                        else
                        {
                            // going down
                            phase = 1;
                        }
                    }
                }
                else
                {
                    if (A[r] > A[r - 1])
                    {
                        // new hill
                        phase = 0;
                        l = r - 1;
                    }
                    else if (A[r] == A[r - 1])
                    {
                        // no mountain
                        phase = 0;
                        l = r;
                    }
                    else
                    {
                        // going down
                    }
                }
                if (phase == 1)
                {
                    answer = Math.Max(answer, r - l + 1);
                }
            }

            return answer;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            [2,1,4,7,3,2,5]
[2,2,2]
[1]
[1,2]
[2,3,3,2,0,2] */
            Console.WriteLine("Hello World!");
        }
    }
}
