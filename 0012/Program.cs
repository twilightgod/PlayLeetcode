using System;
using System.Collections.Generic;

namespace _0012
{
    public class Solution
    {
        public string IntToRoman(int num)
        {
            var dic = new Dictionary<int, Dictionary<int, string>>()
            {
                {
                    0, new Dictionary<int, string>()
                    {
                    {'0', ""},
                    {'1', "I"},
                    {'2', "II"},
                    {'3', "III"},
                    {'4', "IV"},
                    {'5', "V"},
                    {'6', "VI"},
                    {'7', "VII"},
                    {'8', "VIII"},
                    {'9', "IX"},
                    }
                },

                {
                    1, new Dictionary<int, string>()
                    {
                    {'0', ""},
                    {'1', "X"},
                    {'2', "XX"},
                    {'3', "XXX"},
                    {'4', "XL"},
                    {'5', "L"},
                    {'6', "LX"},
                    {'7', "LXX"},
                    {'8', "LXXX"},
                    {'9', "XC"},
                    }
                },

                {
                    2, new Dictionary<int, string>()
                    {
                    {'0', ""},
                    {'1', "C"},
                    {'2', "CC"},
                    {'3', "CCC"},
                    {'4', "CD"},
                    {'5', "D"},
                    {'6', "DC"},
                    {'7', "DCC"},
                    {'8', "DCCC"},
                    {'9', "CM"},
                    }
                },

                {
                    3, new Dictionary<int, string>()
                    {
                    {'0', ""},
                    {'1', "M"},
                    {'2', "MM"},
                    {'3', "MMM"},
                    }
                },
            };

            var ansList = new List<string>();
            var s = num.ToString();
            for (var i = 0; i < s.Length; ++i)
            {
                ansList.Add(dic[i][s[s.Length - i - 1]]);
            }
            ansList.Reverse();
            return String.Join("", ansList);
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
