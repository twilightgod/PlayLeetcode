using System;

namespace _0351
{
    public class Solution
    {
        public int NumberOfPatterns(int m, int n)
        {
            var visited = new bool[3, 3];
            var sequence = String.Empty;
            var answer = 0;
            for (var x = 0; x < 3; ++x)
            {
                for (var y = 0; y < 3; ++y)
                {
                    visited[x, y] = true;
                    DFS(m, n, ref answer, visited, x, y, 1/*, (x * 3 + y + 1).ToString()*/);
                    visited[x, y] = false;
                }
            }
            return answer;
        }

        private void DFS(int m, int n, ref int answer, bool[,] visited, int x, int y, int depth/*, string sequence*/)
        {
            if (depth >= m && depth <= n)
            {
                answer++;
                //Console.WriteLine(sequence);
                if (depth == n)
                {
                    return;
                }
            }

            for (var i = -2; i <= 2; ++i)
            {
                for (var j = -2; j <= 2; ++j)
                {
                    var newx = x + i;
                    var newy = y + j;
                    // in board and not visited
                    if (newx >= 0 && newx < 3 && newy >= 0 && newy < 3 && !visited[newx, newy])
                    {
                        var isNextValid = false;
                        var distance = i * i + j * j;
                        var absi = Math.Abs(i);
                        if (absi == 0)
                        {
                            absi = 1;
                        }
                        var absj = Math.Abs(j);
                        if (absj == 0)
                        {
                            absj = 1;
                        }

                        // don't need to check middle dots
                        if (distance <= 2 || distance == 5)
                        {
                            isNextValid = true;
                        }
                        /* hmm, it turns out 1 -> 8 is valid move, don't need to check middle dots, description is not clear
                        // 2 * 3 cross, 2 middle dot
                        else if (distance == 5)
                        {
                            if (visited[x + i / absi, y + j / absj])
                            {
                                if (absi > absj)
                                {
                                    if (visited[x + i / absi, y])
                                    {
                                        isNextValid = true;
                                    }
                                }
                                else
                                {
                                    if (visited[x, y + j / absj])
                                    {
                                        isNextValid = true;
                                    }
                                }
                            }
                        }
                        */
                        // 1 middle dot
                        else
                        {
                            if (visited[x + i / absi, y + j / absj])
                            {
                                isNextValid = true;
                            }
                        }

                        if (isNextValid)
                        {
                            visited[newx, newy] = true;
                            DFS(m, n, ref answer, visited, newx, newy, depth + 1/*, sequence + (newx * 3 + newy + 1).ToString()*/);
                            visited[newx, newy] = false;
                        }
                    }
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
