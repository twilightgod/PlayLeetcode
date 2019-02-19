using System;
using System.Collections.Generic;
using System.Text;

namespace _0726
{
    public class Solution
    {
        public string CountOfAtoms(string formula)
        {
            var pos = 0;
            var sb = new StringBuilder();
            foreach (var kvp in DFS(formula, ref pos))
            {
                sb.Append(kvp.Key);
                if (kvp.Value > 1)
                {
                    sb.Append(kvp.Value);
                }
            }
            return sb.ToString();
        }

        private SortedDictionary<string, int> DFS(string s, ref int pos)
        {
            var ret = new SortedDictionary<string, int>();
            while (pos < s.Length)
            {
                if (s[pos] == '(')
                {
                    pos++;
                    var subDict = DFS(s, ref pos);
                    var n = ReadNumber(s, ref pos);
                    foreach (var kvp in subDict)
                    {
                        ret[kvp.Key] = ret.GetValueOrDefault(kvp.Key) + kvp.Value * n;
                    }
                }
                else if (s[pos] == ')')
                {
                    pos++;
                    break;
                }
                else
                {
                    var name = ReadName(s, ref pos);
                    var n = ReadNumber(s, ref pos);
                    ret[name] = ret.GetValueOrDefault(name) + n;
                }
            }
            return ret;
        }

        private string ReadName(string s, ref int pos)
        {
            var sb = new StringBuilder();
            while (pos < s.Length)
            {
                var c = s[pos];
                if (sb.Length == 0 || Char.IsLower(c))
                {
                    pos++;
                    sb.Append(c);
                }
                else
                {
                    break;
                }
            }
            return sb.ToString();
        }

        private int ReadNumber(string s, ref int pos)
        {
            var ret = 0;
            while (pos < s.Length)
            {
                var c = s[pos];
                if (Char.IsDigit(c))
                {
                    ret = ret * 10 + (int)(c - '0');
                    pos++;
                }
                else
                {
                    break;
                }
            }
            return ret == 0 ? 1 : ret;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().CountOfAtoms("Mg(OH)2");
            Console.WriteLine("Hello World!");
        }
    }
}
