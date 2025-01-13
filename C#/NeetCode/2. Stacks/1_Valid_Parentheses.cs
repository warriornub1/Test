using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode._2._TwoPointers
{
    public class _1_Valid_Parentheses
    {
        public bool BruteForce(string s)
        {
            while (s.Contains("()") || s.Contains("{}") || s.Contains("[]"))
            {
                s = s.Replace("()", "");
                s = s.Replace("{}", "");
                s = s.Replace("[]", "");
            }
            return s == "";
        }

        public bool Stack(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> closeToOpen = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            foreach(char c in s)
            {
                if (closeToOpen.ContainsKey(c))
                {
                    if (stack.Count > 0 && stack.Peek() == closeToOpen[c])
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }
            return stack.Count == 0;
        }
    }

    }
}
