using System;

namespace _0344
{
    public class Solution
    {
        public string ReverseString(string s)
        {
            var l = 0;
            var r = s.Length - 1;
            var arr = s.ToCharArray();
            while (l < r)
            {
               var tmp = arr[l];
               arr[l] = arr[r];
               arr[r] = tmp;
               l++;
               r--;
            }
            return new string(arr);
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
