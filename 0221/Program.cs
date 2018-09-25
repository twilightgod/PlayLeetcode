using System;

namespace _0221
{
    public class Solution {
    public int MaximalSquare(char[,] matrix) 
    {
        var m = matrix.GetLength(0);
        var n = matrix.GetLength(1);

        var f = new int[m, n];
        var answer = 0;

        for (var i = 0; i < m; ++i)
        {
            for (var j = 0; j < n; ++j)
            {
                if (matrix[i, j] == '1')
                {
                    f[i, j] = Math.Min(Math.Min(GetF(f, i - 1, j), GetF(f, i, j - 1)), GetF(f, i - 1,  j - 1)) + 1;
                    answer = Math.Max(answer, f[i, j]);
                }
            }
        }

        return answer * answer;
    }

    private int GetF(int[,] f, int x, int y)
    {
        if (x < 0 || y < 0)
        {
            return 0;
        }
        else
        {
            return f[x, y];
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
