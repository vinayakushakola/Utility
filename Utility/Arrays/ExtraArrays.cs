using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Arrays
{
    public class ExtraArrays
    {
        public static int LongestLenOfConsecutivesOnes(string A)
        {
            //Console.WriteLine(ExtraArrays.LongestLenOfConsecutivesOnes("010100110101"));
            //Console.WriteLine(ExtraArrays.LongestLenOfConsecutivesOnes("0000"));
            int cnt = 0, ans = 0, len = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == '1')
                    cnt++;
            }
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == '0')
                {
                    int l = 0;
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (A[j] == '0')
                            break;
                        else if (A[j] == '1')
                            l++;
                    }
                    int r = 0;
                    for (int k = i + 1; k < A.Length; k++)
                    {
                        if (A[k] == '0')
                            break;
                        else if (A[k] == '1')
                            r++;
                    }
                    if (l + r < cnt)
                        len = l + r + 1;
                    else
                        len = l + r;
                    ans = Math.Max(ans, len);
                }
            }
            if (cnt == A.Length)
                ans = cnt;
            return ans;
        }
    }
}
