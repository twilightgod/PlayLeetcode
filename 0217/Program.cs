using System;
using System.Linq;

namespace _0217
{
    public class Solution
    {
        public bool ContainsDuplicate(int[] nums)
        {
            return nums.Count() != nums.Distinct().Count();
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
