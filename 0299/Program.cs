using System;
using System.Collections.Generic;
using System.Linq;

namespace _0299
{
    public class Solution
    {
        public string GetHint(string secret, string guess)
        {
            var bulls = 0;
            var cows_secret = Enumerable.Repeat(0, 10).ToList();
            var cows_guess = Enumerable.Repeat(0, 10).ToList();

            for (var i = 0; i < secret.Length; ++i)
            {
                if (secret[i] == guess[i])
                {
                    bulls++;
                }
                else
                {
                    cows_secret[Convert.ToInt32(secret[i].ToString())]++;
                    cows_guess[Convert.ToInt32(guess[i].ToString())]++;
                }
            }

            var cows = 0;
            for (var i = 0; i < 10; ++i)
            {
                cows += Math.Min(cows_secret[i], cows_guess[i]);
            }

            return $"{bulls}A{cows}B";
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
