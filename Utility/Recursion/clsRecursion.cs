using System;
using System.Collections.Generic;

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

        // ======================================================================================

        /// <summary>
        /// HQ1. Sum of Digits!
        /// Given a number A, we need to find sum of its digits using recursion.
        /// </summary>
        /// <param name="A">a</param>
        /// <returns>returns the sum of digits</returns>
        public static int SumOfDigits(int A)
        {
            // Assumptions return the sum of digits; 
            // Base Case
            if (A == 0) return 0;
            // Main logic
            int lastDigit = A % 10; // To get the last digit of the given number (remainder)
            A = A / 10;             // To get the digits from first to second last digit of the given number (quotient)  
            return SumOfDigits(A) + lastDigit; // Recursive Logic - return SumOfDigits(A/10) + A%10;
            /*  Ex: A = 123
                    F(123) = F(123/10) + 123%10; => F(A) = F(A/10) + lastDigit;  
                     F(12) = F(12/10) + 12%10;
                      F(1) = F(1/10) + 1%10;
                      F(0) = return 0
            */
        }

        /// <summary>
        /// HQ2. Recursive Functions
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public static int foo(int x, int y)
        {
            // Input foo(3,5) => Output: 243
            if (y == 0) return 1;
            return bar(x, foo(x, y - 1));
        }
        public static int bar(int x, int y)
        {
            if (y == 0) return 0;
            return (x + bar(x, y - 1));
        }

        public static int Fun(int x, int n)
        {
            if (n == 0) return 1;
            else if (n % 2 == 0) return Fun(x * x, n / 2);
            else return x * Fun(x * x, (n - 1) / 2);
        }

        // HQ1 - Kth Symbol
        public static int FindKthSymbol(int A, int B)
        {
            if (A == 1 && B == 1) return 0;
            int mid = (int)Math.Pow(2, A - 1) / 2;
            if (B <= mid)
                return FindKthSymbol(A - 1, B);
            else
                return 1 - (FindKthSymbol(A - 1, B - mid));
        }

        int num = 0;

        public List<int> grayCode(int a)
        {

            List<int> res = new List<int>();

            ComputeGrayCode(res, a);

            return res;

        }

        public void ComputeGrayCode(List<int> res, int a)
        {

            if (a == 0)
            {
                res.Add(num);
                return;
            }
            ComputeGrayCode(res, a - 1);
            num = num ^ (1 << (a - 1));
            ComputeGrayCode(res, a - 1);
        }
    }
}
