using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    public class Pattern
    {
        public static void DiamondPattern(int N)
        {
            int i, j;
            for (i = 1; i <= N; i++)
            {
                for (j = 1; j <= N; j++)
                {
                    if (j < N - i + 1)
                        Console.Write(" ");
                    else
                        Console.Write("* ");
                }
                Console.WriteLine();
            }
            for (i = 1; i <= N; i++)
            {
                for (j = N; j >= 1; j--)
                {
                    if (j > N - i + 1)
                        Console.Write(" ");
                    else
                        Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
