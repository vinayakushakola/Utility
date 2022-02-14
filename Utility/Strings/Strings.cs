using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Strings
{
    public class Strings
    {
        /// <summary>
        /// AQ1. Reverse the String
        /// </summary>
        /// <param name="A">a.</param>
        /// <returns></returns>
        public static string ReverseTheString(string A)
        {
            char[] arr = A.ToCharArray();
            int n = arr.Length - 1;
            for (int i = 0; i < n / 2; i++)
            {
                char c = arr[i];
                arr[i] = arr[n - 1 - i];
                arr[n - i - 1] = c;
            }
            int L = 0;
            for (int r = 0; r < n; r++)
            {
                if (arr[r] == ' ')
                {
                    int R = r - 1;
                    while (L < R)
                    {
                        char c = arr[L];
                        arr[L] = arr[R];
                        arr[R] = c;
                        L++;
                        R--;
                    }
                    L = r + 1;
                }
                if (r == n - 1)
                {
                    int R = r;
                    while (L < R)
                    {
                        char c = arr[L];
                        arr[L] = arr[R];
                        arr[R] = c;
                        L++;
                        R--;
                    }
                }

            }
            return new string(arr).Trim();
        }

        /// <summary>
        /// AQ2. Simple Reverse - reverse a given string 
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
        /// AQ#. Convert string to lower case letters
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
        /// AQ$. Convert given string to the upper case letters.
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
        /// AQ5. IsAlphaNumeric
        /// You are given a function isalpha() consisting of a character array A.
        /// Return 1 if all the characters of a character array are alphanumeric(a-z, A-Z and 0-9), else return 0.
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
        /// AQ6. Isalpha
        /// You are given a function isalpha() consisting of a character array A.
        /// Return 1 if all the characters of the character array are alphabetical(a-z and A-Z), else return 0.
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
        /// AQ7. Longest Palindromic Substring
        /// Given a string A of size N, find and return the longest palindromic substring in A.
        /// Substring of string A is A[i...j] where 0 <= i <= j<len(A)
        /// Palindrome string:
        /// A string which reads the same backwards.More formally, A is palindrome if reverse(A) = A.
        /// Incase of conflict, return the substring which occurs first (with the least starting index).
        /// </summary>
        /// <param name="A">a.</param>
        /// <returns></returns>
        public static string LongestPalindrome(string A)
        {
            int[] indexArr = new int[2];
            int[] maxArr = new int[] { 0, 0 };

            for (int i = 0; i < A.Length; i++)
            {
                //Odd length palindrome
                indexArr = getPalindromeLength(A, i, i);
                if ((maxArr[1] - maxArr[0]) < (indexArr[1] - indexArr[0]))
                {
                    maxArr[0] = indexArr[0];
                    maxArr[1] = indexArr[1];
                }

                //Even length palindrome
                indexArr = getPalindromeLength(A, i, i + 1);
                if ((maxArr[1] - maxArr[0]) < (indexArr[1] - indexArr[0]))
                {
                    maxArr[0] = indexArr[0];
                    maxArr[1] = indexArr[1];
                }
            }
            return A.Substring(maxArr[0], maxArr[1]);
        }
        private static int[] getPalindromeLength(String A, int i, int j)
        {
            int[] indexArr = new int[2];
            while ((i >= 0 && j < A.Length) && (A[i] == A[j]))
            {
                i--; j++;
            }
            indexArr[0] = i + 1;
            indexArr[1] = j - 1;
            return indexArr;
        }

        // =========================================================================================        
        /// <summary>
        /// HQ1. Amazing Substrings
        /// You are given a string S, and you have to find all the amazing substrings of S.
        /// Amazing Substring is one that starts with a vowel(a, e, i, o, u, A, E, I, O, U).
        /// </summary>
        /// <param name="A">a.</param>
        /// <returns></returns>
        public int AmazingSubstring(String A)
        {
            int res = 0;
            int size = A.Length;
            String vowels = "aeiou";
            A = A.ToLower();
            for (int i = 0; i < size; i++)
            {
                if (vowels.Contains(A[i]))
                    res += size - i;
            }
            return res % 10003;
        }

        /// <summary>
        /// HQ2. Count Occurrences
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

        /// <summary>
        /// HQ3. Change character
        /// Given a string A of size N consisting of lowercase alphabets.
        /// You can change at most B characters in the given string to any other lowercase 
        /// alphabet such that the number of distinct characters in the string is minimized.
        /// Find the minimum number of distinct characters in the resulting string.
        /// </summary>
        /// <param name="A">a.</param>
        /// <param name="B">The b.</param>
        /// <returns></returns>
        public int ChangeCharacter(string A, int B)
        {
            int[] count = new int[26];
            int distinct = 0;
            for (int i = 0; i < A.Length; i++)
            {
                count[A[i] - 'a']++;
                if (count[A[i] - 'a'] == 1)
                    distinct++;
            }

            int remove = 0;
            while (B > 0)
            {
                int min = 0;
                int index = 0;
                for (int i = 0; i < 26; i++)
                {
                    if (count[i] > min && min == 0)
                    {
                        min = count[i];
                        index = i;
                    }
                    else if (min > count[i] && count[i] != 0)
                    {
                        min = count[i];
                        index = i;
                    }
                }
                count[index] = 0;
                B = B - min;
                if (B >= 0)
                    remove++;
            }
            return distinct - remove;
        }

        /// <summary>
        /// HQ4. String operations
        /// Akash likes playing with strings. One day he thought of applying following operations on the string in the given order:
        /// Concatenate the string with itself.
        /// Delete all the uppercase letters.
        /// Replace each vowel with '#'.
        /// You are given a string A of size N consisting of lowercase and uppercase alphabets.Return the resultant string after applying the above operations.
        /// NOTE: 'a' , 'e' , 'i' , 'o' , 'u' are defined as vowels.
        /// </summary>
        /// <param name="A">a.</param>
        /// <returns></returns>
        public static string StringOperations(string A)
        {
            StringBuilder strA = new StringBuilder();
            string vowels = "aeiou";
            for (int i = 0; i < A.Length; i++)
            {
                if (vowels.Contains(A[i]))
                    strA.Append('#');
                else if (!(A[i] >= 'A' && A[i] <= 'Z'))
                    strA.Append(A[i]);

            }
            return strA + strA.ToString();
        }

        /// <summary>
        /// HQ5. Longest Common Prefix
        /// Given the array of strings A, you need to find the longest string S which is the prefix of ALL the strings in the array.
        /// Longest common prefix for a pair of strings S1 and S2 is the longest string S which is the prefix of both S1 and S2.
        /// For Example: longest common prefix of "abcdefgh" and "abcefgh" is "abc".
        /// </summary>
        /// <param name="A">a.</param>
        /// <returns></returns>
        public string LongestCommonPrefix(List<string> A)
        {
            List<String> lt = new List<String>();
            int min = int.MaxValue;
            String s = "";
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i].Length <= min)
                {
                    min = A[i].Length;
                    s = A[i];
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                lt.Add(s.Substring(0, i + 1));
            }
            while (min >= 1)
            {
                int f = 0;
                for (int i = 0; i < A.Count; i++)
                {
                    if (lt.Contains(A[i].Substring(0, min)))
                        f++;
                }
                if (f == A.Count)
                    return A[0].Substring(0, min);
                else
                    min--;
            }
            return "";
        }
    }
}


