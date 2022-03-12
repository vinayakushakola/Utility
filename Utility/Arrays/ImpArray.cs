using System;
using System.Collections.Generic;

namespace Utility.Arrays
{
    public class ImpArray
    {
        // Rotate an array by k to left - clockwise from end
        public static void RotateArrayBykLeft(int[] arr, int k)
        {
            int sizeOfArr = arr.Length; 
            ReverseArray(arr, 0, sizeOfArr-1);
            ReverseArray(arr, 0, k%sizeOfArr - 1);
            ReverseArray(arr, k%sizeOfArr, sizeOfArr - 1);
        }

        // Rotate an array by k to right - anti-clockwise from start
        public static void RotateArrayByKRight(int[] arr, int k)
        {
            int sizeOfArr = arr.Length;
            ReverseArray(arr, 0, sizeOfArr - 1);
            ReverseArray(arr, 0, sizeOfArr - k%sizeOfArr - 1);
            ReverseArray(arr, sizeOfArr - k % sizeOfArr, sizeOfArr - 1);
        }

        // Reverse an array
        public static void ReverseArray(int[] arr, int si, int ei)
        {
            int sizeOfArr = arr.Length;
            while (si < ei)
            {
                int temp = arr[si];
                arr[si] = arr[ei];
                arr[ei] = temp;
                si++; ei--;
            }
        }

        #region Prefix Sum
        // An index is said to be equilibrium index if
        // sum of elements before ith index = sum of elements after ith index. Return count of eq index
        public static int EquilibriumIndex(int[] arr)
        {
            int sizeOfArr = arr.Length;
            int[] prefixSum = new int[sizeOfArr];
            prefixSum[0] = arr[0];
            int count = 0;

            // Prefix Sum
            for (int i = 1; i < sizeOfArr; i++)
                prefixSum[i] = prefixSum[i - 1] + arr[i];
            
            for (int i = 0; i < sizeOfArr; i++)
            {
                int leftSum = i == 0 ? 0 : prefixSum[i - 1];
                int rightSum = prefixSum[sizeOfArr - 1] - prefixSum[i];
                if (leftSum == rightSum) count++;
            }
            return count;
        }

        // Google | Media.Net
        // An index will be called special index if after deleting that index
        // sum of even index value = sum of odd index value
        // return the count of special index
        public static int SpecialIndex(int[] A)
        {
            int N = A.Length;
            int[] pfEven = new int[N];
            int[] pfOdd = new int[N];
            pfEven[0] = A[0];
            pfOdd[0] = 0;
            for (int i = 1; i < N; i++)
            {
                if (i % 2 == 0)
                {
                    pfEven[i] = pfEven[i - 1] + A[i];
                    pfOdd[i] = pfOdd[i - 1];
                }
                else
                {
                    pfOdd[i] = pfOdd[i - 1] + A[i];
                    pfEven[i] = pfEven[i - 1];
                }
            }
            int cnt = 0;
            for (int k = 0; k < N; k++)
            {
                int sumEven = k == 0 ? pfOdd[N-1] : pfEven[k - 1] + (pfOdd[N - 1] - pfOdd[k]);
                int sumOdd = k == 0 ? pfEven[N-1]-pfEven[0] : pfOdd[k - 1] + (pfEven[N - 1] - pfEven[k]);
                if (sumOdd == sumEven)
                    cnt++;
            }
            return cnt;
        }
        #endregion

        #region Carry Forward
        // Given a string s count the pairs 'a' 'g'
        public static int CountPairs(string str)
        {
            // Carry Forward Technique
            int size = str.Length;
            int pairCnt = 0, count_a = 0;
            for (int i = 0; i < size; i++)
            {
                if (str[i] == 'a')
                    count_a++;
                else if (str[i] == 'g')
                    pairCnt += count_a;
            }
            return pairCnt;
        }

