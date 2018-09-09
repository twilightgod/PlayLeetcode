using System;
using System.Collections.Generic;

namespace _0173
{
    /**
 * Definition for binary tree */
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }


public class BSTIterator {

    private Stack<TreeNode> NodeStack = null;

    public BSTIterator(TreeNode root) {
        NodeStack = new Stack<TreeNode>();

        var CurrentNode = root;
        while (CurrentNode != null)
        {
            NodeStack.Push(CurrentNode);
            CurrentNode = CurrentNode.left;
        }
    }

    /** @return whether we have a next smallest number */
    public bool HasNext() {
        return NodeStack.Count > 0;
    }

    /** @return the next smallest number */
    public int Next() {
        var CurrentNode = NodeStack.Pop();
        var value = CurrentNode.val;
        
        if (CurrentNode.right != null)
        {
            // right subtree is larger than root
            // go right subtree and find its left most node
            CurrentNode = CurrentNode.right;
            while (CurrentNode != null)
            {
                NodeStack.Push(CurrentNode);
                CurrentNode = CurrentNode.left;
            }
        }

        return value;
    }
}

/**
 * Your BSTIterator will be called like this:
 * BSTIterator i = new BSTIterator(root);
 * while (i.HasNext()) v[f()] = i.Next();
 */
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(5);
//            root.left = new TreeNode(3);
            root.right = new TreeNode(6);
    //        root.left.right = new TreeNode(4);
            var iter = new BSTIterator(root);
            while (iter.HasNext())
            {
                Console.WriteLine(iter.Next());
            } 
            Console.WriteLine("Hello World!");
        }
    }
}
