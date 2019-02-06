using System;
using System.Collections.Generic;
using System.Text;

namespace _0166
{
    public class Solution
    {
        public string FractionToDecimal(int numerator, int denominator)
        {
            var n = (long)numerator;
            var d = (long)denominator;
            if (d == 0)
            {
                throw new Exception("d is 0");
            }

            var sb = new StringBuilder();
            if ((double)n / d < 0)
            {
                sb.Append("-");
            }
            n = Math.Abs(n);
            d = Math.Abs(d);

            var remain = n % d;
            sb.Append(n / d);
            if (remain > 0)
            {
                sb.Append(".");
            }

            var posDict = new Dictionary<long, int>();
            var numList = new List<long>();
            var div = 0l;
            while (remain > 0)
            {
                if (posDict.ContainsKey(remain))
                {
                    break;
                }
                else
                {
                    posDict[remain] = numList.Count;
                }

                remain *= 10;
                div = remain / d;
                numList.Add(div);
                remain %= d;
            }

            if (remain == 0)
            {
                foreach (var num in numList)
                {
                    sb.Append(num);
                }
            }
            else // loop
            {
                for (var i = 0; i < posDict[remain]; ++i)
                {
                    sb.Append(numList[i]);
                }
                sb.Append("(");
                for (var i = posDict[remain]; i < numList.Count; ++i)
                {
                    sb.Append(numList[i]);
                }
                sb.Append(")");
            }

            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().FractionToDecimal(1, 333);
            Console.WriteLine("Hello World!");
        }
    }
}
