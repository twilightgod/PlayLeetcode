using System;
using System.Collections.Generic;

namespace _0288
{
    public class ValidWordAbbr
    {
        Dictionary<string, string> abbrmapping = new Dictionary<string, string>();

        public ValidWordAbbr(string[] dictionary)
        {
            foreach (var word in dictionary)
            {
                var abbr = word.Length <= 2 ? word : (word[0] + (word.Length - 2).ToString() + word[word.Length - 1]);
                if (abbrmapping.ContainsKey(abbr))
                {
                    if (abbrmapping[abbr] != word)
                    {
                        abbrmapping[abbr] = null;
                    }
                }
                else
                {
                    abbrmapping[abbr] = word;
                }
            }
        }

        public bool IsUnique(string word)
        {
            var abbr = word.Length <= 2 ? word : (word[0] + (word.Length - 2).ToString() + word[word.Length - 1]);
            if (abbrmapping.ContainsKey(abbr))
            {
                return abbrmapping[abbr] == word;
            }
            else
            {
                return true;
            }
        }
    }

    /**
     * Your ValidWordAbbr object will be instantiated and called as such:
     * ValidWordAbbr obj = new ValidWordAbbr(dictionary);
     * bool param_1 = obj.IsUnique(word);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
