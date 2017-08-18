using System;
using System.Linq;

namespace _14
{
    public class Solution {
        private bool IsSame(string[] strs, int i)
        {
            for (var j = 0; j < strs.Count(); ++ j)
            {
                if (strs[j][i] != strs[0][i])
                {
                    return false;
                }
            }
            
            return true;
        }

    public string LongestCommonPrefix(string[] strs) {
        if (strs.Count() == 0)
        {
            return String.Empty;
        }

        var minlen = strs.Select(s => s.Length).Min();
        var bestlen = -1;
        for (var i = 0; i < minlen; ++i)
        {
            if (!IsSame(strs, i))
            {
                break;
            }
            else
            {
                bestlen = i;
            }
        }

        return strs[0].Substring(0, bestlen + 1);
    }
}

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().LongestCommonPrefix(new string[] {""}));
            Console.WriteLine(new Solution().LongestCommonPrefix(new string[] {"abc"}));
            Console.WriteLine(new Solution().LongestCommonPrefix(new string[] {"abc", "123"}));
            Console.WriteLine(new Solution().LongestCommonPrefix(new string[] {"abc", ""}));
            Console.WriteLine(new Solution().LongestCommonPrefix(new string[] {"abc", "abcd"}));
        }
    }
}
