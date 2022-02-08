using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Strings
{
    public class Strings
    {
        /// <summary>
        /// AQ1. Simple Reverse - reverse a given string 
        /// </summary>
        /// <param name="A">a</param>
        /// <returns>returns the reversed string</returns>
        public static string ReverseString(string A)
        {
            char[] chArr = A.ToCharArray();
            int i = 0, j = A.Length - 1;
            while (i < j)
            {
                char temp = chArr[i];
                chArr[i] = chArr[j];
                chArr[j] = temp;
                i++; j--;
            }
            return new string(chArr);
        }

        /// <summary>
        /// Convert string to lower case letters
        /// </summary>
        /// <param name="A">a</param>
        /// <returns></returns>
        public List<char> to_lower(List<char> A)
        {
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] < 'a' && (A[i] >= 'A' && A[i] <= 'Z'))
                    A[i] = (char)(A[i] + 'a' - 'A');
            }
            return A;
        }

        /// <summary>
        /// Convert given string to the upper case letters.
        /// </summary>
        /// <param name="A">a</param>
        /// <returns></returns>
        public List<char> to_upper(List<char> A)
        {
            int N = A.Count;
            for (int i = 0; i < N; i++)
            {
                if (A[i] > 'Z' && (A[i] >= 'a' && A[i] <= 'z'))
                    A[i] = (char)(A[i] - ('a' - 'A'));
            }
            return A;
        }

        /// <summary>
        /// Determines whether [is alpha numeric number] [the specified A]
        /// </summary>
        /// <param name="A">a.</param>
        /// <returns></returns>
        public static int IsAlphaNumericNum(List<char> A)
        {

            for (int i = 0; i < A.Count; i++)
            {
                if (!(A[i] >= 'A' && A[i] <= 'Z'
                    || A[i] >= 'a' && A[i] <= 'z'
                    || A[i] >= '0' && A[i] <= '9'))
                    return 0;
            }
            return 1;
        }

        /// <summary>
        /// Determines whether [is only alphabets] [the specified A]
        /// </summary>
        /// <param name="A">a.</param>
        /// <returns></returns>
        public int IsOnlyAlphabets(List<char> A)
        {
            for (int i = 0; i < A.Count; i++)
            {
                if (!(A[i] >= 'A' && A[i] <= 'Z'
                || A[i] >= 'a' && A[i] <= 'z'))
                    return 0;
            }
            return 1;
        }

        /// <summary>
        /// Find number of occurrences of bob in the string A consisting of lowercase english alphabets.
        /// </summary>
        /// <param name="A">a</param>
        /// <returns></returns>
        public static int CountOccurrences(string A)
        {
            int cnt = 0, N = A.Length;
            for (int i = 0; i < N; i++)
            {
                if (A[i] == 'o')
                {
                    int l = i - 1 >= 0 ? i - 1 : i, r = i + 1 < N ? i + 1 : i;
                    if ((A[l] + A[i] + A[r]) == 'b' + 'o' + 'b')
                        cnt++;
                }
            }
            return cnt;
        }
    }
}


