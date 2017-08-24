using System;

namespace _0028
{
    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            if (String.IsNullOrEmpty(haystack) && String.IsNullOrEmpty(needle))
            {
                return 0;
            }

            if (needle.Length > haystack.Length)
            {
                return -1;
            }

            for (int i = 0; i <= haystack.Length - needle.Length; ++i)
            {
                bool found = true;
                for (int j = 0; j < needle.Length; ++j)
                {
                    if (haystack[i + j] != needle[j])
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    return i;
                }
            }

            return -1;
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
