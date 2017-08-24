using System;
using System.Collections.Generic;
using System.Text;

namespace _0038
{
    public class Solution
    {
        private static List<string> ans = new List<string>();
        
        static Solution()
        {
            ans.Add("1");
        }

        public string CountAndSay(int n)
        {
            var len = ans.Count;
            for (int i = len; i < n; ++i)
            {
                var laststr = ans[i - 1];
                var sb = new StringBuilder();
                var cnt = 1;
                var c = laststr[0];

                for (int j = 1; j < laststr.Length; ++j)
                {
                    if (laststr[j] == laststr[j - 1])
                    {
                        cnt++;
                    }
                    else
                    {
                        sb.Append($"{cnt}{c}");
                        c = laststr[j];
                        cnt = 1;
                    }
                }
                sb.Append($"{cnt}{c}");

                ans.Add(sb.ToString());
            }

            return ans[n - 1];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().CountAndSay(10));
        }
    }
}
