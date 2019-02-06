using System;
using System.Collections.Generic;

namespace _0364
{
    /**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 */
    public class NestedInteger
    {

        // Constructor initializes an empty nested list.
        public NestedInteger() { }

        // Constructor initializes a single integer.
        public NestedInteger(int value) { }

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        public bool IsInteger() { return true; }

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        public int GetInteger() { return 0; }

        // Set this NestedInteger to hold a single integer.
        public void SetInteger(int value) { }

        // Set this NestedInteger to hold a nested list and adds a nested integer to it.
        public void Add(NestedInteger ni) { }

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        public IList<NestedInteger> GetList() { return null; }
    }

    public class Solution
    {
        public int DepthSumInverse(IList<NestedInteger> nestedList)
        {
            return DFS(nestedList, GetMaxDepth(nestedList));
        }

        private int GetMaxDepth(IList<NestedInteger> nestedList)
        {
            var depth = 1;
            foreach (var nestedInt in nestedList)
            {
                if (!nestedInt.IsInteger())
                {
                    depth = Math.Max(depth, GetMaxDepth(nestedInt.GetList()) + 1);
                }
            }
            return depth;
        }

        private int DFS(IList<NestedInteger> nestedList, int depth)
        {
            var sum = 0;
            foreach (var nestedInt in nestedList)
            {
                if (nestedInt.IsInteger())
                {
                    sum += nestedInt.GetInteger() * depth;
                }
                else
                {
                    sum += DFS(nestedInt.GetList(), depth - 1);
                }
            }
            return sum;
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
