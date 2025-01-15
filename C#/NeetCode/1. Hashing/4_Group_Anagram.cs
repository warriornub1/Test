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
                char[] chars = str.ToCharArray();
                Array.Sort(chars);
                string key = new string(chars);
                if (!res.ContainsKey(key))
                    res[key] = new List<string>();
                res[key].Add(str);
            }
            return res.Values.ToList<List<string>>();
        }

        public List<List<string>> HashMap1(string[] strs)
        {
            var res = new Dictionary<string, List<string>>();
            foreach(string str in strs)
            {
                int[] key = new int[26];
                foreach(char c in str)
                {
                    key[c - 'a']++;
                }
                string keyStr = string.Join("", key);
                if (!res.ContainsKey(keyStr))
                {
                    res[keyStr] = new List<string>();

                }
                res[keyStr].Add(str);
            }
            return res.Values.ToList<List<string>>();
        }
    }
}
