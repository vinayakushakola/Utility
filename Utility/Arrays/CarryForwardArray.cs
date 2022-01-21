using System;
using System.Collections.Generic;

namespace Utility.Arrays
{
    public class CarryForwardArray
    {
        /// <summary>
        /// You have given a string A having Uppercase English letters.
        /// You have to find that how many times subsequence "AG" is there in the given string.
        /// NOTE: Return the answer modulo 10^9 + 7 as the answer can be very large.
        /// i/p = "ACGAAG"
        /// </summary>
        /// <returns>Number</returns>
        public static int FindPairCount(string str)
        {
            // Optimal Approach TC - O(N) | SC - O(1)
            int ans = 0; int count_A = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'A')
                    count_A++;
                else if (str[i] == 'G')
                    ans += count_A;
            }
            return ans;
            #region Brute Force TC - O(N^2) | SC - O(1)
            //int count = 0;
            //for (int i = 0; i < str.Length; i++)
            //{
            //    if (str[i] == 'A')
            //    {
            //        for (int j = i; j < str.Length; j++)
            //        {
            //            if (str[j] == 'G')
            //                count++;      
            //        }
            //    }
            //}
            //return count;
            #endregion
        }


        /// <summary>
        /// { 16, 17, 17, 4, 3, 5, 2 }
        /// Given an array A if N integers, find all the leaders.
        /// Ex: A leader is strictly greater than all elements to its right
        /// </summary>
        /// <param name="list">list of array</param>
        /// <returns>Number</returns>
        public static int FindLeadersInArray(List<int> list)
        {
            int leaderCnt = 1;
            int max = list[list.Count - 1];
            for (int i = list.Count - 2; i >= 0; i--)
            {
                if (list[i] > max)
                    leaderCnt++;
            }
            return leaderCnt;
        }

        /// <summary>
        /// Closest Min Max
        /// Given an array A. Find the size of the smallest subarray such that it contains 
        /// atleast one occurrence of the maximum value of the array and atleast one 
        /// occurrence of the minimum value of the array.
        /// Console.WriteLine("Smallest Sub Array length = {0}", 
        /// CarryForwardArray.FindSmallestSubArray(new List<int> { 2,3,1,5,6,2,3,1 }));
        /// </summary>
        /// <param name="list"></param>
        public static int FindSmallestSubArray(List<int> list)
        {
            // TC - O(N) | Sc- O(1)
            int min_Ele, max_Ele;
            int last_Min = -1, last_Max = -1;
            BasicArray.MinMax(list, out min_Ele, out max_Ele);
            if (min_Ele == max_Ele)
                return 1;
            int len = list.Count;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == min_Ele)
                {
                    last_Min = i;
                    if (last_Max >= 0 && last_Min >= 0)
                        len = Math.Min(len, last_Max > last_Min ? last_Max - last_Min + 1 : last_Min - last_Max + 1);
                }
                else if (list[i] == max_Ele)
                {
                    last_Max = i;
                    if (last_Max >= 0 && last_Min >= 0)
                        len = Math.Min(len, last_Max > last_Min ? last_Max - last_Min + 1 : last_Min - last_Max + 1);
                }
            }
            return len;
            #region Brute Force TC - N + N^2 = O(N^2) | SC - O(1)
            //int min_Ele = list[0], max_Ele = list[0];
            //for (int i = 0; i < list.Count; i++)
            //{
            //    if (list[i] > max_Ele)
            //        max_Ele = list[i];
            //    else if (list[i] < min_Ele)
            //        min_Ele = list[i];
            //}
            //int len = list.Count;
            //for (int j = 0; j < list.Count; j++)
            //{
            //    if (list[j] == min_Ele)
            //    {
            //        for (int k = j; k < list.Count; k++)
            //        {
            //            if (list[k] == max_Ele)
            //                len = Math.Min(len, k-j+1);
            //        }
            //    }
            //    else if (list[j] == max_Ele)
            //    {
            //        for (int k = j; k < list.Count; k++)
            //        {
            //            if (list[k] == min_Ele)
            //                len = Math.Min(len, k-j+1);
            //        }
            //    }
            //}
            //return len;
            #endregion
        }

        /// <summary>
        /// DirectI, Amazon, OLA, Cisco & Visa
        /// Given N bulbs connected to a wire, Every N has two tatest On Off
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int FindNoOfTimesStateChangedofAnElement(List<int> list)
        {
            /*
             * look_for=0
count=0
for i in range(len(A)):
if A[i]==look_for:
count+=1
look_for=1-look_for print(count)
             */

            int btnPressed = 0, currBtnState;
            for (int i = 0;i<list.Count; i++)
            {
                if (btnPressed % 2 == 0)
                    currBtnState = list[i];
                else
                    currBtnState = 1 - list[i];
                if (currBtnState == 0)
                    btnPressed++;
            }
            return btnPressed;
            #region Brute Force TC - O(N^2) | Sc - O(1)
            //int cnt = 0;
            //for (int i = 0; i< list.Count; i++)
            //{
            //    if (list[i] == 0)
            //    {
            //        cnt++;
            //        for (int j = i; j< list.Count; j++)
            //        {
            //            list[i] = 1 - list[i];
            //        }
            //    }
            //}
            //return cnt;
            #endregion
        }
    }
class Solution
    {
        public int solve(List<int> A)
        {
            int min_Ele;
            int max_Ele;
            MinMax(A, out min_Ele, out max_Ele);
    
            int last_Min = -1, last_Max = -1;
            int len = A.Count;
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] == min_Ele)
                {
                    last_Min = i;
                    len = Math.Min(len, last_Max > last_Min ? last_Max - last_Min + 1 : last_Min - last_Max + 1);
                }
                else if (A[i] == max_Ele)
                {
                    last_Max = i;
                    len = Math.Min(len, last_Max > last_Min ? last_Max - last_Min + 1 : last_Min - last_Max + 1);
                }
            }
            return len;
        }

        public static void MinMax(List<int> arr, out int min_Ele, out int max_Ele)
        {
            min_Ele = arr[0];
            max_Ele = arr[0];
            for (int i = 1; i < arr.Count; i++)
            {
                if (arr[i] > max_Ele)
                    max_Ele = arr[i];
                else if (arr[i] < min_Ele)
                    min_Ele = arr[i];
            }
        }
    }

}
