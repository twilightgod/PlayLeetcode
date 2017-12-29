using System;

namespace _0680
{
    public class Solution
    {
        public bool ValidPalindrome(string s)
        {
            return ValidPalindromeWithDelete(s, 0, s.Length - 1, 1);
        }

        private bool ValidPalindromeWithDelete(string s, int l, int r, int remaindelete)
        {
            while (l < r)
            {
                if (s[l] != s[r])
                {
                    if (remaindelete == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return ValidPalindromeWithDelete(s, l, r - 1, remaindelete - 1) || ValidPalindromeWithDelete(s, l + 1, r, remaindelete - 1);
                    }
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
