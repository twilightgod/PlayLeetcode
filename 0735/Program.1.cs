using System;
using System.Collections.Generic;
using System.Linq;

namespace _0735_1
{
    // non-stack
    public class Solution
    {
        public int[] AsteroidCollision(int[] asteroids)
        {
            var answer = new List<int>();

            foreach (var a in asteroids)
            {
                if (a > 0)
                {
                    answer.Add(a);
                }
                else
                {
                    bool gone = false;
                    while (answer.Count > 0)
                    {
                        if (answer[answer.Count - 1] < 0)
                        {
                            break;
                        }
                        else if (-answer[answer.Count - 1] == a)
                        {
                            answer.RemoveAt(answer.Count - 1);
                            gone = true;
                            break;
                        }
                        else if (answer[answer.Count - 1] < -a)
                        {
                            answer.RemoveAt(answer.Count - 1);
                        }
                        else
                        {
                            gone = true;
                            break;
                        }
                    }
                    if (!gone)
                    {
                        answer.Add(a);
                    }
                }
            }

            return answer.ToArray();
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
