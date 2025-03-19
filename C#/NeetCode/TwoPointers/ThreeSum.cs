namespace NeetCode.TwoPointers
{
    public class ThreeSum
    {
        public ThreeSum()
        {
            
        }

        public List<List<int>> ForLoop(int[] nums)
        {
            var res = new List<List<int>>();
            var unique = new HashSet<Tuple<int, int, int>>();
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                            unique.Add(Tuple.Create(nums[i], nums[j], nums[k]));
                    }
                }
            }
            foreach(var triplet in unique)
            {
                res.Add(new List<int>() { triplet.Item1, triplet.Item2, triplet.Item3 });
            }
            return res;
        }

        public List<List<int>> ThreePointer(int[] nums)
        {
            Array.Sort(nums);
            var res = new List<List<int>>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    break;
                if(i > 0 && nums[i] == nums[i - 1])
                    continue;

                int l = i + 1, r = nums.Length - 1;
                while (l < r)
                {
                    int sum = nums[i] + nums[l] + nums[r];
                    if (sum > 0)
                        r--;
                    else if (sum < 0)
                        l++;
                    else
                    {
                        res.Add(new List<int>() { nums[i], nums[l], nums[r] });
                        l++;
                        r--;
                        while (l < r && nums[l] == nums[l - 1])
                            l++;
                    }
                }
            }
            return res;
        }
    }
}
