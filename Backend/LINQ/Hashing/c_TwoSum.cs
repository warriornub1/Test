namespace LINQ.Hashing
{
    public class c_TwoSum
    {
        public c_TwoSum()
        {
            
        }
        //public int[] BruteForce(int[] nums, int target)
        //{
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        for (int j = i + 1; j < nums.Length; j++)
        //        {
        //            if (nums[i] + nums[j] == target)
        //                return new int[] { i, j };
        //        }
        //    }
        //    return new int[0];
        //}

        //public int[] Sorting(int[] nums, int target)
        //{
        //    List<int[]> A = new List<int[]>();
        //    for (int idx = 0; idx < nums.Length; idx++)
        //    {
        //        A.Add(new int[] { nums[idx], idx });
        //    }

        //    A.Sort((a, b) => a[0].CompareTo(b[0]));

        //    int i = 0; j = nums.Length - 1;
        //    while(i < j)
        //    {
        //        int cur = A[i][0] + A[j][0];
        //        if (cur == target)
        //            return new int[] { A[i][1], A[j][1] };
        //        else if (cur < target)
        //            i++;
        //        else
        //            j--;
        //    }
        //    return new int[0];
        //}

        //public int[] TwoPass(int[] nums, int target)
        //{
        //    Dictionary<int, int> indices = new Dictionary<int, int>();

        //    for(int i = 0; i < nums.Length; i++)
        //    {
        //        indices[nums[i]] = i;
        //    }

        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        int diff = target - nums[i];
        //        if (indices.ContainsKey(diff) && indices[diff] != i)
        //            return new int[] { i, indices[diff] };
        //    }

        //    return new int[0];
        //}

        //public int[] OnwPass(int[] nums, int target)
        //{
        //    Dictionary<int, int> prevMap = new Dictionary<int, int>();

        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        var diff = target - nums[i];
        //        if (prevMap.ContainsKey(diff))
        //            return new int[] { prevMap[diff], i };
        //        prevMap[nums[i]] = i;
        //    }
        //    return null;
        //}
    }
}