        // Find the smallest continuous part of array s.t it
        // contains both the min man value of the array
        public static int ClosestMinMax(int[] arr, int min, int max)
        {
            // Edge Case
            if (min == max) return 1;
            int last_minI = -1, last_maxI = -1, len = int.MaxValue;
            int size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                if (arr[i] == min)
                {
                    last_minI = i;
                    if (last_maxI >= 0)
                        len = Math.Min(len, Math.Abs(last_maxI - last_minI) + 1);
                }
                else if (arr[i] == max)
                {
                    last_maxI = i;
                    if (last_minI >= 0)
                        len = Math.Min(len, Math.Abs(last_maxI - last_minI) + 1); 
                }
            }
            return len;
        }
        
        public static int ClosestMinMax(int[] arr)
        {
            int last_minI = int.MaxValue, last_MaxI = int.MaxValue, size = arr.Length, len = arr.Length;
            int min = int.MaxValue, max = int.MinValue;
            for (int i = size-1; i >= 0; i--)
            {
                if (arr[i] < max && arr[i] > min)
                    continue;
                else if (arr[i] > max)
                {
                    max = arr[i];
                    last_MaxI = i;
                    len = size;
                }
                else if (arr[i] == max)
                    last_MaxI = i;
                else if (arr[i] < min)
                {
                    min = arr[i];
                    last_minI = i;
                    len = size;
                }
                else if (arr[i] == min)
                    last_minI = i;
                len = Math.Min(len, Math.Abs(last_minI- last_MaxI) +1);
            }
            return len;
        }

        // Directv 0cal Amazon Cisco visa Clue Given N bulbs connected by a wire
        // Evely n bulb has two states
        public static int ToggleBlub(int[] Arr)
        {
            // TC - O(n^2) | SC - O(1)
            int size = Arr.Length, count = 0;
            for (int i = 0; i < size; i++)
            {
                if (Arr[i] == 0)
                {
                    count++;
                    for (int j = i; j < size; j++)
                        Arr[i] = 1 - Arr[i];
                }
            }
            return count;
        }

        // Given no of button presses before reaching a specific inden can we identify
        // the current state of that bulb
        public static int SwitchPressed(int[] Arr)
        {
            // 10101
            int size = Arr.Length;  //5
            int switchPressed = 0;  //0 
            int currState = Arr[0]; //1
            for (int i = 0; i < size; i++)//0|1|2|3|4
            {
                if (switchPressed % 2 == 0) //0|0|1|0|1
                    currState = Arr[i];     //1|0|0
                else
                    currState = 1 - Arr[i]; //0|0
                if (currState == 0) switchPressed++;//0|1|2|3|4
            }
            return switchPressed; //4
        }
        #endregion

        #region Sliding Window Technique
        // Max suesarray sum with length k
        public static int MaxSubarraySumK(int[] Arr, int k)
        {
            #region Input 
            //int[] arr = { 1, -3, 4, 2, 6, 9, 2 };
            //int count = ImpArray.MaxSubarraySumK(arr, 3);
            #endregion
            int size = Arr.Length;
            int maxSum = int.MinValue;
            #region Brute Force TC - O(n^2)
            /*
            for (int i = 0; i <= size-k; i++)
            {
                int sum = 0;
                for (int j = i; j <= i + k - 1; j++)
                {
                    sum += Arr[j];
                }
                maxSum = Math.Max(sum, maxSum);
            }
            */
            #endregion
            // Sliding Window Technique
            int sum = 0;
            for (int i = 0; i < k; i++)
                sum += Arr[i];
            for (int i = k; i < size; i++)
            {
                sum += Arr[i];
                sum -= Arr[i - k];
                maxSum = Math.Max(sum, maxSum);
            }

            return maxSum;
        }
        #endregion

        #region Contribution Technique
        // Google | Bloomberg | Amazon
        // Sum of subarray sum
        public static int IndexKPresent(int[] Arr)
        {
            int size = Arr.Length;
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                int appears = (i + 1) * (size - i);

                int contribution = Arr[i] * appears;

                sum += contribution;
            }
            return sum;
        }
        #endregion
    }
}
