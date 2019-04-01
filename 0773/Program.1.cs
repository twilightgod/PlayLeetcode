using System;
using System.Collections.Generic;
using System.Text;

namespace _0773_1
{
    public class Solution
    {
        public int SlidingPuzzle(int[][] board)
        {
            if (board == null)
            {
                return -1;
            }
            var sb = new StringBuilder();
            foreach (var row in board)
            {
                foreach (var c in row)
                {
                    sb.Append(c);
                }
            }
            var start = sb.ToString();
            var end = "123450";
            var step = new Dictionary<string, int>();
            var q = new Queue<string>();
            var moves = new int[] { -1, 1, 3, -3 };
            q.Enqueue(start);
            step[start] = 0;

            while (q.Count > 0)
            {
                var cur = q.Dequeue();
                if (cur == end)
                {
                    return step[end];
                }
                var idx0 = cur.IndexOf('0');
                for (var i = 0; i < 4; ++i)
                {
                    if (i == 1 && idx0 == 2 || i == 0 && idx0 == 3)
                    {
                        continue;
                    }
                    var idx1 = idx0 + moves[i];
                    if (idx1 < 0 || idx1 >= 6)
                    {
                        continue;
                    }
                    var carr = cur.ToCharArray();
                    (carr[idx0], carr[idx1]) = (carr[idx1], carr[idx0]);
                    var next = new String(carr);
                    if (!step.ContainsKey(next))
                    {
                        step[next] = step[cur] + 1;
                        q.Enqueue(next);
                    }
                }
            }

            return -1;
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
