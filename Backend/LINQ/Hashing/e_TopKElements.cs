using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Hashing
{
    public class e_TopKElements
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                count[num] = 1 + count.GetValueOrDefault(num, 0);
            }

            List<int[]> arr = count.Select(x => new int[] { x.Value, x.Key }).ToList();
            arr.Sort((a, b) => b[0].CompareTo(a[0]));

            int[] res = new int[k];
            for(int i = 0; i < k; i++)
            {
                res[i] = arr[i][1];
            }
            return res;
        }
    }

}
