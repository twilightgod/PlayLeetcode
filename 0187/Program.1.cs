using System;
using System.Collections.Generic;
using System.Linq;

namespace _0187_1
{
    // bit compression
    public class Solution
    {
        Dictionary<char, int> mapping1 = new Dictionary<char, int>() { ['A'] = 0, ['C'] = 1, ['G'] = 2, ['T'] = 3};
        char[] mapping2 = new char[] {'A', 'C', 'G', 'T'};
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            var answer = new HashSet<int>();
            var dnaSet = new HashSet<int>();
            var code = 0;
            for (var i = 0; i <= s.Length - 10; ++i)
            {
                if (i == 0)
                {
                    code = Encode(s.Substring(i, 10));
                }
                else
                {
                    code = ShiftCode(code, s[i + 9]);
                }

                if (dnaSet.Contains(code))
                {
                    answer.Add(code);
                }
                else
                {
                    dnaSet.Add(code);
                }
            }
            var answer_decoded = new List<string>();
            foreach (var a in answer)
            {
                answer_decoded.Add(Decode(a));
            }
            return answer_decoded;
        }

        private int Encode(string dna)
        {
            var code = 0;
            foreach(var c in dna)
            {
                code <<= 2;
                code += mapping1[c];
            }
            return code;
        }

        private int ShiftCode(int code, char c)
        {
            code <<= 2;
            code &= 0b11111111111111111111;
            code += mapping1[c];
            return code;
        }

        private string Decode(int code)
        {
            var chars = new char[10];
            for (var i = 9; i >= 0; --i)
            {
                chars[i] = mapping2[code & 3];
                code >>= 2;
            }
            return new string(chars);
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
