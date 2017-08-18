using System;

namespace _19
{
    /**
 Definition for singly-linked list. */
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }

public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var newhead = new ListNode(0);
        newhead.next = head;
        var endpoint = newhead;
        var deletepoint = newhead;
        for (int i = 0; i < n + 1; ++i)
        {
            endpoint = endpoint.next;
        }

        while (endpoint != null)
        {
            endpoint = endpoint.next;
            deletepoint = deletepoint.next;
        }

        deletepoint.next = deletepoint.next.next;

        return newhead.next;
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
