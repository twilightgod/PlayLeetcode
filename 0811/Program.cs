using System;
using System.Collections.Generic;

namespace _0811
{
    public class Solution
    {
        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            var cnt = new Dictionary<string, int>();
            foreach (var s in cpdomains)
            {
                var sp = s.Split(' ');
                var ct = Int32.Parse(sp[0]);
                var domain = sp[1];
                cnt[domain] = cnt.GetValueOrDefault(domain, 0) + ct;
                var lastIdx = 0;
                while (true)
                {
                    if (lastIdx >= domain.Length)
                    {
                        break;
                    }
                    var idx = domain.IndexOf('.', lastIdx);
                    if (idx == -1)
                    {
                        break;
                    }
                    var subDomain = domain.Substring(idx + 1);
                    cnt[subDomain] = cnt.GetValueOrDefault(subDomain, 0) + ct;
                    lastIdx = idx + 1;
                }
            }
            var answers = new List<string>();
            foreach (var kvp in cnt)
            {
                answers.Add($"{kvp.Value} {kvp.Key}");
            }
            return answers;
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
