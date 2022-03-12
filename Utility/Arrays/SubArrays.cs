using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Arrays
{
    public class SubArrays
    {
        /// <summary>
        /// Find the contiguous subarray within an array, A of length N which has the largest sum.
        /// </summary>
        /// <param name="A">list of elements</param>
        /// <returns>Number</returns>
        public static int MaxSubArray(List<int> A)
        {
            int maxSum = A[0];
            int curSum = A[0];
            for (int i = 1; i < A.Count; i++){
                curSum = Math.Max(curSum + A[i], A[i]);
                maxSum = Math.Max(curSum, maxSum);
            }
            return maxSum;
            #region Optimal Approach 1
            //int max_sum = int.MinValue, currSum = 0;
            //for (int i = 0; i < A.Count; i++)
            //{
            //    currSum += A[i];
            //    max_sum = Math.Max(currSum, max_sum);
            //    if (currSum < 0) currSum = 0;
            //}
            //return max_sum;
            #endregion
            #region N^2 approach
            //int max_sum = int.MinValue;
            //for (int i = 0; i < A.Count; i++)
            //{
            //    int sum = 0;
            //    for (int j = i; j < A.Count; j++)
            //    {
            //        sum += A[j];
            //        max_sum = Math.Max(max_sum, sum);
            //    }
            //}
            //return max_sum;
            #endregion
        }

        // Find the sum of all subarray sums of A
        public static long SumOfSubarraySum(List<int> A)
        {
            // Contribution Technique: TC - O(N) | SC - O(1)
            // a0 a1 a2 a3.....ai-1 ai ai+1 ai+2......aN-1
            // (i+1)*(N-i)
            long sum = 0;
            long N = A.Count;
            for (int i = 0; i < N; i++)
            {
                long occurence = (long)((i + 1) * (N - i));
                sum += A[i] * occurence;
            }
            return sum;
            #region N^2
            //int overall_sum = 0;
            //for (int i = 0; i < A.Count; i++)
            //{
            //    int sum = 0;
            //    for (int j = i; j < A.Count; j++)
            //    {
            //        sum += A[j];
            //    }
            //    overall_sum += sum;
            //}
            //return overall_sum;
            #endregion
        }

        /// <summary>
        /// Given an array of size N, Find the subarray with least average of size k.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int SubArrayLeastAvg(List<int> A, int B)
        {
            // Sliding Window Technique
            int sum = 0, index = 0;
            for (int i = 0; i < B; i++)
            { // get sum of 1st k elements
                sum += A[i]; // O(N)
            }
            int minSum = sum; // store sum of 1st k elements
            for (int i = B; i < A.Count; i++)
            {
                sum += A[i]; // adding next element
                sum -= A[i - B]; // removing previous element
                if (sum < minSum)
                {
                    minSum = sum;
                    index = i - B + 1;
                }
            }
            return index; // O (2N) = O(N)
            #region N ^2
            //int leastAvg = int.MaxValue, avg;
            //int n = A.Count;
            //for (int i = 0; i <= n - B; i++)
            //{
            //    int sum = 0, j = i + B - 1;
            //    for (int x = i; x <= j; x++)
            //        sum += A[i];
            //    avg = sum / B;
            //    leastAvg = Math.Min(leastAvg, avg);
            //}
            //return leastAvg;
            #endregion
        }

        /// <summary>
        /// You are given an integer array C of size A. Now you need to find a subarray (contiguous elements) 
        /// so that the sum of contiguous elements is maximum.
        /// But the sum must not exceed B.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        public static int MaxSubArray(int A, int B, List<int> C)
        {
            int maxSum = 0;
            for (int i = 0; i < C.Count; i++)
            {
                int currSum = 0;
                for (int j = i; j < C.Count; j++)
                {
                    currSum += C[j];
                    if (currSum > maxSum && currSum <= B)
                        maxSum = currSum;
                }
            }
            return maxSum;
            //int currSum = 0, maxSum = int.MinValue;
            //for (int i = 0; i < A; i++)
            //{
            //    currSum += C[i];
            //    if (currSum > maxSum)
            //        maxSum = currSum;
            //    if (currSum < 0)
            //        currSum = 0;
            //}
            //return maxSum;
        }

        // H
        /// <summary>
        /// Given an array A of N non-negative numbers and you are also given non-negative number B.
        /// You need to find the number of subarrays in A having sum less than B.We may assume that there is no overflow.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int CountingSubArrays(List<int> A, int B)
        {
            int count = 0;
            for (int i = 0; i < A.Count; i++)
            {
                int currSum = 0;
                for (int j = i; j < A.Count; j++)
                {
                    currSum += A[j];
                    if (currSum < B)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Given an array of integers A.
        /// A subarray of an array is said to be good if it fulfils any one of the criteria:
        /// 1. Length of the subarray must be even and the sum of all the elements of the subarray must be less than B.
        /// 2. Length of the subarray must be odd and the sum of all the elements of the subarray must be greater than B.
        /// Your task is to find the count of good subarrays in A.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int GoodSubArays(List<int> A, int B)
        {
            int count = 0;
            for (int i = 0; i < A.Count; i++)
            {
                int sum = 0;
                for (int j = i; j < A.Count; j++)
                {
                    sum += A[j];
                    if ((j - i + 1) % 2 == 0 && sum < B)
                        count++;
                    else if ((j - i + 1) % 2 != 0 && sum > B)
                        count++;
                }
            }
            return count;
        }

        /// <summary>
        /// You are given an integer array A of length N comprising of 0's & 1's, and an integer B.
        /// You have to tell all the indices of array A that can act as a centre of 2 * B + 1 length 0-1 alternating subarray.
        /// A 0-1 alternating array is an array containing only 0's & 1's, and having no adjacent 0's or 1's.
        /// For e.g.arrays[0, 1, 0, 1], [1, 0] and[1] are 0-1 alternating, while [1, 1] and[0, 1, 0, 0, 1] are not.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<int> AlternateSubArrays(List<int> A, int B)
        {
            List<int> arr = new List<int>();
            int prev = A[0];
            int count = 0;
            if (B == 0) arr.Add(0); 
            for (int i = 1; i < A.Count; i++)
            {
                if (prev != A[i])
                {
                    count++;
                    if (count >= (2 * B))
                        arr.Add(i - B);
                    prev = A[i];
                }
                else
                {
                    if (B == 0)
                        arr.Add(i);
                    count = 0;
                }
            }
            return arr;
        }

        // =======================================================================================================


    }
}
