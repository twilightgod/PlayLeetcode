using System;
using System.Linq;

namespace _0014_1
{
    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return String.Empty;
            }

            var prefix = strs[0];
            for (var i = 1; i < strs.Length; ++i)
            {
                var j = 0;
                for (j = 0; j < Math.Min(prefix.Length, strs[i].Length); ++j)
                {
                    if (prefix[j] != strs[i][j])
                    {
                        break;
                    }
                }
                prefix = prefix.Substring(0, j);
            }
            return prefix;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().LongestCommonPrefix(new string[] { "" }));
            Console.WriteLine(new Solution().LongestCommonPrefix(new string[] { "abc" }));
            Console.WriteLine(new Solution().LongestCommonPrefix(new string[] { "abc", "123" }));
            Console.WriteLine(new Solution().LongestCommonPrefix(new string[] { "abc", "" }));
            Console.WriteLine(new Solution().LongestCommonPrefix(new string[] { "abc", "abcd" }));
        }
    }
}
