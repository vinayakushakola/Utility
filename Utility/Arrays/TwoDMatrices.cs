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

        public static List<List<int>> SquareMatrixMultiplication(List<List<int>> A, List<List<int>> B)
        {
            List<List<int>> mat = new List<List<int>>();
            for (int i = 0; i < A.Count; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < B[0].Count; j++)
                {
                    for (int k = 0; k < B[0].Count; k++)
                    {
                        if (k == 0)
                            list.Add(A[i][k] * B[k][j]);
                        else
                            list[k + j - 1] += A[i][k] * B[k][j];
                    }
                }
                mat.Add(list);
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
            for (int i = 0; i < A.Count; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < B[0].Count; j++)
                {
                    for (int k = 0; k < A.Count; k++)
                    {
                        if (k==0)
                            list.Add(A[i][k] * B[k][j]);
                        else
                            list[k+j-1] += A[i][k] * B[k][j];
                    }
                }
                mat.Add(list);
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

        /// <summary>
        /// You are given two integer matrices A and B having same size(Both having same number of 
        /// rows (N) and columns (M)). You have to subtract matrix A from B and return the resultant 
        /// matrix. (i.e. return the matrix A - B).
        /// If X and Y are two matrices of the same order(same dimensions). Then X - Y is a matrix of 
        /// the same order as X and Y and its elements are obtained by subtracting the elements of Y 
        /// from the corresponding elements of X.Thus if Z = [z[i][j]] = X - Y, then[z[i][j]] = [x[i][j]] – [y[i][j]]. 6minutes
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<List<int>> MatrixSubtraction(List<List<int>> A, List<List<int>> B)
        {
            int N = A.Count;
            int M = A[0].Count;
            List<List<int>> mat = new List<List<int>>();
            for (int i = 0; i < N; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < M; j++)
                {
                    list.Add(A[i][j] - B[i][j]);
                }
                mat.Add(list);
            }
            return mat;
        }

        /// <summary>
        /// You are given a square matrix A, you have to return another matrix which is the transpose of A.
        /// NOTE: Transpose of a matrix A is defined as - AT[i][j] = A[j][i] ; Where 1 ≤ i ≤ col and 1 ≤ j ≤ row
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<List<int>> SquareMatrixTranspose(List<List<int>> A)
        {
            int N = A.Count;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    int temp = A[i][j];
                    A[i][j] = A[j][i];
                    A[j][i] = temp;
                }
            }
            return A;
        }

        /// <summary>
        /// You are given a matrix A, you have to return another matrix which is the transpose of A.
        /// NOTE: Transpose of a matrix A is defined as - AT[i][j] = A[j][i] ; Where 1 ≤ i ≤ col and 1 ≤ j ≤ row
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<List<int>> MatrixTranspose(List<List<int>> A)
        {
            int N = A.Count;
            int M = A[0].Count;
            List<List<int>> mat = new List<List<int>>();
            for (int i = 0; i < M; i++)
            {
                List<int> l = new List<int>();
                for (int j = 0; j < N; j++)
                {
                    l.Add(A[j][i]);
                }
                mat.Add(l);
            }
            return mat;
            #region input
            /*
             List<List<int>> A = new List<List<int>>() { new List<int> { 1, 2, 3 }, new List<int> {  4, 5,6 }
            , new List<int> { 7,8,9 }, new List<int> { 10,11,12 } };
            //List<List<int>> A = new List<List<int>>() { new List<int> { 1, 2, 3, 4 }, new List<int> {  5,6,7,8 }
            //, new List<int> { 9,10,11,12 } };
            //List<List<int>> B = new List<List<int>>() { new List<int> { 5, 6 }, new List<int> { 7, 8 } };
            Console.WriteLine("1 2 3");
            Console.WriteLine("4 5 6");
            Console.WriteLine("7 8 9");
            Console.WriteLine("10 11 12");
            //Console.WriteLine("1 2 3 4");
            //Console.WriteLine("5 6 7 8");
            //Console.WriteLine("9 10 11 12");
            Console.WriteLine();
            List<List<int>> op = TwoDMatrices.MatrixTranspose(A);
            foreach (var lstItems in op)
            {
                foreach (var item in lstItems)
                    Console.Write(item + " ");
                Console.WriteLine();
            }
             */
            #endregion
        }

        /// <summary>
        /// Given an integer A, generate a square matrix filled with elements from 1 to A2 in spiral order.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int[,] GenerateSpiralMatrix(int A)
        {
            int[,] res = new int[A,A];
            int top = 0, left = 0, bottom = A - 1, right = A - 1;
            int count = 1;
            while (top <= bottom && left <= right)
            {
                for (int i = left; i <= right; i++)
                {
                    res[top,i] = count;
                    count++;
                }
                top++;

                for (int i = top; i <= bottom; i++)
                {
                    res[i,right] = count;
                    count++;
                }
                right--;

                if (top <= bottom)
                {
                    for (int i = right; i >= left; i--)
                    {
                        res[bottom,i] = count;
                        count++;
                    }
                    bottom--;
                }

                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        res[i,left] = count;
                        count++;
                    }
                    left++;
                }
            }
            return res;
            //List<List<int>> mat = new List<List<int>>();
            //int l = 0, r = A-1, b = A-1, t = 0, d = 0, i;
            //int count = 1;
            //while (l <= r && t <= b)
            //{
            //    List<int> list = new List<int>();
            //    if (d == 0)
            //    {
            //        for (i = l; i <= r; i++)
            //        {
            //            list.Add(count); count++;
            //        }
            //        d = 1;t++;
            //    }
            //    else if (d == 1)
            //    {
            //        for (i = t; i <= b; i++)
            //        {
            //            list.Add(count); count++;
            //        }
            //        d = 2;r--;
            //    }
            //    else if (d == 2)
            //    {
            //        for (i = r; i >= l; i--)
            //        {
            //            list.Add(count); count++;
            //        }
            //        d = 3;b--;
            //    }
            //    else if (d == 3)
            //    {
            //        for (i = b; i >= t; i--)
            //        {
            //            list.Add(count); count++;
            //        }
            //        d = 0;l++;
            //    }
            //    mat.Add(list);
            //}
            //return mat;
        }

        public static void RotateTwoDBy90(List<List<int>> a) 
        {
            int N = a.Count;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    int temp = a[i][j];
                    a[i][j] = a[j][i];
                    a[j][i] = temp;
                }
            }
            foreach (var list in a)
            {
                int i = 0, j = list.Count - 1;
                while (i < j)
                {
                    int temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                    i++; j--;
                }
            }
        }
    }
}
