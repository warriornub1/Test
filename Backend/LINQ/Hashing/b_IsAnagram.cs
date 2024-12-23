using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Hashing
{
    public class b_IsAnagram
    {

        public b_IsAnagram()
        {
            string s = "racecar";
            string t = "carrace";

            string s1 = "aa";
            string t1 = "aaa";

            //Console.WriteLine("\nSorting");
            //Console.WriteLine(Sorting(s, t));
            //Console.WriteLine(Sorting(s1, t1));

            //Console.WriteLine("\nHashtable");
            //Console.WriteLine(HashTable(s, t));
            //Console.WriteLine(HashTable(s1, t1));

            //Console.WriteLine("\nHashtable1");
            //Console.WriteLine(HashTable1(s, t));
            //Console.WriteLine(HashTable1(s1, t1));

            Console.WriteLine("\nTest");
            Console.WriteLine(Test(s, t));
            Console.WriteLine(Test(s1, t1));
        }

        public bool Test(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            Dictionary<char, int> map = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                map[s[i]] = map.GetValueOrDefault(s[i], 0) + 1;
                map[t[i]] = map.GetValueOrDefault(t[i], 0) - 1;
            }

            return map.Select(x => x.Value).All(x => x == 0);
        }

        public bool Sorting(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            char[] sortedS = s.ToCharArray();
            char[] sortedT = t.ToCharArray();

            Array.Sort(sortedS);
            Array.Sort(sortedT);

            return sortedS.SequenceEqual(sortedT);
        }


        public bool HashTable(string s, string t)
        {
            if (s.Length != t.Length) return false;

            Dictionary<char, int> hashS = new Dictionary<char, int>();
            Dictionary<char, int> hashT = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                hashS[s[i]] = hashS.GetValueOrDefault(s[i], 0) + 1;
                hashT[s[i]] = hashT.GetValueOrDefault(t[i], 0) + 1;
            }

            return hashS.Count == hashT.Count && hashS.Except(hashT).Any();

        }

        public bool HashTable1(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            int[] key = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                key[s[i] - 'a']++;
                key[t[i] - 'a']--;
            }

            return key.All(x => x == 0);
        }
    }
}
