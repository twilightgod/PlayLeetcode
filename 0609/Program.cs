using System;
using System.Collections.Generic;

namespace _0609
{
    public class Solution
    {
        public IList<IList<string>> FindDuplicate(string[] paths)
        {
            var answers = new List<IList<string>>();
            var fileDict = new Dictionary<string, List<string>>();

            foreach (var path in paths)
            {
                var parts = path.Split(" ");
                for (var i = 1; i < parts.Length; ++i)
                {
                    var pos = parts[i].IndexOf('(');
                    var fileName = parts[i].Substring(0, pos);
                    var content = parts[i].Substring(pos + 1, parts[i].Length - pos - 2);
                    var fullFileName = parts[0] + '/' + fileName;
                    if (!fileDict.ContainsKey(content))
                    {
                        fileDict[content] = new List<string>();
                    }
                    fileDict[content].Add(fullFileName);
                }
            }

            foreach (var kvp in fileDict)
            {
                if (kvp.Value.Count > 1)
                {
                    answers.Add(kvp.Value);
                }
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
