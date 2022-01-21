using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Arrays
{
    public class BasicArray
    {
        public static int FindMaxElementCount(int[] arr)
        {
            // TC - O(N)
            // SC - O(1)
            int max_Ele = arr[0];
            int count = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max_Ele)
                {
                    max_Ele = arr[i];
                    count = 0;
                }
                if (arr[i] == max_Ele)
                    count++;
            }
            return count;
        }

        public static int[] ReverseArray(int[] arr)
        {
            int i = 0, j = arr.Length-1;
            while (i < j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = arr[i];
                i++;j--;
            }
            return arr;
        }

        public static List<int> ReverseArray(List<int> list)
        {
            int i = 0, j = list.Count - 1;
            while (i < j)
            {
                int temp = list[i];
                list[i] = list[j];
                list[j] = list[i];
                i++; j--;
            }
            return list;
        }

        public static void MinMax(List<int> list, out int min_Ele, out int max_Ele)
        {
            min_Ele = list[0]; 
            max_Ele = list[0];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > max_Ele)
                    max_Ele = list[i];
                else if (list[i] < min_Ele)
                    min_Ele = list[i];
            }
        }
    }
}
