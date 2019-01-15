using System;
using System.Collections.Generic;
using System.Text;

namespace _0012
{
    public class Solution
    {
        public string IntToRoman(int num)
        {
            var dic = new Dictionary<int, string>()
            {
                [0] = "",
                [1] = "I",
                [2] = "II",
                [3] = "III",
                [4] = "IV",
                [5] = "V",
                [6] = "VI",
                [7] = "VII",
                [8] = "VIII",
                [9] = "IX",
                [10] = "X",
                [20] = "XX",
                [30] = "XXX",
                [40] = "XL",
                [50] = "L",
                [60] = "LX",
                [70] = "LXX",
                [80] = "LXXX",
                [90] = "XC",
                [100] = "C",
                [200] = "CC",
                [300] = "CCC",
                [400] = "CD",
                [500] = "D",
                [600] = "DC",
                [700] = "DCC",
                [800] = "DCCC",
                [900] = "CM",
                [1000] = "M",
                [2000] = "MM",
                [3000] = "MMM",
            };

            var sb = new StringBuilder();
            var t = num / 1000 * 1000;
            sb.Append(dic[t]);
            num -= t;
            t = num / 100 * 100;
            sb.Append(dic[t]);
            num -= t;
            t = num / 10 * 10;
            sb.Append(dic[t]);
            num -= t;
            t = num;
            sb.Append(dic[t]);
            return sb.ToString();
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
