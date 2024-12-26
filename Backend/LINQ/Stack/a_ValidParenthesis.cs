namespace LINQ.Stack
{
    public class a_ValidParenthesis
    {
        public a_ValidParenthesis()
        {
            string s1 = "([{}])"; // true
            string s2 = "[(])"; // false
            Console.WriteLine(BruteForce(s1));
            Console.WriteLine(BruteForce(s2));
        }
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
            Dictionary<char, char> closeToOpen = new Dictionary<char, char>()
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
                        return false;
                }
                else
                    stack.Push(c);
            }
            return stack.Count == 0;
        }
    }
}
