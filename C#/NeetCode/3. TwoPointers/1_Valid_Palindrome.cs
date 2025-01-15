using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode._3._TwoPointers
{
    public class _1_Valid_Palindrome
    {
        public _1_Valid_Palindrome()
        {
            string s = "Was it a car or a cat I saw?";
            string t = "tab a cat";
            Console.WriteLine( ReverseString(s) );
            Console.WriteLine( ReverseString(t) );
            Console.WriteLine( TwoPointers(s) );
            Console.WriteLine( TwoPointers(t) );
        }
        public bool ReverseString(string s)
        {
            string result = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetterOrDigit(s[i]))
                    result += char.ToLower(s[i]);
            }
            return result == new string(result.Reverse().ToArray());
        }

        public bool TwoPointers(string s)
        {
            int i = 0; int j = s.Length - 1;
            while(i < j)
            {
                while (i < j && !AlphaNum(s[i]))
                    i++;

                while (i < j && !AlphaNum(s[j]))
                    j--;

                if (char.ToLower( s[i] ) != char.ToLower( s[j] ) )
                    return false;

                i++; j--;
            }
            return true;
        }

        public bool AlphaNum(char c)
        {
            if (c >= 'a' && c <= 'z' ||
                c >= 'A' && c <= 'Z' ||
                c >= '1' && c <= '9')
                return true;
            else
                return false;
        }
    }
}
