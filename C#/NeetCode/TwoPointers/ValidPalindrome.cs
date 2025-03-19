using System.Security.Cryptography.X509Certificates;

namespace NeetCode.TwoPointers
{
    public class ValidPalindrome
    {
        public bool IsPalindrome(string s)
        {
            string newStr = "";
            foreach (char c in s)
            {
                if(char.IsLetterOrDigit(c))
                    newStr += c;
            }

            return newStr == new string(newStr.Reverse().ToArray());
        }

        public bool TwoPointer(string s)
        {
            int l = 0, r = s.Length - 1;
            while (l < r) {
                while (l < r && !AlphaNum(s[l]))
                    l++;
                while (r > l && !AlphaNum(s[r]))
                    r--;
                l++; r--;

            }
            return true;
        }

        public bool AlphaNum(char c) {
            return (c >= 'A' && c <= 'Z' ||
                     c >= 'a' && c <= 'z' ||
                     c >= '0' && c <= '9'); 
        }
    }
}
