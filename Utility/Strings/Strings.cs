using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Strings
{
    public class Strings
    {
        /// <summary>
        /// AQ1. Simple Reverse - reverse a given string 
        /// </summary>
        /// <param name="A">a</param>
        /// <returns>returns the reversed string</returns>
        public static string ReverseString(string A)
        {
            char[] chArr = A.ToCharArray();
            int i = 0, j = A.Length - 1;
            while (i < j)
            {
                char temp = chArr[i];
                chArr[i] = chArr[j];
                chArr[j] = temp;
                i++; j--;
            }
            return new string(chArr);
        }
    }
}
