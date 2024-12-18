namespace LINQ.Hashing
{
    public class ContainsDuplicate
    {
        public ContainsDuplicate()
        {
            int[] nums1 = { 1, 2, 3, 3 };
            int[] nums2 = { 1, 2, 3, 4 };
            Console.WriteLine("Brute Force");
            Console.WriteLine( BruteForce(nums1) );
            Console.WriteLine( BruteForce(nums2) );

            Console.WriteLine("\nSorting");
            Console.WriteLine(Sorting(nums1));
            Console.WriteLine(Sorting(nums2));

            Console.WriteLine("\nHashset");
            Console.WriteLine(Hashset(nums1));
            Console.WriteLine(Hashset(nums2));

            Console.WriteLine("\nHashset Length");
            Console.WriteLine(HashsetLength(nums1));
            Console.WriteLine(HashsetLength(nums2));

            Console.WriteLine("\nLINQ");
            Console.WriteLine(LINQ(nums1));
            Console.WriteLine(LINQ(nums2));

        }
        

        // Brute Force
        public bool BruteForce(int[] nums)
        {
            for(int i = 0; i < nums.Length; i++) {
                for(int j = i + 1; j < nums.Length; j++) {
                    if (nums[i] == nums[j])
                        return true;
                }
            }
            return false;
        }
        
        // Sorting
        public bool Sorting(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                    return true;
            }
            return false;
        }

        // Hashset
        public bool Hashset(int[] nums)
        {
            HashSet<int> hashset = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (hashset.Contains(nums[i]))
                    return true;
                hashset.Add(nums[i]);
            }
            return false;
        }

        // Hashset
        public bool HashsetLength(int[] nums)
        {
            return new HashSet<int>(nums).Count() != nums.Count();
        }

        // LINQ
        public bool LINQ(int[] nums)
        {
            // return nums.Distinct().Count() != nums.Count();
            return nums.GroupBy(x => x)
                       .Where(x => x.Count() > 1)
                       .Any();
        }
    }
}
