using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.ModularArithmetic
{
    public class ModularArithmetic
    {
        /// <summary>
        /// i/p: ABCD or AA or AB
        /// Given a column title as appears in an Excel sheet, return its corresponding column number.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int GetExcelColNo(string A)
        {
            int ans = 0;
            for (int i = 0; i < A.Length; i++)
            {
                ans = ans * 26 + (A[i] - 65 + 1);
            }
            return ans;
        }


        /// <summary>
        /// A, B and Modulo
        /// Given two integers A and B, find the greatest possible positive M, such that A % M = B % M.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int FindABModulo(int A, int B)
        {
            return Math.Abs(A - B);
        }

        /// <summary>
        /// AQ3. Given a number A in the form of string. Check if the number is divisible by 8 or not.
        /// Return 1 if it is divisible by 8 else return 0.
        /// Divs the by eight.
        /// </summary>
        /// <param name="A">a.</param>
        /// <returns></returns>
        public static int DivByEight(string A)
        {
            int N = A.Length;
            if (N == 0) return 0;
            else if (N == 1) return (A[0] - '0') % 8 == 0 ? 1 : 0;
            else if (N == 2) return (((A[N-2] - '0') * 10) + A[N-1] - '0') % 8 == 0 ? 1 : 0;
            int l, l2, l3;
            l = A[N - 1] - '0'; l2 = (A[N - 2] - '0')*10; l3 = (A[N - 3] - '0')*100;
            return (l3 + l2 + l) % 8 == 0 ? 1 : 0;
        }

        /// <summary>
        /// AQ4. You are given a huge number in the form of a string A where each character denotes a digit of the number.
        /// You are also given a number B.You have to find out the value of A % B and return it.
        /// Finds the mod.
        /// </summary>
        /// <param name="A">a.</param>
        /// <param name="B">The b.</param>
        /// <returns></returns>
        public static int FindMod(string A, int B)
        {
            long ans = 0, r = 1;
            int N = A.Length;
            for (int i = N-1; i >= 0; i--)
            {
                ans = ans + ((A[i] - '0') * r)%B;
                r = (r * 10) % B;
            }
            return (int)ans % B;
        }
    }
}
