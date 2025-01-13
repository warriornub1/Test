namespace NeetCode._1._Hashing
{
    public class _4_Group_Anagram
    {
        public _4_Group_Anagram()
        {
            
        }

        public List<List<string>> Sorting(string[] strs)
        {
            var res = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                char[] charArray = str.ToCharArray();
                Array.Sort(charArray);
                string sortedS = new string(charArray);
                if(!res.ContainsKey(sortedS))
                    res[sortedS] = new List<string>();
                res[sortedS].Add(str);
            }
            return res.Values.ToList<List<string>>();
        }

        public List<List<string>> HashMap1(string[] strs)
        {
            var res = new Dictionary<string, List<string>>();
            foreach (var s in strs)
            {
                int[] count = new int[26];
                foreach(char c in s)
                {
                    count[c - 'a']++;
                }
                string key = string.Join(",", count);
                if(!res.ContainsKey(key))
                    res[key] = new List<string>();
                res[key].Add(s);
            }
            return res.Values.ToList<List<string>>();
        }
    }
}
