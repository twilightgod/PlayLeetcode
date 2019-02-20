using System;

namespace _0427
{
    /*
// Definition for a QuadTree node.
*/
    public class Node
    {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;

        public Node() { }
        public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }

    public class Solution
    {
        public Node Construct(int[][] grid)
        {
            var n = grid.GetLength(0);
            return CreateNodeDFS(grid, 0, 0, n - 1, n - 1);
        }

        private Node CreateNodeDFS(int[][] grid, int x0, int y0, int x1, int y1)
        {
            var node = new Node();
            var resultAll = CheckSame(grid, x0, y0, x1, y1);
            if (resultAll.isSame)
            {
                node.val = resultAll.val;
                node.isLeaf = true;
            }
            else
            {
                var x2 = (x0 + x1) >> 1;
                var y2 = (y0 + y1) >> 1;
                node.topLeft = CreateNodeDFS(grid, x0, y0, x2, y2);
                node.topRight = CreateNodeDFS(grid, x0, y2 + 1, x2, y1);
                node.bottomLeft = CreateNodeDFS(grid, x2 + 1, y0, x1, y2);
                node.bottomRight = CreateNodeDFS(grid, x2 + 1, y2 + 1, x1, y1);
            }
            return node;
        }

        private (bool isSame, bool val) CheckSame(int[][] grid, int x0, int y0, int x1, int y1)
        {
            var val = grid[x0][y0] == 1;
            for (var i = x0; i <= x1; ++i)
            {
                for (var j = y0; j <= y1; ++j)
                {
                    if ((grid[i][j] == 1) != val)
                    {
                        return (false, false);
                    }
                }
            }
            return (true, val);
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
