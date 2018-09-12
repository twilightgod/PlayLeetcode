using System;
using System.Collections.Generic;
using System.Linq;

namespace _0151
{
   public class Solution
    {
        public string ReverseWords(string s)
        {
            var reversed = ReverseString(s);
            var parts = reversed.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            var reversedParts = new List<string>();

            foreach (var part in parts)
            {
                reversedParts.Add(ReverseString(part));
            }

            return String.Join(" ", reversedParts);
        }

        private string ReverseString(string s)
        {
            var array = s.ToCharArray();
            return new String(array.Reverse().ToArray());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().ReverseWords("the sky is blue");
            Console.WriteLine("Hello World!");
        }
    }
}
