using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Arrays
{
    public class TwoDMatrices
    {
        public static void PrintTwoDMatrix(List<List<int>> mat)
        {
            for (int i = 0; i < mat.Count; i++)
            {
                for (int j = 0; j < mat[i].Count; j++)
                {
                    Console.Write(mat[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// You are given two matrices A & B of same size, you have to return another matrix which is the sum of A and B.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<List<int>> AddMatrices(List<List<int>> A, List<List<int>> B)
        {
            List<List<int>> mat = new List<List<int>>();
            int N = A.Count;    // N rows 
            int M = A[0].Count; // M columns
            for (int i = 0; i < N; i++) {       // For loop for i from 0 - N-1 Rows
                List<int> l = new List<int>(); // creating new list for every row 
                for (int j = 0; j < M; j++) {   // For loop for j row from 0 to M-1 columns
                    l.Add(A[i][j] + B[i][j]);  // Addition of Matrix A + B from j = 0 to j = M-1 col
                    if (j == M - 1)            // j col = M-1 columns
                        mat.Add(l);            // Adding the list to the main matrix
                }
            }
            return mat;
            #region input
            /*
            List<List<int>> A = new List<List<int>>() { new List<int>{ 1, 2, 3 }, new List<int>{ 4, 5, 6 }, new List<int>{ 7, 8, 9 } };
            List<List<int>> B = new List<List<int>>() { new List<int> { 9, 8, 7 }, new List<int> { 6, 5, 4 }, new List<int> { 3, 2, 1 } };
            List<List<int>> op = TwoDMatrices.AddMatrices(A, B);
            foreach (var list in op)
            {
                foreach (int i in list)
                {
                    Console.WriteLine(i + " ");
                }
            }
             */
            #endregion
        }

        /// <summary>
        /// Give a N * N square matrix A, return an array of its anti-diagonals. Look at the example for more details.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<List<int>> GetDiagonal(List<List<int>> A)
        {
            #region Input
            /*
            List<List<int>> op = TwoDMatrices.GetDiagonal(A);
            foreach (var list in op)
            {
                foreach (int i in list)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            */
            #endregion
            List<List<int>> mat = new List<List<int>>();
            int N = A.Count;  // N Rows & Columns
            for (int col = 0; col < N; col++) // Forloop for rows from 1 to N-1
            {
                int startRow = 0, startCol = col; // For each column the start row is 0
                List<int> list = new List<int>();
                while (startRow < N)
                {
                    if (startCol >= 0)
                        list.Add(A[startRow][startCol]);
                    else
                        list.Add(0);
                    startRow++; startCol--;
                }
                mat.Add(list);
            }
            for (int row = 1; row < N; row++) // Forloop for rows from 1 to N-1
            {
                int startRow = row, startCol = N - 1; // For each row the start column is N-1
                List<int> list = new List<int>();
                while (startCol >= 0)
                {
                    if (startRow < N)
                        list.Add(A[startRow][startCol]);
                    else
                        list.Add(0);
                    startRow++; startCol--;
                }
                mat.Add(list);
            }
            return mat;
            #region Simpler way
            // For those who is getting confusion in above mention code can refer the below mention code which is little simpler than above.
            //List<List<int>> mat = new List<List<int>>();
            //int N = A.Count;   // N Rows
            //int M = A.Count;   // M Columns 
            //for (int i = 0; i < N; i++) // Forloop for columns from 0 to N-1
            //{
            //    int startRow = 0, startCol = i;
            //    int cnt = 0;  // For counting the while loop count
            //    List<int> list = new List<int>();
            //    while ((startRow < N && startCol >= 0) || cnt < N)
            //    {
            //        if (cnt < N && startCol < 0)
            //            list.Add(0);
            //        else
            //            list.Add(A[startRow][startCol]);
            //        startRow++; startCol--; cnt++;
            //    }
            //    mat.Add(list);
            //}
            //for (int i = 1; i < N; i++) // Forloop for rows from 1 to N-1
            //{
            //    int startRow = i, startCol = M - 1;
            //    int cnt = 0; // For counting the while loop count
            //    List<int> list = new List<int>();
            //    while ((startRow < N && startCol >= 0) || cnt < N)
            //    {
            //        if (cnt < N && startRow >= N)
            //            list.Add(0);
            //        else
            //            list.Add(A[startRow][startCol]);
            //        startRow++; startCol--; cnt++;
            //    }
            //    mat.Add(list);
            //}
            //return mat;
            #endregion
        }

        /// <summary>
        /// You are given a 2D integer matrix A, return a 1D integer vector containing column-wise sums of original matrix.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> ColumnSum(List<List<int>> A)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < A[0].Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < A.Count; j++)
                {
                    sum += A[j][i];
                }
                list.Add(sum);
            }
            return list;
            #region Input
            /*
            List<List<int>> A = new List<List<int>>() { new List<int> { 1, 2, 3, 4 }, new List<int> { 5, 6, 7, 8 }, new List<int> { 9, 2, 3, 4 } };
            List<int> list = TwoDMatrices.ColumnSum(A);
            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            */
            #endregion
        }

        /// <summary>
        /// You are given two integer matrices A(having M X N size) and B(having N X P). 
        /// You have to multiply matrix A with B and return the resultant matrix. (i.e. return the matrix AB).
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<List<int>> MatrixMultiplication(List<List<int>> A, List<List<int>> B)
        {
            List<List<int>> mat = new List<List<int>>();
            List<int> list = new List<int>();
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = 0; j < A[0].Count; j++)
                {
                    for (int k = 0; k < A[0].Count; k++)
                    {
                       list[i] += A[i][k] * B[k][j];
                    }
                    mat.Add(list);
                }
            }
            return mat;
            #region Input
            //List<List<int>> A = new List<List<int>>() { new List<int> { 1, 2 }, new List<int> { 3, 4 } };
            //List<List<int>> B = new List<List<int>>() { new List<int> { 5, 6 }, new List<int> { 7, 8 } };
            //List<List<int>> op = TwoDMatrices.MatrixMultiplication(A, B);
            //foreach (var lstItems in op)
            //{
            //    foreach (var item in lstItems)
            //        Console.Write(item + " ");
            //    Console.WriteLine();
            //}
            #endregion
        }
    }
}
