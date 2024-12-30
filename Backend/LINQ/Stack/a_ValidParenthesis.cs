namespace LINQ.Stack
{
    public class a_ValidParenthesis
    {
        public a_ValidParenthesis()
        {
            string s1 = "([{}])"; // true
            string s2 = "[(])"; // false
            Console.WriteLine(Stacks(s1));
            Console.WriteLine(Stacks(s2));
        }

        public bool Stacks(string s)
        {
            Dictionary<char, char> lookup = new Dictionary<char, char>()
            {
                {  ')', '(' },
                {  '}', '{' },
                {  ']', '[' }
            };

            Stack<char> ss = new Stack<char>();
            foreach (char c in s)
            {
                if (lookup.ContainsKey(c) && ss.Count > 0)
                {
                    char param = ss.Pop();
                    if (param != lookup[c])
                    {
                        return false;
                    }

                }
                else
                {
                    ss.Push(c);
                }

            }
            return ss.Count == 0;
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
