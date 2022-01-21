using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Arrays
{
    public class PrefixArray
    {
        /// <summary>
        /// 4. You are given an integer array A of length N.
        /// You are also given a 2D integer array B with dimensions M x 2, where each row denotes a[L, R] query.
        /// For each query, you have to find the sum of all elements from L to R indices in A (1 - indexed).
        /// More formally, find A[L] + A[L + 1] + A[L + 2] +... + A[R - 1] + A[R] for each query.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<long> RangeSum(List<int> A, List<List<int>> B)
        {
            List<long> pfArr = new List<long>();
            pfArr.Add(A[0]);
            for (int i = 1; i < A.Count; i++)
                pfArr.Add(pfArr[i - 1] + A[i]);
            List<long> arr = new List<long>();
            foreach (var lst in B)
            {
                int L = lst[0] - 1;
                int R = lst[1] - 1;
                long sum = (long)(L == 0 ? pfArr[R] : pfArr[R] - pfArr[L - 1]);
                arr.Add(sum);
            }
            return arr;
        }

        //H
        /// <summary>
        /// Given an integer array A of size N. In one second you can increase the value of one element by 1.
        /// Find the minimum time in seconds to make all elements of the array equal.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int TimeToEquality(List<int> A)
        {
            int maxEle = A[0], N = A.Count;
            int sumOfElements = 0;
            for (int j = 0; j < N; j++)
            {
                if (maxEle < A[j])
                    maxEle = A[j];
                sumOfElements += A[j];
            }

            return N * maxEle - sumOfElements;
            #region Brute Force O(N+N)
            //int maxEle = A[0];
            //for (int i = 1; i < A.Count; i++)
            //{
            //    if (maxEle < A[i])
            //        maxEle = A[i];
            //}
            //int cnt = 0;
            //for (int j = 0; j < A.Count; j++)
            //{
            //    if (A[j] < maxEle)
            //        cnt += maxEle - A[j];
            //}
            //return cnt;
            #endregion
        }
    }
}
