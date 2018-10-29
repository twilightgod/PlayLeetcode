using System;

namespace _0900
{
    public class RLEIterator
    {
        int[] A = null;
        int current = 0;

        public RLEIterator(int[] A)
        {
            this.A = A;
        }

        public int Next(int n)
        {
            while (true)
            {
                if (current >= A.Length)
                {
                    return -1;
                }
                else if (n <= A[current])
                {
                    A[current] -= n;
                    return A[current + 1];
                }
                else
                {
                    n -= A[current];
                    current += 2;
                }
            }
        }
    }

    /**
     * Your RLEIterator object will be instantiated and called as such:
     * RLEIterator obj = new RLEIterator(A);
     * int param_1 = obj.Next(n);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
