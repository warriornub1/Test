namespace NeetCode.Backtrack
{
    
    public class CombinationSumII
    {
        public CombinationSumII()
        {
            int[] numbers = new int[] { 9, 2, 2, 4, 6, 1, 5 };

            var result = backTackForLoop(numbers, 8);
            foreach(var res  in result)
            {
                Console.WriteLine(string.Join(", ", res.ToList() ));
            }
        }
        public List<List<int>> backTrack(int[] nums, int target)
        {
            Array.Sort(nums);

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
                {
                    return;
                }

                subset.Add(nums[i]);
                recursion(i + 1, total + nums[i]);
                subset.RemoveAt(subset.Count - 1);
                while (i < nums.Count() - 1 &&  nums[i] == nums[i + 1])
                {
                    i++;
                }
                recursion(i + 1, total);
            }
            recursion(0, 0);
            return res;
        }

        public List<List<int>> backTackForLoop(int[] nums, int target)
        {
            var res = new HashSet<string>();
            var subset = new List<int>();
            Array.Sort(nums);

            void recursion(int index, int total)
            {
                if(total == target)
                {
                    res.Add(string.Join(',', subset));
                    return;
                }
                if (index >= nums.Length || total > target)
                    return;

                subset.Add(nums[index]);
                recursion(index + 1, total + nums[index]);
                subset.RemoveAt(subset.Count - 1);
                recursion(index + 1, total);
            }
            recursion(0, 0);
            
            var res1 = new List<List<int>>();
            foreach (var r in res)
            {
                res1.Add(new List<int>(r.Split(",").Select(x => int.Parse(x)).ToList()));
            }
            return res1;
        }
    }
}
