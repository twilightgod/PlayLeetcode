using System;
using System.Collections.Generic;

namespace _0339
{
    /**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation */
  public class NestedInteger {
 
      // Constructor initializes an empty nested list.
      public NestedInteger(){}
 
      // Constructor initializes a single integer.
      public NestedInteger(int value){}
 
      // @return true if this NestedInteger holds a single integer, rather than a nested list.
      public bool IsInteger(){return true;}
 
      // @return the single integer that this NestedInteger holds, if it holds a single integer
      // Return null if this NestedInteger holds a nested list
      public int GetInteger(){return 0;}
 
      // Set this NestedInteger to hold a single integer.
      public void SetInteger(int value){}
 
      // Set this NestedInteger to hold a nested list and adds a nested integer to it.
      public void Add(NestedInteger ni){}
 
      // @return the nested list that this NestedInteger holds, if it holds a nested list
      // Return null if this NestedInteger holds a single integer
      public IList<NestedInteger> GetList(){return null;}
  }

    public class Solution
    {
        public int DepthSum(IList<NestedInteger> nestedList)
        {
            return DepthSumSearch(nestedList, 1);
        }

        private int DepthSumSearch(IList<NestedInteger> nestedList, int depth)
        {
            if (nestedList == null)
            {
                return 0;
            }

            var sum = 0;
            foreach (var nested in nestedList)
            {
                if (nested.IsInteger())
                {
                    sum += nested.GetInteger() * depth;
                }
                else
                {
                    sum += DepthSumSearch(nested.GetList(), depth + 1);
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
