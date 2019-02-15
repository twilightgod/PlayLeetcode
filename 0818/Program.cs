using System;
using System.Collections.Generic;

namespace _0818
{
    public class Solution
    {
        public int Racecar(int target)
        {
            // (position, facing right), only record abs(speed) == 1
            var visited = new HashSet<(int, bool)>();
            // (position, speed, step)
            var q = new Queue<(int, int, int)>();

            visited.Add((0, true));
            // (0, -1) won't be better than (0, 1)
            //visited.Add((0, false));
            q.Enqueue((0, 1, 0));

            while (q.Count > 0)
            {
                var (pos, speed, step) = q.Dequeue();
                if (pos == target)
                {
                    return step;
                }

                // acc
                var next_pos = pos + speed;
                var next_speed = speed << 1;
                var next_step = step + 1;
                if (next_pos <= (target << 1) && next_speed <= (target << 1))
                {
                    q.Enqueue((next_pos, next_speed, next_step));
                }

                // reverse
                next_pos = pos;
                next_speed = speed > 0 ? -1 : 1;
                var key = (next_pos, next_speed > 0);
                if (!visited.Contains(key))
                {
                    visited.Add(key);
                    q.Enqueue((next_pos, next_speed, next_step));
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
