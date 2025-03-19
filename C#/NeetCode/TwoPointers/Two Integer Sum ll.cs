namespace NeetCode.TwoPointers
{
    public class Two_Integer_Sum_ll
    {
        public Two_Integer_Sum_ll()
        {
            int[] numbers = new int[] {1, 2, 3, 4};
            int target = 3;
            var res = TwoPointers(numbers, target);
            Console.WriteLine( string.Join(", ", res ) );
        }

        public List<int> BruteForce(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == target)
                        return new List<int>() { i, j };
                }
            }
            return new List<int>();
        }

        public List<int> TwoPointers(int[] numbers, int target)
        {
            int i = 0; int j = numbers.Length - 1;

            while(i < j)
            {
                int total = numbers[i] + numbers[j];
                if (total < target)
                    i++;
                else if (total > target) 
                    j--;
                else
                    return new List<int>() { i, j };
            }
            return new List<int>();
        }
    }
}
