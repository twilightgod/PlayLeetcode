using System;

namespace _0277
{
    /* The Knows API is defined in the parent class Relation.
      bool Knows(int a, int b); */

    public class Solution : Relation
    {
        public int FindCelebrity(int n)
        {
            var candidate = 0;
            for (var i = 1; i < n; ++i)
            {
                if (Knows(candidate, i))
                {
                    candidate = i;
                }
            }

            for (var i = 0; i < n; ++i)
            {
                if (i != candidate)
                {
                    if (i < candidate && Knows(candidate, i) || !Knows(i, candidate))
                    {
                        return -1;
                    }
                }
            }

            return candidate;
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
