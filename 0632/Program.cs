using System;
using System.Collections.Generic;
using System.Linq;

namespace _0632
{
    public class DoubleHeap
    {
        // (currentvalue, nextvalue's list index) -> nextvalue's index in list)>>
        public SortedSet<(int value, int listIndex, int nextIndexInList)> minHeap = new SortedSet<(int value, int listIndex, int nextIndexInList)>();
        public SortedSet<(int value, int listIndex, int nextIndexInList)> maxHeap = new SortedSet<(int value, int listIndex, int nextIndexInList)>();

        public void InsertNode(IList<int> list, int listIndex, int currentIndexInList)
        {
            var nodeMinHeap = (list[currentIndexInList], listIndex, currentIndexInList + 1);
            var nodeMaxHeap = (-list[currentIndexInList], -listIndex, -(currentIndexInList + 1));
            minHeap.Add(nodeMinHeap);
            maxHeap.Add(nodeMaxHeap);
        }

        // return list index and nextIndexInList of removed element
        public (int listIndex, int nextIndexInList) RemoveFirstNode()
        {
            var nodeMinHeap = minHeap.First();
            var nodeMaxHeap = (-nodeMinHeap.value, -nodeMinHeap.listIndex, -nodeMinHeap.nextIndexInList);
            var listIndex = nodeMinHeap.listIndex;
            var nextIndexInList = nodeMinHeap.nextIndexInList;
            minHeap.Remove(nodeMinHeap);
            maxHeap.Remove(nodeMaxHeap);
            return (listIndex, nextIndexInList);
        }

        public int Max()
        {
            return -maxHeap.First().value;
        }

        public int Min()
        {
            return minHeap.First().value;
        }
    }

    public class Solution
    {
        public int[] SmallestRange(IList<IList<int>> nums)
        {
            if (nums == null || nums.Count == 0)
            {
                return null;
            }

            var doubleHeap = new DoubleHeap();
            // insert first element from each list
            for (var i = 0; i < nums.Count; ++i)
            {
                doubleHeap.InsertNode(nums[i], i, 0);
            }
            var answers = new int[2];
            answers[0] = doubleHeap.Min();
            answers[1] = doubleHeap.Max();
            var minLen = answers[1] - answers[0];

            while (true)
            {
                // remove min element from bst and insert its next element from its list.
                // if there's multiple elements with the same key, remove the one with min nextvalue from its list
                // end the process when we meet the first empty list
                var removeResult = doubleHeap.RemoveFirstNode();

                // skip elements within current range for performance, optional
                var nextIndexInList = removeResult.nextIndexInList;
                if (nums[removeResult.listIndex].Count == nextIndexInList)
                {
                    break;
                }
                
                var currentMax = doubleHeap.Max();
                while (nextIndexInList < nums[removeResult.listIndex].Count && nums[removeResult.listIndex][nextIndexInList] <= currentMax)
                {
                    nextIndexInList++;
                }
 
                if (nextIndexInList != removeResult.nextIndexInList)
                {
                    nextIndexInList--;
                }
                if (nums[removeResult.listIndex].Count == nextIndexInList)
                {
                    break;
                }

                doubleHeap.InsertNode(nums[removeResult.listIndex], removeResult.listIndex, nextIndexInList);
                if (minLen > doubleHeap.Max() - doubleHeap.Min())
                {
                    answers[0] = doubleHeap.Min();
                    answers[1] = doubleHeap.Max();
                    minLen = answers[1] - answers[0];
                }
            }

            return answers;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var answer = new Solution().SmallestRange(
                new List<IList<int>>()
                {
                    new List<int> {1}
                }
            );
            Console.WriteLine(answer[0]);
            Console.WriteLine(answer[1]);
        }
    }
}
