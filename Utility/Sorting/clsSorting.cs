using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Sorting
{
    public class clsSorting
    {
        public static string LargestNumber(List<int> A)
        {
            int sizeOfList = A.Count;
            List<int> lst = new List<int>();
            for (int i = 0; i < sizeOfList; i++)
            {
                int remainder = A[i] % 10;
                lst.Add(remainder);
                if (A[i]/10 != 0)
                {
                    for (int j = 0; j < remainder; j++)
                    {
                        remainder = A[i] % 10;
                        A[i] = A[i] / 10;
                        lst.Add(remainder);
                    }
                    continue;
                }
            }
            lst.Sort();
            string ans = "";
            for (int i = lst.Count-1; i >= 0; i--)
                ans += lst[i];
            return ans;
        }
    }
}
