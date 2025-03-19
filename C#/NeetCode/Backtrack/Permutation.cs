using System.Runtime.InteropServices.Marshalling;

namespace NeetCode.Backtrack
{
    public class Permutation
    {
        public Permutation()
        {
            int[] nums = new int[] { 1, 2, 3 };
            var result = Permute(nums);
            foreach (var r in result)
            {
                Console.WriteLine(string.Join(", ", r));
            }
        }
        public List<List<int>> Permute(int[] nums)
        {
            if(nums.Count() == 0)
                return new List<List<int>>() { new List<int>() };

            var perm = Permute(nums[1..]);
            var result = new List<List<int>>();
            foreach (var p in perm)
            {
                for (int i = 0; i <= p.Count(); i++)
                {
                    var p_copy = new List<int>(p);
                    p_copy.Insert(i, nums[0]);
                    result.Add(p_copy);
                }
            }
            return result;

            #region Solution
            //if (nums.Length == 0)
            //    return new List<List<int>> { new List<int>() };

            //var perms = Permute(nums[1..]);
            //var res = new List<List<int>>();

            //foreach (var p in perms)
            //{
            //    for (int i = 0; i <= p.Count; i++)
            //    {
            //        var p_copy = new List<int>(p);
            //        p_copy.Insert(i, nums[0]);
            //        res.Add(p_copy);
            //    }
            //}
            //return res;
            #endregion
        }
        // https://www.youtube.com/watch?v=gFm1lEfnzUQ&ab_channel=GregHogg
        public List<List<int>> backTack(int[] nums)
        {
            var res = new List<List<int>>();
            var subset = new List<int>();

            void recursion()
            {
                if(subset.Count == nums.Length)
                {
                    res.Add(new List<int>(subset) );
                    return;
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    if (!subset.Contains(nums[i]))
                    {
                        subset.Add(nums[i]);
                        recursion();
                        subset.RemoveAt(subset.Count - 1);
                    }
                }
            }
            recursion();
            return res;
        }
    }
}
