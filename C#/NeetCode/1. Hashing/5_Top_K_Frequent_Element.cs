namespace NeetCode._1._Hashing
{
    public class _5_Top_K_Frequent_Element
    {
        public _5_Top_K_Frequent_Element()
        {
            int[] nums = { 1, 2, 3, 3, 3 };
            int k = 2;
            var res = Sorting(nums, k);
            Console.WriteLine(string.Join(", ", res));

            var res1 = Heaps(nums, k);
            Console.WriteLine(string.Join(", ", res1));

            var res2 = Heaps(nums, k);
            Console.WriteLine(string.Join(", ", res2));
        }

        public int[] Sorting(int[] nums, int k)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                dic[num] = dic.GetValueOrDefault(num, 0) + 1;
            }

            List<int[]> sorted = dic.Select(x => new int[] { x.Value, x.Key })
                                    .ToList();

            sorted.Sort((x, y) => y[0].CompareTo(x[0]));

            int[] rtn = new int[k];
            for (int i = 0; i < k; i++)
            {
                rtn[i] = sorted.ElementAt(i)[1];
            }

            return rtn;
        }

        public int[] Heaps(int[] nums, int k)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            PriorityQueue<int, int> queue = new PriorityQueue<int, int>();

            foreach (int num in nums)
            {
                dic[num] = dic.GetValueOrDefault(num, 0) + 1;
            }

            foreach(var entry in dic)
            {
                queue.Enqueue(entry.Key, entry.Value);
                if(queue.Count > k)
                    queue.Dequeue();
            }

            int[] res = new int[k];
            for(int i = 0; i < k; i++)
            {
                res[i] = queue.Dequeue();
            }
            return res;
        }

        public int[] BucketSort(int[] nums, int k)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            List<int> [] slots = new List<int>[nums.Count()];

            for (int i = 0; i < nums.Length; i++) 
            {
                slots[i] = new List<int>();
            }
            foreach (int num in nums)
            {
                dic[num] = dic.GetValueOrDefault(num, 0) + 1;
            }

            foreach(var entry in dic)
            {
                slots[entry.Value].Add(entry.Key);
            }

            int[] res = new int[k];
            int index = 0;
            for (int i = slots.Length - 1; i >= 0; i--)
            {
                foreach (int item in slots[i])
                {
                    res[index++] = item;
                    if (index == k)
                        return res;
                }
            }
            return res;
        }
    }
}
