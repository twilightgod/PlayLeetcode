using System;
using System.Collections.Generic;

namespace _0729
{
    public class MyCalendar
    {
        List<(int Start, int End)> meetings = new List<(int Start, int End)>(); 

        public MyCalendar()
        {

        }

        public bool Book(int start, int end)
        {
            if (!IsConflict(start, end))
            {
                meetings.Add((start, end));
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsConflict(int start, int end)
        {
            foreach (var meeting in meetings)
            {
                if (!(end <= meeting.Start || start >= meeting.End))
                {
                    return true;
                }
            }

            return false;
        }
    }

    /**
     * Your MyCalendar object will be instantiated and called as such:
     * MyCalendar obj = new MyCalendar();
     * bool param_1 = obj.Book(start,end);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
