using System;

namespace _0647
{
    public class Solution
    {
        public int CountSubstrings(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return 0;
            }

            var answer = 0;

            for (var i = 0; i < s.Length; ++i)
            {
                // a[i] as center
                for (var j = 0; i + j < s.Length && i - j >= 0; ++j)
                {
                    if (s[i + j] == s[i - j])
                    {
                        answer++;
                    }
                    else
                    {
                        break;
                    }
                }
                // a[i] and a[i + 1] as center
                for (var j = 0; i + 1 + j < s.Length && i - j >= 0; ++j)
                {
                    if (s[i + j + 1] == s[i - j])
                    {
                        answer++;
                    }
                    else
                    {
                        break;
                    }
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
