using System;
using System.Collections.Generic;

namespace _0341
{
    /**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 */
    public class NestedInteger
    {

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        public bool IsInteger()
        {
            return true;
        }

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        public int GetInteger()
        {
            return 1;
        }

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        public IList<NestedInteger> GetList()
        {
            return null;
        }
    }

    public class NestedIterator
    {
        Stack<NestedInteger> stack;

        public NestedIterator(IList<NestedInteger> nestedList)
        {
            stack = new Stack<NestedInteger>();
            PushList(nestedList);            
        }

        public bool HasNext()
        {
            while (stack.Count > 0 && !stack.Peek().IsInteger())
            {
                PushList(stack.Pop().GetList());
            }
            return stack.Count > 0;
        }

        public int Next()
        {
            return stack.Pop().GetInteger();
        }

        private void PushList(IList<NestedInteger> nestedList)
        {
            for (var i = nestedList.Count - 1; i >= 0; --i)
            {
                stack.Push(nestedList[i]);
            }
        }
    }

    /**
     * Your NestedIterator will be called like this:
     * NestedIterator i = new NestedIterator(nestedList);
     * while (i.HasNext()) v[f()] = i.Next();
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
