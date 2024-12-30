using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.TwoPointer
{
    public class b_Two_Sum
    {
        public b_Two_Sum()
        {
            
        }

        /*
         Time complexity : O(n^2)
         Space complexity: O(1) 
         */
        public int[] BruteForce(int[] numbers, int target)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                for(int j = i + 1; j < numbers.Length;  j++)
                {
                    if (numbers[i] + numbers[j] == target)
                        return new int[] { i + 1, j + 1 };
                }

            }

            return new int[0];
        }

        //public int[] TwoPointers(int[] numbers, int target)
        //{
        //    int l = 0, r = numbers.Length - 1;

        //    while(l < r)
        //    {
        //        int curSum = numbers[l] + numbers[r];

        //        if (curSum > target)
        //            r--;
        //        else if (curSum < target)
        //            l++;
        //        else
        //            return new int[] { l + 1, r + 1 };
        //    }
        //}
    }
}
