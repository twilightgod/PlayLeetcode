using System;
using System.Collections.Generic;

namespace _0825
{
    public class Solution
    {
        public int NumFriendRequests(int[] ages)
        {
            var ageCount = new Dictionary<int, int>();
            foreach (var age in ages)
            {
                ageCount[age] = ageCount.GetValueOrDefault(age) + 1;
            }

            var answer = 0;
            foreach (var kvp1 in ageCount)
            {
                foreach (var kvp2 in ageCount)
                {
                    if (kvp2.Key <= 0.5 * kvp1.Key + 7)
                    {
                        continue;
                    }
                    if (kvp2.Key > kvp1.Key)
                    {
                        continue;
                    }
                    if (kvp2.Key > 100 && kvp1.Key < 100)
                    {
                        continue;
                    }
                    answer += kvp1.Value * kvp2.Value;
                    // can't send request to self
                    if (kvp1.Key == kvp2.Key)
                    {
                        answer -= kvp1.Value;
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
