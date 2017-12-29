using System;
using System.Text;

namespace _0125
{
    public class Solution
    {
        public bool IsPalindrome(string s)
        {
            var cleaneds_sb = new StringBuilder();
            foreach (var c in s)
            {
                var lowc = Char.ToLower(c);
                if (Char.IsLetterOrDigit(lowc))
                {
                    cleaneds_sb.Append(lowc);
                }
            }
            var cleanedc = cleaneds_sb.ToString();
            
            if (cleanedc.Length == 0)
            {
                return true;
            }

            var l = 0;
            var r = cleanedc.Length - 1;

            while (l < r)
            {
                if (cleanedc[l] != cleanedc[r])
                {
                    return false;
                }
                l++;
                r--;
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
