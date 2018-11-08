using System;
using System.Text;

namespace _0125
{
    public class Solution
    {
        public bool IsPalindrome(string s)
        {
            var l = 0;
            var r = s.Length - 1;

            while (l < r)
            {
                while (l < r && !Char.IsLetterOrDigit(s[l]))
                {
                    l++;
                }
                while (l < r && !Char.IsLetterOrDigit(s[r]))
                {
                    r--;
                }
                
                if (l < r && Char.ToLower(s[l++]) != Char.ToLower(s[r--]))
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
