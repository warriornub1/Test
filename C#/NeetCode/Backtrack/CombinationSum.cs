namespace NeetCode.Backtrack
{
    public class CombinationSum
    {
        public CombinationSum()
        {
            var result = forLoop(new int[] { 2, 5, 6, 9 }, 9);
            foreach (var r in result)
            {
               Console.WriteLine(string.Join(", ", r));
            }
        }

        public List<List<int>> backTracking(int[] nums, int target)
        {
            var res = new List<List<int>>();
            var subset = new List<int>();

            void recursion(int i, int total)
            {
                if(total == target)
                {
                    res.Add(new List<int>(subset));
                    return;
                }
                if (total > target || i >= nums.Length)
                    return;

                subset.Add(nums[i]);
                recursion(i, total + nums[i]);
                subset.RemoveAt(subset.Count - 1);
                recursion(i + 1, total);
            }

            recursion(0, 0);
            return res;
        }

        public List<List<int>> forLoop(int[] nums, int target)
        {
            var res = new List<List<int>>();
            var subset = new List<int>();

            void recursion(int i, int total)
            {
                if (total == target)
                {
                    res.Add(new List<int>(subset));
                    return;
                }
                if (i >= nums.Length || total > target)
                    return;

                for (int j = i; j < nums.Length; j++)
                {
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
