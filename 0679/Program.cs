using System;
using System.Collections.Generic;

namespace _0679
{
    public class Solution
    {
        public bool JudgePoint24(int[] nums)
        {
            var numList = new List<double>();
            foreach (var num in nums)
            {
                numList.Add((double)num);
            }
            return DFS(numList);
        }

        private bool DFS(List<double> numList)
        {
            if (numList.Count == 0)
            {
                return false;
            }
            if (numList.Count == 1)
            {
                if (Math.Abs(numList[0] - 24) < 1e-6)
                {
                    return true;
                }
            }
            for (var i = 0; i < numList.Count; ++i)
            {
                for (var j = 0; j < numList.Count; ++j)
                {
                    if (i != j)
                    {
                        var newNumList = new List<double>();
                        for (var k = 0; k < numList.Count; ++k)
                        {
                            if (k != i && k != j)
                            {
                                newNumList.Add(numList[k]);
                            }
                        }
                        for (var k = 0; k < 4; ++k)
                        {
                            if (k < 2 && i > j)
                            {
                                continue;
                            }
                            if (k == 0)
                            {
                                newNumList.Add(numList[i] + numList[j]);                                
                            }
                            if (k == 1)
                            {
                                newNumList.Add(numList[i] * numList[j]);
                            }
                            if (k == 2)
                            {
                                newNumList.Add(numList[i] - numList[j]);
                            }
                            if (k == 3)
                            {
                                if (numList[j] == 0)
                                {
                                    continue;
                                }
                                else
                                {
                                    newNumList.Add(numList[i] / numList[j]);
                                }
                            }
                            if (DFS(newNumList))
                            {
                                return true;
                            }
                            newNumList.RemoveAt(newNumList.Count - 1);
                        }
                    }
                }
            }

            return false;
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
