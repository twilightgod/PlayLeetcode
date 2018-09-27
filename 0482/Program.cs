using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0482
{
    public class Solution
    {
        public string LicenseKeyFormatting(string S, int K)
        {
            if (String.IsNullOrEmpty(S))
            {
                return S;
            }

            var sb = new StringBuilder();
            var counter = 0;
            var isFirst = true;
            for (var i = S.Length - 1; i >= 0; --i)
            {
                if (S[i] == '-')
                {
                    continue;
                }
                if (counter == 0 && !isFirst)
                {
                    sb.Append("-");
                }
                
                var c = Char.ToUpper(S[i]);
                sb.Append(c);

                if (++counter == K)
                {
                    counter = 0;
                    if (isFirst)
                    {
                        isFirst = false;
                    }
                }
            }
            
            var carray = sb.ToString().ToCharArray();
            Array.Reverse(carray);

            return new String(carray); 
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
