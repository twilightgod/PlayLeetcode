using System;

namespace _0009
{
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0 || x % 10 == 0)
            {
                return false;
            }

            var rightpart = 0;
            while (x > rightpart)
            {
                rightpart = rightpart * 10 + x % 10;
                x = x / 10;
            }

            return x == rightpart || x == rightpart / 10;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().IsPalindrome(21120));
            Console.WriteLine(new Solution().IsPalindrome(100));
        }
    }
}
