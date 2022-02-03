using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.BitManipulation
{
    public class Bit
    {
        public static int SingleNumber(List<int> A)
        {
            int ans = 0;
            for (int i = 0; i < A.Count; i++)
            {
                ans = ans ^ A[i];
            }
            return ans;
        }

        public static bool CheckBitSetOrUnset(int N, int i)
        {
            // Ex: N = 10 int bit it would represent as 1010 & i = 2
            Console.WriteLine(1 << 1);
            return true;
        }

    }
}
