using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Hashing
{
    public class clsHashing
    {
        /// <summary>
        /// AQ4. 2 Sum
        /// Ex: Input: [2, 7, 11, 15], target=9
        ///    Output: index1 = 1, index2 = 2
        /// </summary>
        /// <param name="A">a.</param>
        /// <param name="B">The b.</param>
        /// <returns></returns>
        public List<int> TwoSum(List<int> A, int B)
        {
            List<int> a = new List<int>{ 0, 1 };
            Dictionary<int, int> m = new Dictionary<int, int>();
            for (int i = 0; i < A.Count; i++)
            {
                if (m.ContainsKey(B - A[i]))
                {
                    a[0] = m[B - A[i]] + 1;
                    a[1] = i + 1;
                    a.Sort();
                    return a;
                }
                else if (!m.ContainsKey(A[i])) 
                    m[A[i]] = i;
            }
            return new List<int>();
        }
    }
}
