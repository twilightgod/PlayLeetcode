using System;
using System.Text;

namespace _0833
{
    public class ReplaceItem
    {
        public int index;
        public string source;
        public string target;
    }

    public class Solution
    {
        public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets)
        {
            var sb = new StringBuilder();
            var p = 0;
            var replaceItems = new List<ReplaceItem>();
            for (var i = 0; i < indexes.Length; ++i)
            {
                replaceItems.Add(new ReplaceItem(){index = indexes[i], source = sources[i], target = targets[i]});
            }
            replaceItems.Sort((a, b) => a.index.CompareTo(b.index));
            for (var i = 0; i < indexes.Length; ++i)
            {
                var replaceItem = replaceItems[i];
                while (p < replaceItem.index)
                {
                    sb.Append(S[p++]);
                }
                if (replaceItem.index + replaceItem.source.Length - 1 < S.Length 
                && S.Substring(replaceItem.index, replaceItem.source.Length) == replaceItem.source)
                {
                    sb.Append(replaceItem.target);
                    p = replaceItem.index + replaceItem.source.Length;
                }
            }
            while (p < S.Length)
            {
                sb.Append(S[p++]);
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
