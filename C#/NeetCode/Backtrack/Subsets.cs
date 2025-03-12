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

            var forloop = Iteration(sets);
            foreach(var l in forloop)
            {
                Console.WriteLine(string.Join(", ", l));
            }
        }

        public List<List<int>> Backtracking(List<int> sets)
        {
            var res = new List<List<int>>();
            var subset = new List<int>();

            void recursion(int i)
            {
                if( i >= sets.Count )
                {
                    res.Add(new List<int>( subset ));
                    return;
                }

                subset.Add(sets[i]);
                recursion(i + 1);
                subset.RemoveAt(subset.Count - 1);
                recursion(i + 1);
            }
            recursion(0);
            return res;
        }

        public List<List<int>> Iteration(List<int> sets)
        {
            var res = new List<List<int>>();
            res.Add( new List<int>() );

            foreach (int number in sets)
            {
                int count = res.Count;
                for(int i = 0; i < count; i++)
                {
                    var subset  = new List<int> (res[i]);
                    subset.Add(number);
                    res.Add( subset );
                }
            }
            return res;

        }

    }

    
}
