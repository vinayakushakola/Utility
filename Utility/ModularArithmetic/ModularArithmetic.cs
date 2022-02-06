using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.ModularArithmetic
{
    public class ModularArithmetic
    {
        /// <summary>
        /// i/p: ABCD or AA or AB
        /// AQ1. Given a column title as appears in an Excel sheet, return its corresponding column number.
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
        /// AQ2. Given two integers A and B, find the greatest possible positive M, such that A % M = B % M.
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

        // ==============================================        
        /// <summary>
        /// HQ2. Concatenate Three Numbers
        /// Given three 2-digit integers, A, B and C, find out the minimum number that can be obtained 
        /// by concatenating them in any order.
        /// Return the minimum result that can be obtained.
        /// </summary>
        /// <param name="A">number</param>
        /// <param name="B">number</param>
        /// <param name="C">number</param>
        /// <returns></returns>
        public static int ConcatenateMinNumber(int A, int B, int C)
        {
            string ans = "";
            if (A <= B && A <= C)
            {
                ans += A.ToString();
                if (B <= C)
                    ans += B.ToString() + C.ToString();
                else
                    ans += C.ToString() + B.ToString();
            }
            else if (B < A && B < C)
            {
                ans += B.ToString();
                if (A <= C)
                    ans += A.ToString() + C.ToString();
                else    
                    ans += C.ToString() + A.ToString();
            }
            else
            {
                ans += C.ToString();
                if (A <= B)
                    ans += A.ToString() + B.ToString();
                else
                    ans += B.ToString() + A.ToString();
            }
            return int.Parse(ans);
        }

        /// <summary>
        /// HQ4. Leap year? - III
        /// Given an integer A representing an year, Return 1 if it is a leap year else return 0.
        /// A year is leap year if the following conditions are satisfied:
        /// Year is multiple of 400.
        /// Year is multiple of 4 and not multiple of 100.
        /// </summary>
        /// <param name="Year">The year.</param>
        /// <returns></returns>
        public static int LeapYear(int Year)
        {
            if (Year % 4 == 0 && Year % 100 != 0 || Year % 400 == 0)
                return 1;
            return 0;
        }

        /// <summary>
        /// HQ5. Least Common Multiple
        /// You are given two non-negative integers A and B, find the value of Least Common Multiple (LCM) of A and B.
        /// LCM of two integers is the smallest positive integer that is divisible by both.
        /// </summary>
        /// <param name="A">a.</param>
        /// <param name="B">The b.</param>
        /// <returns></returns>
        public static int LeastCommonMultiple(int A, int B)
        {
            return (A / GCD(A, B)) * B;
        }

        public static int GCD(int a, int b)
        {
            if (a == 0)
                return b;
            return GCD(b % a, a);
        }
    }
}
