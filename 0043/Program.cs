using System;
using System.Text;

namespace _0043
{
    public class Solution
    {
        public string Multiply(string num1, string num2)
        {
            var n1 = new int[num1.Length];
            for (var i = 0; i < num1.Length; ++i)
            {
                n1[num1.Length - i - 1] = Convert.ToInt32(num1[i].ToString());
            }

            var n2 = new int[num2.Length];
            for (var i = 0; i < num2.Length; ++i)
            {
                n2[num2.Length - i - 1] = Convert.ToInt32(num2[i].ToString());
            }

            var result = new int[num1.Length + num2.Length];
            for (var i = 0; i < num1.Length; ++i)
            {
                for (var j = 0; j < num2.Length; ++j)
                {
                    result[i + j] += n1[i] * n2[j];
                }
            }

            for (var i = 0; i < num1.Length + num2.Length - 1; ++i)
            {
                result[i + 1] += result[i] / 10;
                result[i] %= 10;
            }
            
            var sb = new StringBuilder();
            var startPos = num1.Length + num2.Length - 1;
            while (startPos >= 0 && result[startPos] == 0)
            {
                startPos--;
            }

            if (startPos < 0)
            {
                sb.Append("0");
            }
            else
            {
                for (var j = startPos; j >= 0; --j)
                {
                    sb.Append(result[j]);
                }
            }

            return sb.ToString();
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
