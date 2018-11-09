using System;

namespace _0678
{
    public class Solution
    {
        public bool CheckValidString(string s)
        {
            // like the simple problem without *, counter increase by 1 when we meet (, decrease by 1 when meet )
            // when introducing *, counter becomes a range, keep track of the left and right boundries
            var l = 0;
            var r = 0;
            foreach (var c in s)
            {
                if (c == '(')
                {
                    l++;
                }
                else
                {
                    l--;
                }
                if (c != ')')
                {
                    r++;
                }
                else
                {
                    r--;
                }
                if (r < 0)
                {
                    return false;
                }
                if (l < 0)
                {
                    l = 0;
                }
            }
            return l == 0;
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
