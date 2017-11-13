using System;
using System.Collections.Generic;

namespace _0013
{
    public class Solution
    {
        public int RomanToInt(string s)
        {
            var dic1 = new Dictionary<string, int>()
            {
                {"IV", 4},
                {"IX", 9},
                {"XL", 40},
                {"XC", 90},
                {"CD", 400},
                {"CM", 900},
            };

            var dic2 = new Dictionary<string, int>()
            {
                {"I", 1},
                {"V", 5},
                {"X", 10},
                {"L", 50},
                {"C", 100},
                {"D", 500},
                {"M", 1000},
            };

            var ans = 0;

            while (!String.IsNullOrEmpty(s))
            {
                var found = false;
                foreach (var key in dic1.Keys)
                {
                    if (s.StartsWith(key))
                    {
                        ans += dic1[key];
                        found = true;
                        s = s.Substring(key.Length);
                        break;            
                    }
                }

                if (found)
                {
                    continue;
                }

                foreach (var key in dic2.Keys)
                {
                    if (s.StartsWith(key))
                    {
                        ans += dic2[key];
                        found = true;
                        s = s.Substring(key.Length);
                        break;            
                    }
                }
            }

            return ans;
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
