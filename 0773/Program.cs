using System;
using System.Collections.Generic;
using System.Text;

namespace _0773
{
    public class Solution
    {
        public int SlidingPuzzle(int[,] board)
        {
            var sb = new StringBuilder();
            foreach (var c in board)
            {
                sb.Append(c);
            }
            var start = sb.ToString();
            var end = "123450";
            var move = new int[]{1, -1, 3, -3};
            var step = new Dictionary<string, int>();
            var pre = new Dictionary<string, string>();
            var q = new Queue<string>();
            step.Add(start, 0);
            pre[start] = start;
            q.Enqueue(start);
            while (q.Count > 0)
            {
                var cur = q.Dequeue();
                if (cur == end)
                {
                    /*
                    for (var p = end; pre[p] != p; p = pre[p])
                    {
                        Console.WriteLine(p);
                    }
                     */
                    return step[cur];
                }
                var idx = cur.IndexOf('0');
                for (var i = 0; i < 4; ++i)
                {
                    if (i == 0 && idx == 2 || i == 1 && idx == 3)
                    {
                        continue;
                    }
                    var target = idx + move[i];
                    if (target >= 0 && target < 6)
                    {
                        var arr = cur.ToCharArray();
                        arr[idx] = cur[target];
                        arr[target] = '0';
                        var next = new String(arr);
                        if (!step.ContainsKey(next))
                        {
                            step.Add(next, step[cur] + 1);
                            pre[next] = cur;
                            q.Enqueue(next);
                        }
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
