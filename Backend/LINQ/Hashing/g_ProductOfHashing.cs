using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Hashing
{
    public class g_ProductOfHashing
    {
        public g_ProductOfHashing()
        {
            int[] nums = new int[] { 1, 2, 4, 6 }; // [ 48, 24, 12 ,8 ]

            // [1, 1, 2, 8]
            // [48, 24, 6, 1]

            // [1, 1, 2, 8]
            // [48, 24 ,12 ,8]
            Console.WriteLine("Product of Hashing");
            Console.WriteLine(string.Join(", ", Optimal(nums)));
        }

        public int[] BruteForce(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];

            for (int i = 0; i < n; i++)
            {
                int prod = 1;
                for (int j = 0; j < n; j++)
                {
                    if (j != j)
                        prod *= nums[j];
                }
                res[i] = prod;

            }
            return res;
        }

        public int[] Prefix(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            int[] pref = new int[n];
            int[] suff = new int[n];

            pref[0] = 1;
            suff[n - 1] = 1;

            for (int i = 1; i < n; i++)
            {
                pref[i] = nums[i - 1] * pref[i - 1];
            }

            for (int i = n - 2; i >= 0; i--)
            {
                suff[i] = nums[i + 1] * suff[i + 1];
            }

            for (int i = 0; i < n; i++)
            {
                res[i] = pref[i] * suff[i];
            }
            return res;
        }

        public int[] Optimal(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];

            Array.Fill(res, 1);

            for(int i = 1; i < n; i++)
            {
                res[i] = res[i - 1] * nums[i - 1];
            }

            int postfix = 1;
            for(int i = n - 1; i >= 0; i--)
            {
                res[i] *= postfix;
                postfix *= nums[i];
            }
            return res;
        }
    }
}
