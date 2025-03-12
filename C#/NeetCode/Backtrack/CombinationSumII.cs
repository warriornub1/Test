namespace NeetCode.Backtrack
{
    public class CombinationSumII
    {
        public List<List<int>> backTrack(int[] nums, int target)
        {
            var res = new List<List<int>>();
            var subset = new List<int>();
            Array.Sort(nums);

            void recursion(int i, int total)
            {
                if (total == target)
                {
                    res.Add(new List<int>(subset));
                    return;
                }
                if (total > target || i == nums.Length)
                    return;
                subset.Add(nums[i]);
                recursion(i + 1, total + nums[i]);
                subset.RemoveAt(subset.Count - 1);

                while (i + 1 < nums.Length && nums[i] == nums[i + 1])
                    i++;
                recursion(i + 1, total);
            }

            recursion(0, 0);
            return res;
        }
    }
}
