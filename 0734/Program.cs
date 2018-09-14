using System;
using System.Collections.Generic;

namespace _0734
{
    public class Solution
    {
        public bool AreSentencesSimilar(string[] words1, string[] words2, string[,] pairs)
        {
            if (words1.Length != words2.Length)
            {
                return false;
            }

            var similarDic = new Dictionary<string, HashSet<string>>();
            for (var i = 0; i < pairs.GetLength(0); ++i)
            {
                if (!similarDic.ContainsKey(pairs[i, 0]))
                {
                    similarDic.Add(pairs[i, 0], new HashSet<string>());
                }
                similarDic[pairs[i, 0]].Add(pairs[i ,1]);
            }

            for (var i = 0; i < words1.Length; ++i)
            {
                if (words1[i] == words2[i] || similarDic.ContainsKey(words1[i]) && similarDic[words1[i]].Contains(words2[i]) || similarDic.ContainsKey(words2[i]) && similarDic[words2[i]].Contains(words1[i]))
                {

                }
                else
                {
                    return false;
                }
            }

            return true;
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
