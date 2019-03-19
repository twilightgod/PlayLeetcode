using System;
using System.Collections.Generic;

namespace _0676
{
    public class MagicDictionary
    {
        Dictionary<string, char> magicDict = null;

        /** Initialize your data structure here. */
        public MagicDictionary()
        {
            magicDict = new Dictionary<string, char>();
        }

        /** Build a dictionary through a list of words */
        public void BuildDict(string[] dict)
        {
            foreach (var word in dict)
            {
                for (var i = 0; i < word.Length; ++i)
                {
                    var wild = GetWildStr(word, i);
                    if (magicDict.ContainsKey(wild))
                    {
                        magicDict[wild] = '.';
                    }
                    else
                    {
                        var c = word[i];
                        magicDict[wild] = c;
                    }
                }
            }
        }

        private string GetWildStr(string s, int idx)
        {
            var arr = s.ToCharArray();
            arr[idx] = '.';
            return new String(arr);
        }

        /** Returns if there is any word in the trie that equals to the given word after modifying exactly one character */
        public bool Search(string word)
        {
            for (var i = 0; i < word.Length; ++i)
            {
                var wild = GetWildStr(word, i);
                var c = word[i];
                if (magicDict.ContainsKey(wild) && magicDict[wild] != c)
                {
                    return true;
                }
            }
            return false;
        }
    }

    /**
     * Your MagicDictionary object will be instantiated and called as such:
     * MagicDictionary obj = new MagicDictionary();
     * obj.BuildDict(dict);
     * bool param_2 = obj.Search(word);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
