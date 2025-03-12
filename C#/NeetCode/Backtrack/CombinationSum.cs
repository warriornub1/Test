namespace NeetCode.Backtrack
{
    public class CombinationSum
    {
        public CombinationSum()
        {
            var result = backTracking(new int[] { 2, 5, 6, 9 }, 9);
            foreach (var r in result)
            {
               Console.WriteLine(string.Join(", ", r));
            }
        }

        public List<List<int>> backTracking(int[] nums, int target)
        {
            var res = new List<List<int>>();
            var subset = new List<int>();

            void recursion(int i, int sum)
            {
                if (sum == target)
                {
                    res.Add(new List<int>(subset));
                    return;
                }
                else if (sum > target || i >= nums.Count() )
                {
                    return;
                }

                subset.Add(nums[i]);
                recursion(i, sum + nums[i]);
                subset.RemoveAt(subset.Count - 1);
                recursion(i + 1, sum);
            }
            recursion(0, 0);
            return res;
        }

        public List<List<int>> forLoop(int[] nums, int target)
        {
            var res = new List<List<int>>();
            var subset = new List<int>();
            Array.Sort(nums);

            void recursion(int index, int total)
            {
                if (total == target)
                {
                    res.Add(new List<int>(subset));
                    return;
                }

                for (int j = index; j < nums.Length; j++)
                {
                    if(total + nums[j] > target)
                        return;
                    subset.Add(nums[j]);
                    recursion(j, total + nums[j]);
                    subset.RemoveAt(subset.Count - 1);
                }
            }
            recursion(0, 0);
            return res;
        }
    }


}
