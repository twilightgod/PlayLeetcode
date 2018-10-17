using System;

namespace _0065
{
    public class Solution
    {
        public bool IsNumber(string s)
        {
            s = s.Trim();
            var parts = s.Split('e');
            if (parts.Length == 0 || parts.Length > 2)
            {
                return false;
            }
            
            if (parts.Length == 1)
            {
                // no e
                return IsNumberInternal(parts[0], true);
            }
            else if (parts.Length == 2)
            {
                // with e
                return IsNumberInternal(parts[0], true) && IsNumberInternal(parts[1], false);
            }

            return false;
        }

        private bool IsNumberInternal(string s, bool allowDot)
        {
            if (String.IsNullOrEmpty(s))
            {
                return false;
            }

            bool meetSign = false;
            bool meetDot = false;
            bool meetDigit = false;
            for (var i = 0; i < s.Length; ++i)
            {
                if (s[i] == '+' || s[i] == '-')
                {
                    if (i != 0)
                    {
                        return false;
                    }
                    if (meetSign)
                    {
                        return false;
                    }
                    meetSign = true;
                }
                else if (Char.IsDigit(s[i]))
                {
                    meetDigit = true;
                }
                else if (s[i] == '.')
                {
                    if (!allowDot)
                    {
                        return false;
                    }
                    if (meetDot)
                    {
                        return false;
                    }
                    meetDot = true;
                }
                else
                {
                    return false;
                }
            }

            if (!meetDigit)
            {
                return false;
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
