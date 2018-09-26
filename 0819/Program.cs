using System;
using System.Collections.Generic;

namespace _0819
{
    public class Solution
    {
        public string MostCommonWord(string paragraph, string[] banned)
        {
            var banset = new HashSet<string>();
            foreach (var word in banned)
            {
                banset.Add(word.ToLower());
            }
            var counter = new Dictionary<string, int>();
            var symbols = new char[]{'!', '?', '\'', ',', ';', '.'};
            paragraph = paragraph.ToLower();
            foreach (var rawword in paragraph.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries))
            {
                var word = rawword.Trim(symbols);
                if (!banset.Contains(word))
                {
                    if (!counter.ContainsKey(word))
                    {
                        counter[word] = 0;
                    }
                    counter[word]++;
                }
            }
            var answer = String.Empty;
            var maxcnt = 0;
            foreach (var kvp in counter)
            {
                if (kvp.Value > maxcnt)
                {
                    maxcnt = kvp.Value;
                    answer = kvp.Key;
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
