using System;
using System.Collections.Generic;

namespace _0841
{
    public class Solution
    {
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            if (rooms == null || rooms.Count == 0)
            {
                return false;
            }
            var n = rooms.Count;
            var visited = new bool[n];
            visited[0] = true;
            DFS(rooms, 0, visited);
            var visitCount = 0;
            for (var i = 0; i < n; ++i)
            {
                if (visited[i])
                {
                    visitCount++;
                }
            }
            return visitCount == n;
        }

        private void DFS(IList<IList<int>> rooms, int roomId, bool[] visited)
        {
            foreach (var nextId in rooms[roomId])
            {
                if (!visited[nextId])
                {
                    visited[nextId] = true;
                    DFS(rooms, nextId, visited);
                }
            }
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
