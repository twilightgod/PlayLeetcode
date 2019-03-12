using System;

namespace _0161
{
    public class Solution
    {
        public bool IsOneEditDistance(string s, string t)
        {
            if (s == null || t == null)
            {
                throw new Exception("input is null");
            }
            if (s == t)
            {
                return false;
            }
            var len1 = s.Length;
            var len2 = t.Length;
            if (len1 > len2)
            {
                return IsOneEditDistance(t, s);
            }
            if (len2 - len1 >= 2)
            {
                return false;
            }
            for (var i = 0; i < len1; ++i)
            {
                if (s[i] != t[i])
                {
                    if (len1 == len2)
                    {
                        return s.Substring(i + 1) == t.Substring(i + 1);
                    }
                    else
                    {
                        return s.Substring(i) == t.Substring(i + 1);
                    }
                }
            }

            return true;
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
