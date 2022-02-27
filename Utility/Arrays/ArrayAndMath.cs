using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Arrays
{
    public class ArrayAndMath
    {
        public static int FindMajorityElement(int[] A)
        {
            int cand = 0;
            int votes = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (votes == 0)
                {
                    cand = A[i];
                }
                if (A[i] == cand)
                {
                    votes++;
                }
                else
                {
                    votes--;
                }
            }
            return cand;
        }

        public static int FindHighestPowOf2(int N)
        {
            int res = 0;
            for (int i = N; i >= 1; i--)
            {
                // If i is a power of 2
                if ((i & (i - 1)) == 0)
                {
                    res = i;
                    break;
                }
            }
            return res;
        }

        public static int FindAP(int[] A)
        {
            int N = A.Length;
            if (N == 1 || N == 2)
                return 1;
            DSA.Sorting.SortingAlgo.MergeSort(A, 0, N - 1);
            int diff = A[N - 1] - A[N - 2];
            for (int i = N - 2; i > 0; i--)
            {
                if (A[i] - A[i - 1] != diff)
                    return 0;
            }
            return 1;
        }

        //HQ2 - Elements Removal
        public static int ElementsRemoval(List<int> A)
        {
            int cost = 0;
            A.Sort();
            for (int i = A.Count - 1; i > 0; i--)
            {
                cost = cost + A[i] + A[i - 1];
            }
            HashSet<int> hashSet = new HashSet<int>();
            return cost;
        }
    }
}
