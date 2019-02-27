using System;
using System.Collections.Generic;
using System.Linq;

namespace _0621
{
    public class Solution
    {
        public int LeastInterval(char[] tasks, int n)
        {
            if (tasks.Length == 0)
            {
                return 0;
            }
            
            var counter = new Dictionary<char, int>();
            foreach (var c in tasks)
            {
                counter[c] = counter.GetValueOrDefault(c) + 1;
            }

            var maxFrequncy = counter.Values.Max();
            var maxCount = counter.Values.Where(x => x == maxFrequncy).Count();

            // tasks.Length means if N too small, tasks number in one interval is larger than n+1, then the task should always be finished without any idle time
            // (n + 1) means one interval lenth
            // (maxFrequncy - 1) means the number of full interval
            // maxCount means the length of last interval, since other less frequent task should be fitted before last interval
            return Math.Max(tasks.Length, (n + 1) * (maxFrequncy - 1) + maxCount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().LeastInterval(new char[]{'A','A','A','B','B','C','C'}, 3);
            Console.WriteLine("Hello World!");
        }
    }
}
