using System;
using System.Text;

namespace _0006
{
    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            var sb = new StringBuilder();
            // # of elements in one interval
            var k = numRows * 2 - 2;

            for (var row = 0; row < numRows; ++row)
            {
                for (var i = 0; i < s.Length; i += k)
                {
                    if (i + row < s.Length)
                    {
                        sb.Append(s[i + row]);
                    }
                    if (row != 0 && row != numRows - 1 && k - row + i < s.Length)
                    {
                        sb.Append(s[k - row + i]);
                    }
                }
            }

            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().Convert("1", 2));
            Console.WriteLine(new Solution().Convert("", 1));
            Console.WriteLine(new Solution().Convert("PAYPALISHIRING", 1));
            Console.WriteLine(new Solution().Convert("PAYPALISHIRING", 3));
        }
    }
}
