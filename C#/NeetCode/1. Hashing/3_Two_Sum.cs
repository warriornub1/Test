namespace NeetCode._1._Hashing
{
    public class _3_Two_Sum
    {
        public _3_Two_Sum()
        {
            
        }

        public int[] BruteForce(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[0];
        }

        public int[] Sorting(int[] nums, int target)
        {
            List<int[]> bag = new List<int[]>();
            for(int i = 0; i < nums.Length; i++)
            {
                bag.Add(new int[] { nums[i], i });
            }

            bag.Sort((a, b) => a[0].CompareTo(b[0]));

            int a = 0; int b = nums.Length - 1;
            while(a < b)
            {
                int diff = bag[b][0] - bag[a][0];
                if (diff > target)
                    b--;
                else if(diff < target) 
                    a++;
                else
                    return new int[] { Math.Min(bag[a][1], bag[b][1]), Math.Max(bag[a][1], bag[b][1]) };
            }

            return new int[0];
        }
    }
}
