using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Hashing
{
    public class Hashing
    {
        /// <summary>
        /// SQ1. Given an array of size N d queries
        /// Every query n integer
        /// Return frequency of u in away
        /// </summary>
        /// <param name="List">The list.</param>
        public static Dictionary<int, int> FreqOfArray(List<int> list)
        {
            int sizeOfArray = list.Count;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < sizeOfArray; i++)
            {
                if (dict.ContainsKey(list[i]))
                {
                    int value = 0;
                    dict.TryGetValue(list[i], out value);
                    dict.Add(list[i], value++);
                }
                else
                    dict.Add(list[i], 1);
            }
            return dict;
        }

        /// <summary>
        /// SQ2 Given an array court the no of distinct ele in
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static int CountDistinctEle(List<int> list)
        {
            int sizeOfArray = list.Count;
            HashSet<int> resSet = new HashSet<int>();
            for (int i = 0; i < sizeOfArray; i++)
            {
                resSet.Add(list[i]);
            }
            return resSet.Count;
        }

        /// <summary>
        /// SQ3 get longest subarray length
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static int GetLengthOfLargestSubArr(List<int> list)
        {
            int sizeOfArray = list.Count;
            int length = 0;
            List<int> pfArr = new List<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            pfArr.Add(list[0]);
            for (int i = 1; i < sizeOfArray; i++)
            {
                pfArr.Add(pfArr[i - 1] + list[i]);
            }
            for (int i = 0; i < sizeOfArray; i++)
            {
                if (dict.ContainsKey(list[i]))
                {
                    length = Math.Max(length, i - dict[list[i]]);
                }
                else
                {
                    dict.Add(list[i], i);
                }
            }
            return length;
        }

        // ==================================================================================================
        /// <summary>
        /// AQ3. Largest Continuous Sequence Zero Sum
        /// Given an array A of N integers.
        /// Find the largest continuous sequence in a array which sums to zero.
        /// </summary>
        /// <param name="A">a.</param>
        /// <returns></returns>
        public static int LargestSeqZero(int[] A)
        {

            return 1;
        }

        /// <summary>
        /// AQ3. Largest Continuous Sequence Zero Sum
        /// Given an array A of N integers.
        /// Find the largest continuous sequence in a array which sums to zero.
        /// </summary>
        /// <param name="A">a.</param>
        /// <returns></returns>
        public static List<int> LargestSeqZero(List<int> A)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            List<int> resArr = new List<int>();
            int[] prefixSum = new int[A.Count];
            int maxLength = 0;

            prefixSum[0] = A[0];
            for (int i = 1; i < A.Count; i++)
                prefixSum[i] = prefixSum[i - 1] + A[i];

            int startIndex = -1;
            int endIndex = -1;
            for (int i = 0; i < prefixSum.Length; i++)
            {
                if (prefixSum[i] == 0)
                {
                    maxLength = Math.Max(i + 1, maxLength);
                    startIndex = 0;
                    endIndex = i;
                }
                else
                {
                    if (!dict.ContainsKey(prefixSum[i]))
                    {
                        dict.Add(prefixSum[i], i);
                    }
                    else
                    {
                        int length = i - dict[prefixSum[i]];

                        if (length > maxLength)
                        {
                            maxLength = length; //Math.Max(length, maxLength);
                            startIndex = 1 + dict[prefixSum[i]];
                            endIndex = i;
                        }
                    }
                }
            }

            if (startIndex == -1 && endIndex == -1)
                return resArr;

            for (int i = startIndex; i <= endIndex; i++)
                resArr.Add(A[i]);

            return resArr;
        }
        public List<int> LargestSeqZero2(List<int> A)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int sum = 0;
            int i = -1;
            int maxLength = 0;
            List<int> ans = new List<int>();
            int startIdx = -1;
            int endIdx = -1;

            dict.Add(sum, -1);

            while (i < A.Count - 1)
            {
                // first increment
                i++;
                sum += A[i];
                if (!dict.ContainsKey(sum))
                {
                    dict.Add(sum, i);
                }
                else
                {
                    // Find out the the prev pos
                    int length = i - dict[sum];

                    if (length > maxLength)
                    {
                        maxLength = length;
                        startIdx = dict[sum] + 1;
                        endIdx = i;
                    }
                }
            }

            if (startIdx == -1 && endIdx == -1)
                return new List<int>();

            for (int j = startIdx; j <= endIdx; j++)
                ans.Add(A[j]);

            return ans;
        }

        /// <summary>
        /// Q4. Sub-array with 0 sum
        /// Given an array of integers A, find and return whether the given array 
        /// contains a non-empty subarray with a sum equal to 0.
        /// If the given array contains a sub-array with sum zero return 1 else return 0.
        /// </summary>
        /// <param name="A">a.</param>
        /// <returns></returns>
        public static int SubArraySumZero(List<int> A)
        {
            int sizeOfArray = A.Count;
            List<int> pfArr = new List<int>();
            pfArr.Add(A[0]);
            for (int i = 1; i < sizeOfArray; i++)
            {
                pfArr.Add(pfArr[i - 1] + A[i]);
            }
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict.Add(0, 0);
            for (int j = 0; j < sizeOfArray; j++)
            {
                for (int i = 0; i < sizeOfArray; i++)
                {
                    int sum = 0;
                    if (dict.ContainsKey(pfArr[i]))
                    {
                        int startIndex = 0;
                        dict.TryGetValue(pfArr[i], out startIndex);
                        sum = startIndex == 0 ? pfArr[i] : pfArr[i] - pfArr[startIndex - 1];
                        if (sum == 0) return 1;
                    }
                    else
                    {
                        dict.Add(A[i], i);
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// AQ5. Shaggy and distances
        /// Shaggy has an array A consisting of N elements. We call a pair of distinct indices in that 
        /// array as a special pair if elements at that index in the array are equal.
        /// Shaggy wants you to find a special pair such that distance between that pair is minimum.
        /// Distance between two indices is defined as |i-j|. If there is no special pair in the array then return -1.
        /// </summary>
        /// <param name="A">a</param>
        /// <returns></returns>
        public static int ShaggyDistance(List<int> A)
        {
            int sizeOfArray = A.Count;
            Dictionary<int, int> map = new Dictionary<int, int>();
            int minLen = int.MaxValue;
            for (int i = 0; i < sizeOfArray; i++)
            {
                if (map.ContainsKey(A[i]))
                {
                    int diff = Math.Abs(i - map[A[i]]);
                    minLen = Math.Min(minLen, diff);
                }
                else
                    map.Add(A[i], i);
            }
            if (minLen == int.MaxValue) return -1;
            return minLen;
        }

        // ===================================================================================================
        /// <summary>
        /// HQ1. K Occurrences
        /// Groot has N trees lined up in front of him where the height of the i'th tree is denoted by H[i].
        /// He wants to select some trees to replace his broken branches.
        /// But he wants uniformity in his selection of trees.
        /// So he picks only those trees whose heights have frequency K.
        /// He then sums up the heights that occur K times. (He adds the height only once to the sum and not K times).
        /// But the sum he ended up getting was huge so he prints it modulo 10^9+7.
        /// In case no such cluster exists, Groot becomes sad and prints -1.
        /// </summary>
        /// <param name="A">a.</param>
        /// <param name="B">The b.</param>
        /// <param name="C">The c.</param>
        /// <returns></returns>
        public static int GetSum(int A, int B, List<int> C)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int ans = 0;
            for (int i = 0; i < C.Count; i++)
            {
                if (dict.ContainsKey(C[i]))
                    dict[C[i]] = dict[C[i]] + 1;
                else
                    dict.Add(C[i], 1);
            }
            foreach (var item in dict)
            {
                if (item.Value >= B)
                    ans = ans + item.Key;
            }
            if (ans == 0 && dict.ContainsKey(0) && dict[0] == B)
                return 0;

            return (ans > 0) ? ans : -1;
        }

        /// <summary>
        /// HQ2. Check Palindrome - II
        /// Given a string A consisting of lowercase characters.
        /// Check if characters of the given string can be rearranged to form a palindrome.
        /// Return 1 if it is possible to rearrange the characters of the string A such that 
        /// it becomes a palindrome else return 0.
        /// </summary>
        /// <param name="A">a.</param>
        /// <returns></returns>
        public static int CheckPalindrome2(string A)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            char[] chArray = A.ToCharArray();
            int sizeOfString = A.Length;
            int cnt = 0;

            for (int i = 0; i < sizeOfString; i++)
            {
                if (dict.ContainsKey(chArray[i]))
                    dict[chArray[i]] = dict[chArray[i]] + 1;
                else
                    dict.Add(chArray[i], 1);
            }

            foreach (var item in dict)
            {
                if (item.Value % 2 != 0)
                    cnt++;
            }

            if (cnt == 1 || cnt == 0) return 1;
            return 0;
        }

        /// <summary>
        /// HQ3. Colorful Number
        /// For Given Number A find if its COLORFUL number or not.
        /// If number A is a COLORFUL number return 1 else return 0.
        /// What is a COLORFUL Number:
        /// A number can be broken into different contiguous sub-subsequence parts. 
        /// Suppose, a number 3245 can be broken into parts like 3 2 4 5 32 24 45 324 245. 
        /// And this number is a COLORFUL number, since product of every digit of a contiguous subsequence is different.
        /// </summary>
        /// <param name="A">a</param>
        /// <returns></returns>
        public static int ColorfulNumber(int A)
        {
            HashSet<int> set = new HashSet<int>();
            int prev = -1;
            int n = 10;
            while (A > 0)
            {
                int currDigit = A % n;
                A = A / n;
                if (set.Count == 0)
                {
                    set.Add(currDigit);
                    prev = currDigit;
                    continue;
                }
                if (set.Contains(currDigit)) return 0;
                set.Add(currDigit);
                if (set.Contains(currDigit * prev)) return 0;
                set.Add(currDigit * prev);
                prev = currDigit;
            }
            return 1;
        }
    }
}
