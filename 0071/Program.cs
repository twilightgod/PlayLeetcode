using System;
using System.Collections.Generic;

namespace _0071
{
    public class Solution
    {
        public string SimplifyPath(string path)
        {
            var parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var folders = new List<string>();
            foreach (var p in parts)
            {
                if (p == ".")
                {
                    continue;
                }
                if (p == "..")
                {
                    if (folders.Count > 0)
                    {
                        folders.RemoveAt(folders.Count - 1);
                    }
                }
                else
                {
                    folders.Add(p);
                }
            }
            return "/" + String.Join("/", folders);
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
