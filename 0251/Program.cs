using System;
using System.Collections.Generic;

namespace _0251
{
    public class Vector2D
    {

        IEnumerator<IList<int>> idx1 = null;
        IEnumerator<int> idx2 = null;

        private IList<IList<int>> vec2d = null;

        public Vector2D(IList<IList<int>> vec2d)
        {
            this.vec2d = vec2d;
            idx1 = vec2d.GetEnumerator();
            idx2 = idx1.Current.GetEnumerator();
        }

        public bool HasNext()
        {
            if (idx1 >= vec2d.Count)
            {
                return false;
            }
            return true;
        }

        public int Next()
        {
            var ret = vec2d[idx1][idx2];
            idx2++;
            while (idx1 < vec2d.Count && idx2 >= vec2d[idx1].Count)
            {
                idx1++;
                idx2 = 0;
            }
            return ret;
        }
    }

    /**
     * Your Vector2D will be called like this:
     * Vector2D i = new Vector2D(vec2d);
     * while (i.HasNext()) v[f()] = i.Next();
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
