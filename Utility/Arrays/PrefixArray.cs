using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Arrays
{
    public class PrefixArray
    {
        // SQ - Equilibrium Index -> return the count of equilibrium index 
        public static int EqilibriumIndex(List<int> list)
        {
            #region Parameter Input
            //Console.WriteLine("Count = " + PrefixArray.EqilibriumIndex(new List<int> { -7, 1, 5, 2, -4, 3, 0 }));
            //Console.WriteLine("Count = " + PrefixArray.EqilibriumIndex(new List<int> { 3, -1, 2, -1, 1, 2, 1 }));
            #endregion
            #region Brute Force: TC - O(N^2) | SC - O(1)
            //int sizeOfList = list.Count, count = 0;
            //for (int i = 0; i < sizeOfList; i++)
            //{
            //    int leftSum = 0, rightSum = 0;
            //    for (int j = 0; j < sizeOfList; j++)
            //    {
            //        if (j < i)
            //            leftSum += list[j];
            //        else if (j > i)
            //            rightSum += list[j];
            //    }
            //    if (leftSum == rightSum) count++;

            //}
            //return count;
            #endregion
            #region Prefix Array Appraoch: TC - O(N) | SC - O (N)
            List<int> prefixSumArr = GetPrefixArray(list);
            int sizeOfList = prefixSumArr.Count, leftSum = 0, rightSum = 0, count = 0;
            for (int i = 0; i < sizeOfList; i++)
            {
                leftSum = i == 0 ? 0 : prefixSumArr[i - 1];
                rightSum = prefixSumArr[sizeOfList - 1] - prefixSumArr[i];
                if (leftSum == rightSum) count++;
            }
            return count;
            #endregion
        }

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

        /// <summary>
        /// Q3. Given an integer array A of size N.
        /// You can pick B elements from either left or right end of the array A to get maximum sum.
        /// Find and return this maximum possible sum.
        /// NOTE: Suppose B = 4 and array A contains 10 elements then
        /// You can pick first four elements or can pick last four elements or can pick 1 from front and 3 from back etc.you need to return the maximum possible sum of elements you can pick
        /// </summary>
        public static int PickFromBothSides(List<int> A, int B)
        {
            int cs = 0;
            int ms = 0;
            for (int x = 0; x < B; x++)
            {
                cs += A[x];
            }
            ms = cs;
            int i = B - 1;
            int j = A.Count - 1;
            while (i >= 0)
            {
                cs -= A[i--];
                cs += A[j--];
                ms = Math.Max(cs, ms);
            }
            return ms;
            #region tle error
            /*
            int sum = int.MinValue, currentSum = 0;
            int n = A.Count;
            bool isSumInitialized = false;
            List<long> prefixA = GetPrefixArray(A);
            for (int i = 0; i <= B; i++)
            {
                currentSum = 0;
                int numOfLastElements = B - i;
                if (i == 0)
                {
                    currentSum += (int)(prefixA[n - 1] - prefixA[n - numOfLastElements - 1]);
                }
                else
                {
                    currentSum += (int)(prefixA[i - 1] + (prefixA[n - 1] - prefixA[n - numOfLastElements - 1]));
                }
                if (!isSumInitialized)
                {
                    sum = currentSum;
                    isSumInitialized = true;
                }
                else if (currentSum > sum)
                {
                    sum = currentSum;
                }
            }
            return sum;
            */
            #endregion
        }

        public static List<int> GetPrefixArray(List<int> A)
        {
            List<int> pfArr = new List<int>();
            pfArr.Add(A[0]);
            for (int i = 1; i < A.Count; i++)
                pfArr.Add(pfArr[i - 1] + A[i]);
            return pfArr;
        }


        //HW
        /// <summary>
        /// Q2. Given an array of integers A, find and return the product array of same size where i'th eement of the product array will be equal to the product of all the elements divided by the i'th element of the array.
        /// Note: It is always possible to form the product array with integer(32 bit) values.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> ProductArrayPuzzle(List<int> A)
        {
            List<int> pfArr = GetPrefixProductArray(A);
            List<int> productLst = new List<int>();
            for (int i = 0; i < A.Count; i++)
            {
                int product = pfArr[A.Count - 1] / A[i];
                productLst.Add(product);
            }
            return productLst;
        }

        public static List<int> GetPrefixProductArray(List<int> A)
        {
            List<int> pfArr = new List<int>();
            pfArr.Add(A[0]);
            for (int i = 1; i < A.Count; i++)
                pfArr.Add(pfArr[i - 1] * A[i]);
            return pfArr;
        }
    }
}
