using System;
using System.Collections.Generic;

namespace _0809
{
    public class Solution
    {
        public int ExpressiveWords(string S, string[] words)
        {
            var S_st = Shorten(S);
            var answer = 0;
            foreach (var word in words)
            {
                var word_st = Shorten(word);
                if (IsEqual(S_st, word_st))
                {
                    answer++;
                }
            }
            return answer;
        }

        private List<(char, int)> Shorten(string s)
        {
            var ret = new List<(char, int)>();
            if (s.Length > 0)
            {
                // padding
                s = s + '|';
                var cnt = 1;
                for (var i = 1; i < s.Length; ++i)
                {
                    if (s[i] != s[i - 1])
                    {
                        ret.Add((s[i - 1], cnt));
                        cnt = 1;
                    }
                    else
                    {
                        cnt++;
                    }
                }
            }
            return ret;
        }

        private bool IsEqual(List<(char, int)> l1, List<(char, int)> l2)
        {
            if (l1.Count != l2.Count)
            {
                return false;
            }
            for (var i = 0; i < l1.Count; ++i)
            {
                if (l1[i].Item1 != l2[i].Item1)
                {
                    return false;
                }
                if (l1[i].Item2 == l2[i].Item2)
                {
                    continue;
                }
                else if (l1[i].Item2 > l2[i].Item2)
                {
                    if (l1[i].Item2 >= 3)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
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
