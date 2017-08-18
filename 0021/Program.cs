using System;

namespace _21
{
    /**
 * Definition for singly-linked list.*/
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }
 
public class Solution {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        var head = new ListNode(0);
        var current = head;

        while (l1 != null | l2 != null)
        {
            if (l1 == null || l1 != null && l2 != null && l2.val < l1.val)
            {
                current.next = l2;
                current = current.next;
                l2 = l2.next;
            }
            else
            {
                current.next = l1;
                current = current.next;
                l1 = l1.next;
            }
        }

        return head.next;
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
