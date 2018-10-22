using System;
using System.Collections.Generic;
using System.Text;

namespace _0804
{
    public class Solution
    {
        public int UniqueMorseRepresentations(string[] words)
        {
            var chars = new string[26] {".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};
            var answers = new HashSet<string>();
            foreach (var word in words)
            {
                var sb = new StringBuilder();
                foreach (var c in word)
                {
                    sb.Append(chars[(int)c - (int)'a']);
                }
                answers.Add(sb.ToString());
            }
            return answers.Count;
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
