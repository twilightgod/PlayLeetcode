using System;
using System.Collections.Generic;
using System.Linq;

namespace _0218_old
{
    class Program
    {

        public class Solution
        {
            public class Line
            {
                public int L { set; get; }

                public int R { set; get; }

                public int H { set; get; }

                public Line(int L, int R, int H)
                {
                    this.L = L;
                    this.R = R;
                    this.H = H;
                }
            }

            public IList<int[]> GetSkyline(int[,] buildings)
            {
                var result = new List<int[]>();

                var MinL = Int32.MaxValue;
                var MaxR = 0;
                var building_roofs = new List<Line>();
                for (var i = 0; i < buildings.GetLength(0); ++i)
                {
                    building_roofs.Add(new Line(buildings[i, 0], buildings[i, 1], buildings[i, 2]));
                    if (MinL > buildings[i, 0])
                    {
                        MinL = buildings[i, 0];
                    }
                    if (MaxR < buildings[i, 1])
                    {
                        MaxR = buildings[i, 1];
                    }
                }

                // sort the roofs by H, L, R, to ensure the correctness of overlap area calcualtion (e.g. [[0, 2, 1], [0, 1, 2], [0, 1, 1]])
                building_roofs.Sort((x, y) =>
                        x.H == y.H ?
                            x.L == y.L ?
                                x.R.CompareTo(y.R) :
                                x.L.CompareTo(y.L) :
                            x.H.CompareTo(y.H)
                    );

                var roofs = new List<Line>();
                var roofs_tmp = new List<Line>();

                // add horizon
                if (building_roofs.Count > 0)
                {
                    roofs.Add(new Line(MinL, Int32.MaxValue, 0));
                }

                for (var i = 0; i < building_roofs.Count; ++i)
                {
                    roofs_tmp.Clear();
                    var roofi = building_roofs[i];
                    var handled = false;

                    foreach (var roof in roofs)
                    {
                        // roofi already mergered into existing roof, add the rest untoughed
                        if (handled)
                        {
                            roofs_tmp.Add(roof);
                        }
                        /* roofi merges with roof
                            ----------------
                            |       |      |
                        */
                        else if (roofi.H == roof.H && roofi.L <= roof.R)
                        {
                            roofs_tmp.Add(new Line(Math.Min(roofi.L, roof.L), Math.Max(roofi.R, roof.R), roof.H));
                            handled = true;
                        }
                        /* roofi totally cover roof
                            -----------------
                            |               |
                            |   ---------   |
                            |   |       |   |
                        */
                        else if (roofi.H > roof.H && roofi.L <= roof.L && roof.R <= roofi.R)
                        {
                            continue;
                        }
                        /* roofi partially cover roof
                            ---------
                            |       |        
                            |   ----------   
                            |   |   |    |   


                                   ----------
                                   |        |
                               ----------   |
                               |   |    |   |


                                   ----
                                   |  |
                                ----------
                                |  |  |  |
                        */
                        else if (roofi.H > roof.H && (roof.L < roofi.L && roofi.L < roof.R || roof.L < roofi.R && roofi.R < roof.R))
                        {
                            if (roofi.L > roof.L)
                            {
                                roofs_tmp.Add(new Line(roof.L, roofi.L, roof.H));
                            }
                            if (roofi.R < roof.R)
                            {
                                roofs_tmp.Add(new Line(roofi.R, roof.R, roof.H));
                            }
                        }
                        // roof doesn't get impacted by roofi
                        else
                        {
                            roofs_tmp.Add(roof);
                        }

                    }

                    if (!handled)
                    {
                        roofs_tmp.Add(roofi);
                    }

                    roofs.Clear();
                    roofs.AddRange(roofs_tmp);
                }

                foreach (var roof in roofs)
                {
                    result.Add(new int[] { roof.L, roof.H });
                }

                result.Sort((x, y) => x[0].CompareTo(y[0]));

                // last corner
                if (result.Count > 0 && result[result.Count - 1][0] != MaxR)
                {
                    result.Add(new int[] { MaxR, 0 });
                }
                return result;
            }
        }
        static void Main(string[] args)
        {
            var g = new Solution().GetSkyline(new int[,] { { 2, 9, 10 }, { 3, 7, 15 }, { 5, 12, 12 } });
            var c = new Solution().GetSkyline(new int[,] { { 0, 2, 3 }, { 2, 5, 3 } });
            var f = new Solution().GetSkyline(new int[,] { { 5, 10, 12 }, { 10, 15, 7 } });
            var e = new Solution().GetSkyline(new int[,] { { 15, 20, 10 }, { 19, 24, 8 } });
            var d = new Solution().GetSkyline(new int[,] { { 0, 2, 3 }, { 0, 2, 3 } });
            var b = new Solution().GetSkyline(new int[,] { { 0, 2147483647, 2147483647 } });
            var a = new Solution().GetSkyline(new int[,] { { 2, 9, 10 }, { 3, 7, 15 }, { 5, 12, 12 }, { 15, 20, 10 }, { 19, 24, 8 } });
            Console.WriteLine("1");
        }
    }
}
