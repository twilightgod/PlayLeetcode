using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0049_1
{
    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dic = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                var hash = BucketHash(str);

                if (!dic.ContainsKey(hash))
                {
                    dic[hash] = new List<string>();
                }

                dic[hash].Add(str);
            }

            return dic.Values.ToList();
        }

        private string BucketHash(string str)
        {
            var cnt = new int[26];
            var sb = new StringBuilder();
            foreach (var c in str)
            {
                cnt[c - 'a']++;
            }
            foreach (var num in cnt)
            {
                sb.Append($"{num},");
            }
            return sb.ToString();
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
