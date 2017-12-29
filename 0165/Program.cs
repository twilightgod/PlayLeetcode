using System;

namespace _0165
{
    public class Solution
    {
        public int CompareVersion(string version1, string version2)
        {
            var verlist1 = version1.Split(new string[]{"."}, StringSplitOptions.RemoveEmptyEntries);
            var verlist2 = version2.Split(new string[]{"."}, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < Math.Max(verlist1.Length, verlist2.Length); ++i)
            {
                var subver1 = i >= verlist1.Length ? 0 : Int32.Parse(verlist1[i]);
                var subver2 = i >= verlist2.Length ? 0 : Int32.Parse(verlist2[i]);
                if (subver1 > subver2)
                {
                    return 1;
                }
                else if (subver1 < subver2)
                {
                    return -1;
                }
            }

            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().CompareVersion("1.0", "");
            new Solution().CompareVersion("1.0", "1");
            Console.WriteLine("Hello World!");
        }
    }
}
