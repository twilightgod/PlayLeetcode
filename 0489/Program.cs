using System;
using System.Collections.Generic;

namespace _0489
{
    /**
 * // This is the robot's control interface.
 * // You should not implement it, or speculate about its implementation
 */
    class Robot
    {
        // Returns true if the cell in front is open and robot moves into the cell.
        // Returns false if the cell in front is blocked and robot stays in the current cell.
        public bool Move()
        {
            return true;
        }

        // Robot will stay in the same cell after calling turnLeft/turnRight.
        // Each turn will be 90 degrees.
        public void TurnLeft() { }
        public void TurnRight() { }

        // Clean the current cell.
        public void Clean() { }
    }
    class Solution
    {
        // clockwise
        // U, R, D, L
        int[,] moves = new int[4, 2] {{-1, 0}, {0, 1}, {1, 0}, {0, -1}};

        public void CleanRoom(Robot robot)
        {
            var visited = new HashSet<(int, int)>();
            visited.Add((0, 0));
            DFS(robot, 0, 0, 0, visited);
        }

        private void DFS(Robot robot, int x, int y, int direction, HashSet<(int, int)> visited)
        {
            robot.Clean();

            for (var i = direction; i < 4 + direction; ++i)
            {
                // try move in direction i
                var nextd = i % 4;
                var nextx = x + moves[nextd, 0];
                var nexty = y + moves[nextd, 1];
                if (!visited.Contains((nextx, nexty)))
                {
                    visited.Add((nextx, nexty));
                    if (robot.Move())
                    {
                        DFS(robot, nextx, nexty, nextd, visited);
                    }
                }
                robot.TurnRight();
            }

            // move back to previous position
            // U turn
            robot.TurnRight();
            robot.TurnRight();
            // move back
            robot.Move();
            // restore direction
            robot.TurnRight();
            robot.TurnRight();
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
