using System;
using System.Collections.Generic;
using System.Text;

namespace _0273
{
    public class Solution
    {
        public string NumberToWords(int num)
        {
            if (num == 0)
            {
                return "Zero";
            }

            var segments = new List<string>();

            var numStr = Convert.ToString(num);

            while (!String.IsNullOrEmpty(numStr))
            {
                var segmentLength = 3;

                if (numStr.Length < 3)
                {
                    segmentLength = numStr.Length;
                }

                var segmentStr = numStr.Substring(numStr.Length - segmentLength, segmentLength);
                segments.Add(segmentStr);
                numStr = numStr.Substring(0, numStr.Length - segmentLength);
            }

            return TranslateSengments(segments);
        }

        private string TranslateSengments(List<string> segments)
        {
            var segmentNames = new string[]{String.Empty, "Thousand", "Million", "Billion"};
            var digitNames = new Dictionary<int, string>()
            {
                [0] = String.Empty,
                [1] = "One", 
                [2] = "Two", 
                [3] = "Three", 
                [4] = "Four", 
                [5] = "Five", 
                [6] = "Six", 
                [7] = "Seven", 
                [8] = "Eight", 
                [9] = "Nine",
                [10] = "Ten",
                [11] = "Eleven",
                [12] = "Twelve",
                [13] = "Thirteen",
                [14] = "Fourteen",
                [15] = "Fifteen",
                [16] = "Sixteen",
                [17] = "Seventeen",
                [18] = "Eighteen",
                [19] = "Nineteen",
                [20] = "Twenty",
                [30] = "Thirty",
                [40] = "Forty",
                [50] = "Fifty",
                [60] = "Sixty",
                [70] = "Seventy",
                [80] = "Eighty",
                [90] = "Ninety",
            };
            
            var sb = new StringBuilder();

            for(var i = segments.Count - 1; i >= 0 ; --i)
            {
                var segmentSb = new StringBuilder();

                if (segments[i].Length == 3)
                {
                    var hundred = Convert.ToInt32(segments[i][0].ToString());
                    segments[i] = segments[i].Substring(1, 2);
                    if (hundred != 0)
                    {
                        segmentSb.Append($"{digitNames[hundred]} Hundred ");
                    }
                }

                var left = Convert.ToInt32(segments[i]);
                if (left != 0)
                {
                    if (digitNames.ContainsKey(left))
                    {
                        segmentSb.Append($"{digitNames[left]} ");
                    }
                    else
                    {
                        segmentSb.Append($"{digitNames[left / 10 * 10]} {digitNames[left % 10]} ");
                    }
                }

                if (segmentSb.Length > 0)
                {
                    segmentSb.Append($"{segmentNames[i]} ");
                }

                sb.Append(segmentSb.ToString());
            }

            return sb.ToString().Trim();
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
