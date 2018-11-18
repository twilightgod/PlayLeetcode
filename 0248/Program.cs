using System;
using System.Collections.Generic;

namespace _0248
{
    public class Solution
    {
        public int StrobogrammaticInRange(string low, string high)
        {
            Console.WriteLine("start");
            var len1 = low.Length;
            var len2 = high.Length;
            var intRes = new List<List<string>>();
            var answer = 0;

            for (var i = 0; i <= len2; ++i)
            {
                intRes.Add(new List<string>());
                if (i == 0)
                {
                    intRes[i].Add(String.Empty);
                }
                else if (i == 1)
                {
                    intRes[i].Add("0");
                    intRes[i].Add("1");
                    intRes[i].Add("8");
                }
                else
                {
                    foreach (var s in intRes[i - 2])
                    {
                        intRes[i].Add("0" + s + "0");
                        intRes[i].Add("1" + s + "1");
                        intRes[i].Add("6" + s + "9");
                        intRes[i].Add("8" + s + "8");
                        intRes[i].Add("9" + s + "6");
                    }
                }
                if (i >= len1 && i <= len2)
                {
                    foreach (var s in intRes[i])
                    {
                        if (i > 1 && s[0] == '0')
                        {
                            continue;
                        }
                        if (i == len1 && low.CompareTo(s) > 0)
                        {
                            continue;
                        }
                        if (i == len2 && s.CompareTo(high) > 0)
                        {
                            continue;
                        }
                        answer++;
                    }
                }
            }
            return answer;
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
