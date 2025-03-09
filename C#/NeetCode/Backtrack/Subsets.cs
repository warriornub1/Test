namespace NeetCode.Backtrack
{
    public class Subsets
    {
        public Subsets()
        {
            List<int> sets = new List<int>() { 1, 2, 3 };
            var bt = Backtracking(sets);
            foreach (var l in bt)
            {
                Console.WriteLine(string.Join(", ", l));
            }
        }
        public List<List<int>> Backtracking(List<int> list)
        {
            List<List<int>> res = new List<List<int>>();
            List<int> temp = new List<int>();

            void backtrack(int index)
            {
                if (index >= list.Count)
                {
                    res.Add(new List<int>(temp));
                    return;
                }
                temp.Add(list[index]);
                backtrack(index + 1);
                temp.RemoveAt(temp.Count() - 1);
                backtrack(index + 1);
            }
            backtrack(0);
            return res;
        }
    }

    
}
