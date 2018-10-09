using System;
using System.Collections.Generic;
using System.Linq;

namespace _0716
{
    public class MaxStack
    {

        /** initialize your data structure here. */
        SortedDictionary<int, Stack<LinkedListNode<int>>> bst = new SortedDictionary<int, Stack<LinkedListNode<int>>>(Comparer<int>.Create((a, b) => -a.CompareTo(b)));
        LinkedList<int> list = new LinkedList<int>();

        public MaxStack()
        {

        }

        public void Push(int x)
        {
            var node = new LinkedListNode<int>(x);
            if (!bst.ContainsKey(x))
            {
                bst.Add(x, new Stack<LinkedListNode<int>>());
            }
            bst[x].Push(node);
            list.AddLast(node);
        }

        public int Pop()
        {
            var node = list.Last;
            list.RemoveLast();
            var x = node.Value;
            bst[x].Pop();
            if (bst[x].Count == 0)
            {
                bst.Remove(x);
            }
            return x;
        }

        public int Top()
        {
            return list.Last.Value;
        }

        public int PeekMax()
        {
            return bst.First().Key;
        }

        public int PopMax()
        {
            var maxValue = bst.First().Key;
            var node = bst.First().Value.Pop();
            if (bst.First().Value.Count == 0)
            {
                bst.Remove(maxValue);
            }
            list.Remove(node);
            return maxValue;
        }
    }

    /**
     * Your MaxStack object will be instantiated and called as such:
     * MaxStack obj = new MaxStack();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.PeekMax();
     * int param_5 = obj.PopMax();
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
