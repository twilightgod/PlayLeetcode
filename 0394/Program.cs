using System;
using System.Text;

namespace _0394
{
    public class Solution
    {
        public string DecodeString(string s)
        {
            var i = 0;
            return DFS(1, s + "]", ref i);
        }

        private string DFS(int times, string s, ref int i)
        {
            var num = -1;
            var sb = new StringBuilder();
            for (;;++i)
            {
                if (Char.IsDigit(s[i]))
                {
                    if (num == -1)
                    {
                        num = s[i] - '0';
                    }
                    else
                    {
                        num = num * 10 + s[i] - '0';
                    }
                }
                else if (s[i] == '[')
                {
                    i++;
                    sb.Append(DFS(num, s, ref i));
                    num = -1;
                }
                else if (s[i] == ']')
                {
                    break;
                }
                else
                {
                    sb.Append(s[i]);
                }
            }

            var single = sb.ToString();
            sb.Clear();
            for (var j = 0; j < times; ++j)
            {
                sb.Append(single);
            }
            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().DecodeString("3[a]2[bc]");
            Console.WriteLine("Hello World!");
        }
    }
}
