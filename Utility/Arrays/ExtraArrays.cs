using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Arrays
{
    public class ExtraArrays
    {
        public static int LongestLenOfConsecutivesOnes(string A)
        {
            //Console.WriteLine(ExtraArrays.LongestLenOfConsecutivesOnes("010100110101"));
            //Console.WriteLine(ExtraArrays.LongestLenOfConsecutivesOnes("0000"));
            int cnt = 0, ans = 0, len = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == '1')
                    cnt++;
            }
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == '0')
                {
                    int l = 0;
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (A[j] == '0')
                            break;
                        else if (A[j] == '1')
                            l++;
                    }
                    int r = 0;
                    for (int k = i + 1; k < A.Length; k++)
                    {
                        if (A[k] == '0')
                            break;
                        else if (A[k] == '1')
                            r++;
                    }
                    if (l + r < cnt)
                        len = l + r + 1;
                    else
                        len = l + r;
                    ans = Math.Max(ans, len);
                }
            }
            if (cnt == A.Length)
                ans = cnt;
            return ans;
        }

        /// <summary>
        /// You are given an array A consisting of heights of Christmas trees, and an array B of same size consisting of the cost of each of the trees (Bi is the cost of tree Ai, where 1 ≤ i ≤ size(A)), and you are supposed to choose 3 trees (let's say, indices p, q and r), such that Ap < Aq < Ar, where p < q < r.
        /// The cost of these trees is Bp + Bq + Br.
        /// You are to choose 3 such trees, so they have the minimum cost and find the minimum cost.
        /// If not possible to choose 3 such trees, return -1.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int ChristmasTree(List<int> A, List<int> B)
        {
            int N = A.Count;
            int minCost = int.MaxValue;
            for (int j = 1; j < N - 1; j++)
            {
                int cost = 0, ci = int.MaxValue, ck = int.MaxValue;
                for (int i = 0; i < j; i++)
                {
                    if (A[i] < A[j])
                        ci = Math.Min(ci, B[i]);
                }
                for (int k = j + 1; k < N; k++)
                {
                    if (A[j] < A[k])
                        ck = Math.Min(ck, B[k]);
                }
                if (ci == int.MaxValue || ck == int.MaxValue) continue;
                else cost = ci + B[j] + ck;
                minCost = Math.Min(cost, minCost);
            }
            return minCost == int.MaxValue ? -1 : minCost;
            #region Brute Force TC - O(N^3)
            /*
            int N = A.Count;
            int minCost = int.MaxValue;
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    for (int k = j + 1; k < N; k++)
                    {
                        if (A[i] < A[j] && A[j] < A[k])
                            minCost = Math.Min(minCost, B[i] + B[j] + B[k]);
                    }
                }
            }
            return minCost;
            */
            #endregion
        }

        //HW
        /// <summary>
        /// Q1. Given an array of integers A, of size N.
        /// Return the maximum size subarray of A having only non-negative elements.
        /// If there are more than one such subarrays, return the one having the earliest starting index in A.
        /// NOTE: It is guaranteed that an answer always exists.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> MaximumPositivitySubarray(List<int> A)
        {
            int n = A.Count;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int maxLen = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (A[j] >= 0)
                    {
                        maxLen = Math.Max(maxLen, j - i + 1);
                        dict[i] = j;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            List<int> res = new List<int>();
            int start = 0, end = n;

            foreach (var mapElement in dict)
            {
                int key = (int)mapElement.Key;
                int value = (int)mapElement.Value;
                if (value - key + 1 == maxLen)
                {
                    start = key;
                    end = value;
                    break;
                }
            }

            int k = 0;
            for (int i = start; i <= end; i++)
            {
                res.Add(A[i]);
                k++;
            }

            return res;
        }

        /// <summary>
        /// Write a program to input an integer N from user and print hollow diamond star pattern series of N lines.
        /// See example for clarifications over the pattern.
        /// </summary>
        public static void StarPattern()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (j < N - i)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                for (int j = N-1; j >= 0; j--)
                {
                    if (j < N - i)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = N-1; j >= 0; j--)
                {
                    if (j >= N - i - 1)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                for (int j = 0; j < N; j++)
                {
                    if (j >= N-1-i)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
            
        }


        public static int GetMajorityElement(List<int> A)
        {
            int majorityEle = A[0];
            int cnt = 0;
            return majorityEle;
        }
    }
}
