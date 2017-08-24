using System;

namespace _0008
{
    public class Solution
    {
        public int MyAtoi(string str)
        {
            int result = 0;
            bool negtive = false;

            str = str.Trim();

            if (String.IsNullOrEmpty(str))
            {
                return 0;
            }

            try
            {
                checked
                {
                    for (int i = 0; i < str.Length; ++i)
                    {
                        if (i == 0)
                        {
                            if (str[i] == '+')
                            {
                                continue;
                            }
                            else if (str[i] == '-')
                            {
                                negtive = true;
                                continue;
                            }
                        }

                        if (str[i] >= '0' && str[i] <= '9')
                        {
                            var newdigit = ((int)str[i] - (int)'0');
                            if (negtive)
                            {
                                newdigit = -newdigit;
                            }
                            result = result * 10 + newdigit;
                        }
                        else
                        {
                            break;
                        }
                    }

                    return result;
                }
            }
            catch (OverflowException ex)
            {
                return negtive ? Int32.MinValue : Int32.MaxValue;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int a = 2147483640 + 8;
            Console.WriteLine(`)
            Console.WriteLine(new Solution().MyAtoi("1.1"));
        }
    }
}
