using System;

namespace _7
{
public class Solution {
    public static string Reverse( string s )
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse( charArray );
        return new string( charArray );
    }

    public int Reverse(int x) {
        var negtive = x < 0;
        var reverse_str = Reverse(Math.Abs((long)x).ToString());
        if (negtive)
        {
            reverse_str = "-" + reverse_str;
        }
        int reverse_int = 0;
        if (Int32.TryParse(reverse_str, out reverse_int))
        {
            return reverse_int;
        }
        else
        {
            return 0;
        }
    }
}

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().Reverse(-2147483648));
            Console.WriteLine(new Solution().Reverse(-123));
        }
    }
}
