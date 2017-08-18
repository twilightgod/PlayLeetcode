using System;

namespace _58
{
    public class Solution {
    public int LengthOfLastWord(string s) {
        var list = s.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
        if (list.Length == 0)
        {
            return 0;
        }
        else
        {
            return list[list.Length - 1].Length;
        }
    }
}

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().LengthOfLastWord("a "));
        }
    }
}
