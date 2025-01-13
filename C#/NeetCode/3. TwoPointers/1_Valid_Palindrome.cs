using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode._3._TwoPointers
{
    public class _1_Valid_Palindrome
    {
        public bool ReverseString(string s)
        {
            string newStr = "";
            foreach (char c in s)
            {
                if (char.IsLetterOrDigit(c))
                {
                    newStr += char.ToLower(c);
                }
            }
            return newStr == new string(newStr.Reverse().ToArray());
        }

        public bool TwoPointers(string s)
        {
            int l = 0, r = s.Length - 1;

            while (l < r)
            {
                while (l < r && !AlphaNum(s[l]))
                {
                    l++;
                }
                while (r > l && !AlphaNum(s[r]))
                {
                    r--;
                }
                if (char.ToLower(s[l]) != char.ToLower(s[r]))
                {
                    return false;
                }
                l++; r--;
            }
            return true;
        }

        public bool AlphaNum(char c)
        {
            return (c >= 'A' && c <= 'Z' ||
                    c >= 'a' && c <= 'z' ||
                    c >= '0' && c <= '9');
        }
    }
}
