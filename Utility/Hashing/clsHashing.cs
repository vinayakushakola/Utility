using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Hashing
{
    public class clsHashing
    {
        /// <summary>
        /// AQ1. Subarray with given sum
        /// Given an array of positive integers A and an integer B, find and return first continuous subarray which adds to B.
        /// If the answer does not exist return an array with a single element "-1".
        /// First sub-array means the sub-array for which starting index in minimum.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <param name="n">The n.</param>
        /// <param name="sum">The sum.</param>
        /// <returns></returns>
        public static List<int> SubArraySum(List<int> arr, int n, int sum)
        {
            long curr_sum = arr[0];
            List<int> ans = new List<int>{ -1 }; 
            int start = 0, i;
            // Pick a starting point
            for (i = 1; i <= n; i++)
            {
                // If curr_sum exceeds the sum,
                // then remove the starting elements
                while (curr_sum > sum && start < i - 1)
                {
                    curr_sum = curr_sum - arr[start];
                    start++;
                }

                // If curr_sum becomes equal to sum,
                // then return true
                if (curr_sum == sum)
                {
                    //return Array.Copy(arr, start, i);
                }

                // Add this element to curr_sum
                if (i < n)
                    curr_sum = curr_sum + arr[i];
            }
            return ans;
        }

        /// <summary>
        /// AQ4. 2 Sum
        /// Ex: Input: [2, 7, 11, 15], target=9
        ///    Output: index1 = 1, index2 = 2
        /// </summary>
        /// <param name="A">a.</param>
        /// <param name="B">The b.</param>
        /// <returns></returns>
        public List<int> TwoSum(List<int> A, int B)
        {
            List<int> a = new List<int>{ 0, 1 };
            Dictionary<int, int> m = new Dictionary<int, int>();
            for (int i = 0; i < A.Count; i++)
            {
                if (m.ContainsKey(B - A[i]))
                {
                    a[0] = m[B - A[i]] + 1;
                    a[1] = i + 1;
                    a.Sort();
                    return a;
                }
                else if (!m.ContainsKey(A[i])) 
                    m[A[i]] = i;
            }
            return new List<int>();
        }
    }
}
