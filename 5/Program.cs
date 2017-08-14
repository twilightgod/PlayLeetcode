using System;

namespace _5
{
    public class Solution {
        public string LongestPalindrome(string s) 
        {
            if (String.IsNullOrEmpty(s))
            {
                return s;
            }

            var best_start =  0;
            var best_len = 0;
            
            for (var i = 0; i< s.Length; ++i)
            {
                {
                    // i is the center
                    var j = 0;
                    while (i - j >= 0 && i + j < s.Length)
                    {
                        if (s[i - j] != s[i + j])
                        {
                            break;
                        }
                        else
                        {
                            if (best_len < j * 2 + 1)
                            {
                                best_start = i - j;
                                best_len = j * 2 + 1;
                            }

                            j++;
                        }
                    }
                }

                {
                    // i and i + 1 are the center
                    if (i < s.Length - 1 && s[i] == s[i+1])
                    {
                        var j = 0;  
                        while (i - j >= 0 && i + 1 + j < s.Length)
                        {
                            if (s[i - j] != s[i + 1 + j])
                            {
                                break;
                            }
                            else
                            {
                                if (best_len < j * 2 + 2)
                                {
                                    best_start = i - j;
                                    best_len = j * 2 + 2;
                                }

                                j++;
                            }
                        } 
                    }
                }
            }
                
            return s.Substring(best_start, best_len);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().LongestPalindrome("a"));
            Console.WriteLine(new Solution().LongestPalindrome("cbbd"));
            Console.WriteLine(new Solution().LongestPalindrome("babad"));
        }
    }
}
