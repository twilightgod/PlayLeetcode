using System;
using System.Text;

namespace _6
{
    public class Solution {
    public string Convert(string s, int numRows) {
        if (numRows == 1)
        {
            return s;
        }
        
        var sb = new StringBuilder();
        var k = numRows * 2 - 2;

        for (var row = 0; row < numRows; ++row)
        {
            for (var i = 0; i < s.Length; ++i)
            {
                var m = i % k;
                var targetrow = m < numRows ? m : k - m;
                if (row == targetrow)
                {
                    sb.Append(s[i]);
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
            Console.WriteLine(new Solution().Convert("", 1));
            Console.WriteLine(new Solution().Convert("PAYPALISHIRING", 1));
            Console.WriteLine(new Solution().Convert("PAYPALISHIRING", 3));
        }
    }
}
