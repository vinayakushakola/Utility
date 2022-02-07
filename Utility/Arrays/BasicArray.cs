using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Arrays
{
    public class BasicArray
    {
        /// <summary>
        /// Given N array elements, count the no. of elements having atleast 1 element greater than itself
        /// </summary>
        /// <param name="arr">arr</param>
        /// <returns>returns the count of element which is less than max</returns>
        public static int FindCntOfEleLessThanMax(int[] arr)
        {
            #region Input 
            //Console.WriteLine("Count the no. of elements having atleast 1 element grater than itself {0}",
            //    BasicArray.FindCntOfEleLessThanMax(new int[] { 3, -2, 6, 8, 4, 8, 5 }));
            //Console.WriteLine("Count the no. of elements having atleast 1 element grater than itself {0}",
            //    BasicArray.FindCntOfEleLessThanMax(new int[] { 2, 5, 1, 4, 8, 0, 8, 1, 3, 8 }));
            #endregion
            // TC - O(N)
            // SC - O(1)
            int max_Ele = arr[0], count = 1, N = arr.Length;
            for (int i = 1; i < N; i++)
            {
                if (arr[i] > max_Ele)
                {
                    max_Ele = arr[i];
                    count = 0;
                }
                if (arr[i] == max_Ele)
                    count++;
            }
            return N - count;
        }

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

        public static bool FindPairEqualk(int[] arr, int k)
        {
            // TC - O(N^2) | SC - O(1)
            //int N = arr.Length;
            //for(int i = 0; i < N; i++)
            //{
            //    for (int j = i + 1; j < N; j++)
            //    {
            //        if (arr[i] + arr[j] == k)
            //            return true;
            //    }
            //}
            //return false;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int N = arr.Length;
            for (int i = 0; i < N; i++)
            {
                dict[arr[i]] = 0;
            }
            return false;
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
                list[j] = temp;
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

        /// <summary>
        /// Q5. You are given an integer T (Number of test cases). 
        /// For each test case, you are given array A and an integer B. 
        /// You have to tell whether B is present in array A or not
        /// </summary>
        public static void SearchElementInAnArray()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            for (int x = 0; x < T; x++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int B = Convert.ToInt32(Console.ReadLine());
                int N = Convert.ToInt32(input[0]);

                bool flag = true;
                for (int m = 0; m < N; m++)
                {
                    if (Convert.ToInt32(input[m + 1]) == B)
                    {
                        Console.WriteLine(1);
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    Console.WriteLine(0);
            }
        }

        //HW
        /// <summary>
        /// Q4. You are given an integer T denoting the number of test cases. For each test case, you are given an integer array A.
        /// You have to put the odd and even elements of array A in 2 separate arrays and print the new arrays.
        /// NOTE: Array elements should have same relative order as in A
        /// </summary>
        public static void SeparateOddEven()
        {
            #region Input
            /*
             2 
             5
             1 2 3 4 5
             3
             4 3 2
             */
            #endregion
            int testCases = Convert.ToInt32(Console.ReadLine());
            while (testCases > 0)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                string[] input = Console.ReadLine().Split(' ');
                List<int> evenArr = new List<int>();
                List<int> oddArr = new List<int>();
                for (int a = 0; a < N; a++)
                {
                    int ele = Convert.ToInt32(input[a]);
                    if (ele % 2 == 0)
                    {
                        evenArr.Add(ele);
                    }
                    else
                    {
                        oddArr.Add(ele);
                    }
                }
                for (int i = 0; i < oddArr.Count; i++)
                    Console.Write(oddArr[i] + " ");
                Console.WriteLine();
                for (int i = 0; i < evenArr.Count; i++)
                    Console.Write(evenArr[i] + " ");
                Console.WriteLine();
                testCases--;
            }
        }

        /// <summary>
        /// Q5. Given an array of integers A and multiple values in B which represents 
        /// number of times array A needs to be left rotated.
        /// Find the rotated array for each value and return the result in the from of a 
        /// matrix where i'th row represents the rotated array for the i'th value in B.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<List<int>> MultipleleftRotationsOfArray(List<int> A, List<int> B)
        {
            #region Input
            /*
            List<int> A = new List<int>() { 1,2,3,4,5 };
            List<int> B = new List<int>() { 2, 4 };
            List<List<int>>  op = BasicArray.MultipleleftRotationsOfArray(A, B);
             */
            #endregion
            List<List<int>> mat = new List<List<int>>();
            int N = A.Count;
            A = ReverseArray(A, 0, N - 1);
            for (int i = 0; i < B.Count; i++)
            {
                List<int> copyA = new List<int>(A);
                copyA = ReverseArray(copyA, 0, N - B[i]%N- 1);
                copyA = ReverseArray(copyA, N - B[i]%N, N-1);
            }
            mat.Add(A);
            return mat;
        }

        public static List<int> ReverseArray(List<int> A, int i, int j)
        {
            while (i < j)
            {
                int temp = A[i];
                A[i] = A[j];
                A[j] = temp;
                i++; j--;
            }
            return A;
        }

        /// <summary>
        /// Clock wise
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public List<List<int>> MultipleRightRotationsOfArray(List<int> A, List<int> B)
        {
            List<List<int>> mat = new List<List<int>>();
            int N = A.Count;
            A = ReverseArray(A, 0, N - 1);
            for (int i = 0; i < B.Count; i++)
            {
                List<int> copyA = new List<int>(A);
                copyA = ReverseArray(copyA, 0, B[i] - 1);
                copyA = ReverseArray(copyA, B[i], N - 1);
            }
            mat.Add(A);
            return mat;
        }
    }
}
