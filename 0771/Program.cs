using System;
using System.Collections.Generic;

namespace _0771
{
    public class Solution
    {
        public int NumJewelsInStones(string J, string S)
        {
            if (String.IsNullOrEmpty(J) || String.IsNullOrEmpty(S))
            {
                return 0;
            }
            var jew = new HashSet<char>();
            foreach (var c in J)
            {
                jew.Add(c);
            }
            var answer = 0;
            foreach (var c in S)
            {
                if (jew.Contains(c))
                {
                    answer++;
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
