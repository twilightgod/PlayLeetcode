using System;
using System.Collections.Generic;

namespace _0556
{
    public class Solution
    {
        public int NextGreaterElement(int n)
        {
            var digits = n.ToString().ToCharArray();
            var found = false;
            var len = digits.Length;
            for (var i = len - 1; i >= 1; --i)
            {
                if (digits[i] > digits[i - 1])
                {
                    found = true;
                    // find the one just bigger than digits[i - 1]
                    var larger = i;
                    for (var j = i + 1; j < len; ++j)
                    {
                        if (digits[j] > digits[i - 1] && digits[j] < digits[larger])
                        {
                            larger = j;
                        }
                    }
                    Swap(ref digits[i - 1], ref digits[larger]);
                    Array.Sort(digits, i, len - i);
                    break;
                }
            }
            if (found)
            {
                var answer = 0;
                if (Int32.TryParse(new String(digits), out answer))
                {
                    return answer;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        private void Swap(ref char a, ref char b)
        {
            var t = a;
            a = b;
            b = t;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().NextGreaterElement(24);
            Console.WriteLine("Hello World!");
        }
    }
}
