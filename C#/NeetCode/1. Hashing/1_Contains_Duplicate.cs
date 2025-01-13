namespace NeetCode._1._Hashing
{
    public class _1_Contains_Duplicate
    {
        public _1_Contains_Duplicate()
        {
            
        }
        public bool BruteForce(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if(nums[i] == nums[j])
                        return true;
                }
            }
            return false;
        }

        public bool Sorting(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                    return true;
            }
            return false;
        }

        public bool HashSet(int[] nums)
        {
            HashSet<int> seen = new HashSet<int>();
            foreach (int i in nums)
            {
                if (!seen.Contains(i))
                    seen.Add(i);
                else
                    return true;
            }
            return false;
        }

        public bool HashSetLength(int[] nums)
        {
            HashSet<int> seen = new HashSet<int>(nums);
            return seen.Count != nums.Length;
        }
    }

}
