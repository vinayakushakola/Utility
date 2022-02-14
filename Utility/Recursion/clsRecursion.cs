using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Recursion
{
    public class clsRecursion
    {
        public static int IsPalindrome(string A, int start, int end)
        {
            if (start >= end)
                return 1;
            if (A[start] != A[end])
                return 0;
            return IsPalindrome(A, start + 1, end - 1);
        }
    }
}
