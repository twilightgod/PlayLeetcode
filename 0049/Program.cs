using System;
using System.Collections.Generic;
using System.Linq;

namespace _0049
{
    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dic = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                var sorted = str.ToList();
                sorted.Sort();
                var hash = new String(sorted.ToArray());

                if (!dic.ContainsKey(hash))
                {
                    dic[hash] = new List<string>(); 
                }

                dic[hash].Add(str);
            }

            return dic.Values.ToList();
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
