using System;
using System.Collections.Generic;

namespace _0929
{
    public class Solution
    {
        public int NumUniqueEmails(string[] emails)
        {
            var emailSet = new HashSet<string>();
            foreach (var email in emails)
            {
                var atPos = email.IndexOf('@');
                if (atPos == -1)
                {
                    throw new Exception("format error");
                }
                var localPart = email.Substring(0, atPos);
                var domainPart = email.Substring(atPos);
                
                localPart = localPart.Replace(".", "");
                var plusPos = localPart.IndexOf('+');
                if (plusPos >= 0)
                {
                    localPart = localPart.Substring(0, plusPos);
                }
                emailSet.Add(localPart + "@" + domainPart);
            }
            return emailSet.Count;
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
