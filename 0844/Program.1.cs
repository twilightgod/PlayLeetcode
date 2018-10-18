using System;
using System.Collections.Generic;

namespace _0844_1
{
    public class Solution
    {
        public bool BackspaceCompare(string S, string T)
        { 
            var validCharIndexS = S.Length - 1;
            var validCharIndexT = T.Length - 1;

            while (true)
            {
                validCharIndexS = GetCharBackwards(S, validCharIndexS);
                validCharIndexT = GetCharBackwards(T, validCharIndexT);
                if (validCharIndexS == -1)
                {
                    if (validCharIndexT == -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (validCharIndexT == -1)
                    {
                        return false;
                    }
                    else if (S[validCharIndexS] != T[validCharIndexT])
                    {
                        return false;
                    }
                }
                validCharIndexS--;
                validCharIndexT--;
            }
        }

        private int GetCharBackwards(string s, int startIndex)
        {
            var backCounter = 0;
            var i = 0;
            for (i = startIndex; i >= 0; --i)
            {
                if (s[i] == '#')
                {
                    backCounter++;
                }
                else
                {
                    if (backCounter > 0)
                    {
                        backCounter--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return i;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().BackspaceCompare("ab#c", "ab#c");
            Console.WriteLine("Hello World!");
        }
    }
}
