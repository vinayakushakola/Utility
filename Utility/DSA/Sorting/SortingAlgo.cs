using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.DSA.Sorting
{
    public class SortingAlgo
    {
        public static void MergeSort(int[] arr, int si, int ei)
        {
            if (si >= ei) return;
            int mid = si + (ei - si) / 2;
            MergeSort(arr, si, mid);
            MergeSort(arr, mid+1, ei);
            Merge(arr, si, mid, ei);
        }

        private static void Merge(int[] arr, int si, int mid, int ei)
        {
            int[] mergedArr = new int[ei - si + 1];
            int idx1 = si, idx2 = mid+1, mi = 0;

            while (idx1 <= mid && idx2 <= ei)
            {
                if (arr[idx1] <= arr[idx2])
                    mergedArr[mi++] = arr[idx1++];
                else
                    mergedArr[mi++] = arr[idx2++];
            }

            while (idx1 <= mid)
                mergedArr[mi++] = arr[idx1++];
            while (idx2 <= ei)
                mergedArr[mi++] = arr[idx2++];

            for (int i = 0, j = si; i < mergedArr.Length; i++, j++)
                arr[j] = mergedArr[i];
        }

        public static void MergeSort(List<int> arr, int si, int ei)
        {
            if (si >= ei) return;
            int mid = si + (ei - si) / 2;
            MergeSort(arr, si, mid);
            MergeSort(arr, mid + 1, ei);
            Merge(arr, si, mid, ei);
        }

        private static void Merge(List<int> arr, int si, int mid, int ei)
        {
            List<int> mergedArr = new List<int>();
            int idx1 = si, idx2 = mid + 1, mi = 0;

            while (idx1 <= mid && idx2 <= ei)
            {
                if (arr[idx1] <= arr[idx2])
                {
                    mergedArr.Add(arr[idx1++]);
                    mi++;
                }
                else
                {
                    mergedArr.Add(arr[idx2++]);
                    mi++;
                }
            }

            while (idx1 <= mid)
            {
                mergedArr.Add(arr[idx1++]);
                mi++;
            }
            while (idx2 <= ei)
            {
                mergedArr.Add(arr[idx2++]);
                mi++;
            }

            for (int i = 0; i < mergedArr.Count; i++)
                arr.Add(mergedArr[i]);
        }
    }
}
