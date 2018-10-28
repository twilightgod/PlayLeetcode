using System;
using System.Collections.Generic;

namespace _0853
{
    public class Car
    {
        public int Position;
        public int Speed;
        public double Time;
    }

    public class Solution
    {
        public int CarFleet(int target, int[] position, int[] speed)
        {
            if (position == null || position.Length == 0)
            {
                return 0;
            }

            var n = position.Length;
            var cars = new List<Car>(n);
            for (var i = 0; i < n; ++i)
            {
                cars.Add(new Car(){Position = position[i], Speed = speed[i], Time = (target - position[i]) * 1d / speed[i]});
            }
            cars.Sort((a, b) => -a.Position.CompareTo(b.Position));
            var answer = 1;
            var leader = cars[0];
            for (var i = 1; i < n; ++i)
            {
                if (cars[i].Time > leader.Time)
                {
                    answer++;
                    leader = cars[i];
                }
            }

            return answer;
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
