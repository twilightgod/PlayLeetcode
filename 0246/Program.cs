using System;
using System.Collections.Generic;

namespace _0246
{
    public class Solution
    {
        public bool IsStrobogrammatic(string num)
        {
            var mapping = new Dictionary<char, char>()
            {
                ['0'] = '0',
                ['1'] = '1',
                ['6'] = '9',
                ['8'] = '8',
                ['9'] = '6'
            };

            for (var i = 0; i <= (num.Length >> 1); ++i)
            {
                if (!mapping.ContainsKey(num[i]))
                {
                    return false;
                }
                if (mapping[num[i]] != num[num.Length - i - 1])
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
