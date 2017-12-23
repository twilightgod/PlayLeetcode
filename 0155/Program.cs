using System;
using System.Collections.Generic;

namespace _0155
{
    public class MinStack {

    private Stack<int> _ValStack = new Stack<int>();
    private Stack<int> _MinStack = new Stack<int>();
    
    /** initialize your data structure here. */
    public MinStack() {
        
    }
    
    public void Push(int x) {
        
        _ValStack.Push(x);
        
        if (_MinStack.Count == 0 || x < _MinStack.Peek())
        {
            _MinStack.Push(x);
        }
        else
        {
            _MinStack.Push(_MinStack.Peek());
        }
    }
    
    public void Pop() {
        _ValStack.Pop();
        _MinStack.Pop();
    }
    
    public int Top() {
        return _ValStack.Peek();    
    }
    
    public int GetMin() {
        return _MinStack.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
