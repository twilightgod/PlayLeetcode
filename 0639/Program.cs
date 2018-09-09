using System;
using System.Collections.Generic;

namespace _0639
{
    public class Solution
    {
        const int MOD = 1000000007;

        public int NumDecodings(string s)
        {
            // x * 15 where x < MOD will overflow, needs 64bit 
            var f = new List<Int64>(s.Length);
            
            for (var i = 0; i < s.Length; ++i)
            {
                f.Add(0);

                // comes from f(i - 1)
                if (s[i] == '0')
                {
                    // 0 can't be decoded alone
                }
                else if (s[i] == '*')
                {
                    // 1..9
                    f[i] = (GetF(f, i - 1) * 9) % MOD;
                }
                else
                {
                    f[i] = GetF(f, i - 1);
                }

                // comes from f(i - 2)
                if (i > 0)
                {
                    if (s[i] == '*')
                    {
                        if (s[i - 1] == '*')
                        {
                            // 11..19, 21..26
                            f[i] = (f[i] + GetF(f, i - 2) * 15) % MOD;
                        }
                        else if (s[i - 1] == '1')
                        {
                            // 11..19
                            f[i] = (f[i] + GetF(f, i - 2) * 9) % MOD;
                        }
                        else if (s[i - 1] == '2')
                        {
                            // 21..26
                            f[i] = (f[i] + GetF(f, i - 2) * 6) % MOD;
                        }
                    }
                    else
                    {
                        if (s[i - 1] == '*')
                        {
                            var cases = 0;
                            var twodigits = Convert.ToInt32("1" + s[i].ToString());
                            if (twodigits >= 10 && twodigits <= 26)
                            {
                                cases++;
                            }

                            twodigits = Convert.ToInt32("2" + s[i].ToString());
                            if (twodigits >= 10 && twodigits <= 26)
                            {
                                cases++;
                            }
                            
                            f[i] = (f[i] + GetF(f, i - 2) * cases) % MOD;
                        }
                        else
                        {
                            var twodigits = Convert.ToInt32(s.Substring(i - 1, 2).ToString());

                            if (twodigits >= 10 && twodigits <= 26)
                            {
                                f[i] = (f[i] + GetF(f, i - 2)) % MOD;
                            }
                        }
                    }
                }
            }

            return (Int32)f[s.Length - 1];
        }

        private Int64 GetF(List<Int64> f, int index)
        {
            if (index < 0)
            {
                return 1;
            }
            else
            {
                return f[index];
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().NumDecodings("101");
            Console.WriteLine("Hello World!");
        }
    }
}
