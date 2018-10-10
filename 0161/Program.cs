using System;

namespace _0161
{
    public class Solution
    {
        public bool IsOneEditDistance(string s, string t)
        {
            // padding for empty
            s += '|';
            t += '|';
            return MatchWithDistance(s, t, 1);
        }

        private bool MatchWithDistance(string s, string t, int allowedDistance)
        {
            var i = 0;
            for (i = 0; i < s.Length && i < t.Length; ++i)
            {
                if (s[i] != t[i])
                {
                    if (allowedDistance > 0)
                    {
                        return 
                        // remove
                        MatchWithDistance(s.Remove(0, i + 1), t.Substring(i), allowedDistance - 1)
                        // change
                        || MatchWithDistance(t[i] + s.Remove(0, i + 1), t.Substring(i), allowedDistance - 1)
                        // add
                        || MatchWithDistance(t[i] + s.Substring(i), t.Substring(i), allowedDistance - 1)
                        ;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            
            return allowedDistance == 0 && i == s.Length && i == t.Length;
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
