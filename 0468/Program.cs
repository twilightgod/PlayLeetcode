using System;

namespace _0468
{
    public class Solution
    {
        public string ValidIPAddress(string IP)
        {
            if (IsIPv4(IP))
            {
                return "IPv4";
            }
            else if (IsIPv6(IP))
            {
                return "IPv6";
            }
            else
            {
                return "Neither";
            }
        }

        private bool IsIPv4(string IP)
        {
            var parts = IP.Split('.');
            if (parts.Length != 4)
            {
                return false;
            }
            foreach (var p in parts)
            {
                var pInt = 0;
                if (!Int32.TryParse(p, out pInt))
                {
                    return false;
                }
                if (pInt.ToString() != p)
                {
                    return false;
                }
                if (pInt < 0 || pInt > 255)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsIPv6(string IP)
        {
            var parts = IP.Split(':');
            if (parts.Length != 8)
            {
                return false;
            }
            foreach (var p in parts)
            {
                if (p.Length > 4)
                {
                    return false;
                }
                var pInt = 0;
                if (!Int32.TryParse(p, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture, out pInt))
                {
                    return false;
                }
                if (pInt < 0 || pInt > 65535)
                {
                    return false;
                }
            }
            return true;
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
