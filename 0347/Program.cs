using System;
using System.Collections.Generic;

namespace _0347
{
    public class Solution
    {
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            var n = nums.Length;
            var freq2num = new HashSet<int>[n + 1];
            var num2freq = new Dictionary<int, int>();
            for (var i = 0; i < n + 1; ++i)
            {
                freq2num[i] = new HashSet<int>();
            }
            foreach (var num in nums)
            {
                num2freq[num] = num2freq.GetValueOrDefault(num, 0) + 1;
                var oldFreq = num2freq[num] - 1;
                var newFreq = num2freq[num];
                if (oldFreq > 0)
                {
                    freq2num[oldFreq].Remove(num);
                }
                freq2num[newFreq].Add(num);
            }
            var answer = new List<int>();
            for (var i = n; i > 0; --i)
            {
                if (freq2num[i].Count > 0)
                {
                    foreach (var num in freq2num[i])
                    {
                        answer.Add(num);
                        k--;
                    }
                    if (k == 0)
                    {
                        break;
                    }
                }
            }
            return answer;
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
