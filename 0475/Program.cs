using System;
using System.Collections.Generic;

namespace _0475
{
    public class Solution
    {
        public int FindRadius(int[] houses, int[] heaters)
        {
            var n = heaters.Length;
            var heaterList = new List<int>(heaters);
            heaterList.Sort();
            var answer = 0;
            foreach (var house in houses)
            {
                var closestHeater = heaterList.BinarySearch(house);
                if (closestHeater < 0)
                {
                    closestHeater = ~closestHeater;
                }
                var leftDistance = Int32.MaxValue;
                var rightDistance = Int32.MaxValue;
                if (closestHeater != n)
                {
                    rightDistance = heaterList[closestHeater] - house;
                }
                if (closestHeater > 0)
                {
                    leftDistance = house - heaterList[closestHeater - 1];
                }
                answer = Math.Max(answer, Math.Min(leftDistance, rightDistance));
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
