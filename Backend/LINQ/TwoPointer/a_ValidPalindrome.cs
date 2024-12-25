using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.TwoPointer
{
    public class a_ValidPalindrome
    {
        public a_ValidPalindrome()
        {
            string s = "Was it a car or a cat I saw?";
            string t = "tab a cat";
        }

        public bool ReverseString(string s)
        {
            string newStr = "";
            foreach (char c in s)
            {
                if (char.IsLetterOrDigit(c))
                    newStr += char.ToLower(c);
            }
            return newStr == new string(newStr.Reverse().ToArray());
        }

        public bool IsPalindrome(string s)
        {
            int l = 0, r = s.Length - 1;

            while(l < r)
            {
                while (l < r && !AlphaNum(s[l]))
                    l++;

                while (r > l && !AlphaNum(s[r])) 
                    r--;

                if (char.ToLower(s[l]) != char.ToLower(s[r]))
                    return false;
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
