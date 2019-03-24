using System;
using System.Collections.Generic;

namespace _0895
{
    public class FreqStack
    {
        int maxFreq = 0;
        Dictionary<int, int> freq;
        Dictionary<int, Stack<int>> stacks;

        public FreqStack()
        {
            maxFreq = 0;
            freq = new Dictionary<int, int>();
            stacks = new Dictionary<int, Stack<int>>();
        }

        public void Push(int x)
        {
            var f = freq.GetValueOrDefault(x) + 1;
            freq[x] = f;
            if (!stacks.ContainsKey(f))
            {
                stacks[f] = new Stack<int>();
            }
            stacks[f].Push(x);
            maxFreq = Math.Max(maxFreq, f);
        }

        public int Pop()
        {
            var x = stacks[maxFreq].Pop();
            freq[x] = freq[x] - 1;
            if (stacks[maxFreq].Count == 0)
            {
                maxFreq--;
            }
            return x;
        }
    }

    /**
     * Your FreqStack object will be instantiated and called as such:
     * FreqStack obj = new FreqStack();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
