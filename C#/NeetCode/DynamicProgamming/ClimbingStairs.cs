using System.Net.Http.Headers;

namespace NeetCode.DynamicProgamming
{
    public class ClimbingStairs
    {
        public ClimbingStairs()
        {
            Console.WriteLine(climbStairs(5));
        }
        public int Recursion(int n)
        {
            int dfs(int i)
            {
                if (i >= n)
                    return i == n ? 1 : 0;
                return dfs(i + 1) + dfs(i + 2);
            }
            return dfs(0);
        }

        public int Caching(int n)
        {
            int[] cache = new int[n];
            Array.Fill(cache, -1);

            int dfs(int i)
            {
                if (i >= n)
                    return i == n ? 1 : 0;

                if (cache[i] != -1)
                    return cache[i];

                cache[i] = dfs(i + 1) + dfs(i + 2);
                return cache[i];
            }
            return dfs(0);
        }

        public int climbStairs(int n)
        {
            if (n == 1) return 1;
            int one = 1;
            int two = 1;

            for (int i = 0; i < n - 1; i++)
            {
                int temp = one;
                one = one + two;
                two = temp;
            }
            return one;
        }
    }
}
