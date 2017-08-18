using System;
using System.Collections.Generic;

namespace _17
{
    class Program
    {
        public class Solution {
            Dictionary<char, List<char>> dict = new Dictionary<char, List<char>>()
            {
                ['2'] = new List<char>() { 'a', 'b', 'c'},
                ['3'] = new List<char>() { 'd', 'e', 'f'},
                ['4'] = new List<char>() { 'g', 'h', 'i'},
                ['5'] = new List<char>() { 'j', 'k', 'l'},
                ['6'] = new List<char>() { 'm', 'n', 'o'},
                ['7'] = new List<char>() { 'p', 'q', 'r' ,'s'},
                ['8'] = new List<char>() { 't', 'u', 'v'},
                ['9'] = new List<char>() { 'w', 'x', 'y', 'z'},
            };

            private void GenLetter(List<string> result, string digits, char[] current, int depth)
            {
                if (depth == digits.Length)
                {
                    result.Add(new string(current));
                    return;
                }
                foreach (var c in dict[digits[depth]])
                {
                    current[depth] = c;
                    GenLetter(result, digits, current, depth + 1);
                }
            }

    public IList<string> LetterCombinations(string digits) {
        var result = new List<string>();
        foreach (var c in digits)
        {
            if (!dict.ContainsKey(c))
            {
                return result;
            }
        }
        if (String.IsNullOrEmpty(digits))
        {
            return result;
        }
        var current = new char[digits.Length];
        GenLetter(result, digits, current, 0);
        return result;
    }
}
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(", ", new Solution().LetterCombinations("")));
            Console.WriteLine(String.Join(", ", new Solution().LetterCombinations("123")));
            Console.WriteLine(String.Join(", ", new Solution().LetterCombinations("23")));
        }
    }
}
