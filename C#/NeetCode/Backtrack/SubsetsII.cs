namespace NeetCode.Backtrack
{
    public class SubsetsII
    {

        public List<List<int>> BruteForce(int[] nums)
        {
            var res = new HashSet<string>();
            var subset = new List<int>();

            void backtrack(int i )
            {
                if (i == nums.Length)
                {
                    res.Add(string.Join(",", subset));
                }

                subset.Add(nums[i]);
                backtrack(i + 1);
                subset.RemoveAt(subset.Count - 1);
                backtrack(i + 1);
            }
            backtrack(0);
            var final_res = new List<List<int>>();
            foreach (var r in res)
            {
                final_res.Add(r.Split(",").Select(x => int.Parse(x)).ToList());
            }
            return final_res;
        }
    }

}
