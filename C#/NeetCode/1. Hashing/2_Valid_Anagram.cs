using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode._1._Hashing
{
    public class _2_Valid_Anagram
    {
        public _2_Valid_Anagram()
        {
            Console.WriteLine(Hashing("racecar", "carrace"));
            Console.WriteLine(Hashing("jar", "jam"));

            Console.WriteLine(Hashing1("racecar", "carrace"));
            Console.WriteLine(Hashing1("jar", "jam"));
        }

        //public bool Sorting(string s, string t)
        //{
        //    if (s.Length != t.Length)
        //        return false;

        //    char[] charS = s.ToCharArray();
        //    char[] charT = t.ToCharArray();



        //    return Array.Sort(charS).SequenceEqual( Array.Sort(charT) );
        //}

        public bool Hashing(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in s)
            {
                // dic[c] = dic.ContainsKey(c) ? dic[c] + 1  : 1;
                dic[c] = dic.GetValueOrDefault(c, 0) + 1;
            }

            foreach (char c in t)
            {
                //if (!dic.ContainsKey(c))
                //    return false;
                //else
                //    dic[c]--;

                if(!dic.TryGetValue(c, out int value))
                {
                    return false;
                }
                dic[c] = value - 1;
            }

            return dic.Values.All(x => x == 0);
        }

        public bool Hashing1(string s, string t)
        {
            if(s.Length != t.Length)
                return false;

            char[] key = new char[26];
            foreach(char c in s)
            {
                key[c -  'a']++;
            }

            foreach(char c in t)
            {
                key[c - 'a']--;
            }

            return key.All(x => x == 0);
        }
    }
}
