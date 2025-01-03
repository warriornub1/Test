﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Hashing
{
    public class d_GroupAnagram
    {
        public d_GroupAnagram()
        {
            string[] strs = { "act", "pots", "tops", "cat", "stop", "hat" };
            Console.WriteLine("\nGroupAnagrams");
            var res = Test(strs);
            foreach (var str in res)
            {
                Console.WriteLine(string.Join(", ", str));
            }
            Console.WriteLine("\nGroupAnagrams");
            var res1 = GroupAnagrams1(strs);
            foreach ( var str in res)
            {
                Console.WriteLine(string.Join(", ", str));

            }
        }

        public List<List<string>> Test(string[] strs)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            foreach(string str in strs)
            {
                char[] key = new char[26];
                foreach(char c in str)
                {
                    key[c - 'a']++;
                }
                string keyStr = key.ToString();
                map[keyStr] = map.GetValueOrDefault(keyStr, new List<string>());
                map[keyStr].Add(str);
            }

            return map.Values.ToList<List<string>>();
        }

        public List<List<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> res = new Dictionary<string, List<string>>();
            foreach (var c in strs)
            {
                char[] charArray = c.ToCharArray();
                Array.Sort(charArray);

                string sortedS = new string(charArray);
                if (!res.ContainsKey(sortedS))
                    res[sortedS] = new List<string>();

                res[sortedS].Add(c);
            }

            return res.Values.ToList<List<string>>();
        }

        public List<List<string>> GroupAnagrams1(string[] strs)
        {
            Dictionary<string, List<string>> res = new Dictionary<string, List<string>>();
            foreach(var c in strs)
            {
                int[] count = new int[26];
                foreach(char cc in c)
                {
                    count[cc - 'a']++;
                }
                string key = string.Join(",", count);
                res[key] = res.GetValueOrDefault(key, new List<string>());
                res[key].Add(c);

            }

            return res.Values.ToList<List<string>>();
        }
    }
}
