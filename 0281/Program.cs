using System;
using System.Collections.Generic;

namespace _0281
{
    public class ListWithPos
    {
        public IList<int> List;
        public int Pos;
        public ListWithPos(IList<int> list, int pos)
        {
            this.List = list;
            this.Pos = pos;
        }
    }

    public class ZigzagIterator
    {
        LinkedListNode<ListWithPos> CurrentListPointer = null;
        LinkedList<ListWithPos> Lists = null;
        public ZigzagIterator(IList<int> v1, IList<int> v2)
        {
            Lists = new LinkedList<ListWithPos>();
            if (v1 != null && v1.Count > 0)
            {
                Lists.AddLast(new ListWithPos(v1, 0));
            }
            if (v2 != null && v2.Count > 0)
            {
                Lists.AddLast(new ListWithPos(v2, 0));
            }
            
            CurrentListPointer = Lists.First;
        }

        public bool HasNext()
        {
            return CurrentListPointer != null;
        }

        public int Next()
        {
            var val = CurrentListPointer.Value.List[CurrentListPointer.Value.Pos];
            var nextListPointer = CurrentListPointer.Next;
            if (++CurrentListPointer.Value.Pos == CurrentListPointer.Value.List.Count)
            {
                Lists.Remove(CurrentListPointer);
            }
            CurrentListPointer = nextListPointer;
            if (CurrentListPointer == null)
            {
                CurrentListPointer = Lists.First;
            }
            return val;
        }
    }

    /**
     * Your ZigzagIterator will be called like this:
     * ZigzagIterator i = new ZigzagIterator(v1, v2);
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
