using System;
using System.Text;

namespace _0415
{
    public class Solution
    {
        public string AddStrings(string num1, string num2)
        {
            var s1 = num1.ToCharArray();
            Array.Reverse(s1);
            var s2 = num2.ToCharArray();
            Array.Reverse(s2);
            var c = 0;
            var len3 = Math.Max(s1.Length, s2.Length) + 1;
            var sb = new StringBuilder();
            for (var i = 0; i < len3; ++i)
            {
                var sum = 0;
                sum += (i < s1.Length ? (int)s1[i] - (int)'0' : 0);
                sum += (i < s2.Length ? (int)s2[i] - (int)'0' : 0);
                sum += c;
                c = sum / 10;
                sum %= 10;
                sb.Append(sum);
            }
            var num3 = sb.ToString();
            var s3 = num3.ToCharArray();
            Array.Reverse(s3);
            num3 = new String(s3);
            num3 = num3.TrimStart('0');
            return num3.Length == 0 ? "0" : num3;
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
