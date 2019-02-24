using System;
using System.Collections.Generic;
using System.Linq;

namespace _0187
{
    public class Solution
    {
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            var answer = new HashSet<string>();
            var dnaSet = new HashSet<string>();
            for (var i = 0; i <= s.Length - 10; ++i)
            {
                var dna = s.Substring(i, 10);
                if (dnaSet.Contains(dna))
                {
                    answer.Add(dna);
                }
                else
                {
                    dnaSet.Add(dna);
                }
            }
            return answer.ToList();
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
