using System;
using System.Collections.Generic;

namespace _0721
{
    public class UnionFind
    {
        Dictionary<string, string> root = new Dictionary<string, string>();
        Dictionary<string, int> rank = new Dictionary<string, int>();

        public void TryCreate(string x)
        {
            if (!root.ContainsKey(x))
            {
                root[x] = x;
                rank[x] = 0;
            }
        }

        public string Find(string x)
        {
            if (root[x] != x)
            {
                root[x] = Find(root[x]);
            }
            return root[x];
        }

        public void Union(string x, string y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y)
            {
                return;
            }

            if (rank[x] > rank[y])
            {
                root[y] = x;
            }
            else if (rank[x] < rank[y])
            {
                root[x] = y;
            }
            else
            {
                root[x] = y;
                rank[y]++;
            }
        }
    }

    public class Solution
    {
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            var emailNameMapping = new Dictionary<string, string>();
            var answers = new List<IList<string>>();
            var uf = new UnionFind();

            foreach (var account in accounts)
            {
                var name = account[0];
                var firstEmail = String.Empty;
                for (var i = 1; i < account.Count; ++i)
                {
                    var email  = account[i];
                    emailNameMapping[email] = name;
                    uf.TryCreate(email);
                    if (i != 1)
                    {
                        uf.Union(firstEmail, email);
                    }
                    else
                    {
                        firstEmail = email;
                    }
                }
            }

            var rootEmailList = new Dictionary<string, List<string>>();
            
            foreach (var email in emailNameMapping.Keys)
            {
                var rootEmail = uf.Find(email);
                if (!rootEmailList.ContainsKey(rootEmail))
                {
                    rootEmailList.Add(rootEmail, new List<string>());
                }
                rootEmailList[rootEmail].Add(email);
            }

            foreach (var kvp in rootEmailList)
            {
                kvp.Value.Sort((x, y) => String.CompareOrdinal(x, y));
                var mergedList = new List<string>();
                mergedList.Add(emailNameMapping[kvp.Key]);
                mergedList.AddRange(kvp.Value);
                answers.Add(mergedList);
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
