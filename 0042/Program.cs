using System;

namespace _42
{
    class Program
    {
        public class Solution
        {
            public int Trap(int[] height)
            {
                var n = height.Length;
                
                var lefthighest = new int[n];
                var righthighest = new int[n];
                var sum = 0;
                
                for (int i = 0; i < n; ++i)
                {
                    lefthighest[i] = height[i];
                    if (i > 0)
                    {
                        lefthighest[i] = Math.Max(lefthighest[i], lefthighest[i - 1]);
                    }

                    righthighest[n - i - 1] = height[n - i -1];
                    if (i > 0)
                    {
                        righthighest[n - i - 1] = Math.Max(righthighest[n - i -1], righthighest[n - i]);
                    }
                }
                
                for (int i = 0; i < n; ++i)
                {
                    sum += Math.Min(lefthighest[i], righthighest[i]) - height[i];
                }   

                return sum;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
        }
    }
}
