using System;

namespace _0544
{
    public class Solution
    {
        public string FindContestMatch(int n)
        {
            var answer = new string[n];
            for (var i = 1; i <= n; ++i)
            {
                answer[i - 1] = i.ToString();
            }
            while (n > 0)
            {
                for (var i = 0; i < n / 2; ++i)
                {
                    answer[i] = $"({answer[i]},{answer[n - i - 1]})";
                }
                n /= 2;
            }
            return answer[0];
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
