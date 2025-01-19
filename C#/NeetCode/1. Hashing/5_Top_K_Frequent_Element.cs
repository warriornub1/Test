namespace NeetCode._1._Hashing
{
    public class _5_Top_K_Frequent_Element
    {
        public _5_Top_K_Frequent_Element()
        {
            
        }

        public int[] Sorting(int[] nums, int k)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                count[nums[i]] = count.GetValueOrDefault(nums[i], 1);
            }

            List<int[]> sort = count.Select(x => new int[] { x.Value, x.Key }).ToList();
            sort.Sort((a, b) => b[0].CompareTo(a[0]));
            int j = 0;
            int[] res = new int[k];
            while( j < k )
            {
                res[j] = sort[j][1];
            }
            return res;
        }

        public int[] Hashmap(int[] nums, int k)
        {
            
        }
    }
}
