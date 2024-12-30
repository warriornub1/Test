using System.Numerics;

namespace LINQ.Stack
{
    public class c_Evaluate_Reverse_Polish_Notation
    {
        public c_Evaluate_Reverse_Polish_Notation()
        {
            string[] tokens = new string[]
            {
                "1","2","+","3","*","4","-"
            };
            Console.WriteLine("Reverse Polish Notation");
            Console.WriteLine(Stack1(tokens));
        }

        public int Stack1(string[] tokens)
        {
            Stack<int> ss = new Stack<int>();

            int total = 0;
            foreach (string s in tokens)
            {
                if (s == "+")
                {
                    total = ss.Pop() + ss.Pop();
                    ss.Push(total);
                }
                else if (s == "-")
                {
                    int a = ss.Pop();
                    int b = ss.Pop();
                    total = b - a;
                    ss.Push(total);
                }
                else if(s == "*")
                {
                    total = ss.Pop() * ss.Pop();
                    ss.Push(total);
                }
                else if(s == "/")
                {
                    int a = ss.Pop();
                    int b = ss.Pop();
                    total = b / a;
                    ss.Push(total);
                }
                else
                {
                    ss.Push(int.Parse(s));
                }
            }
            return ss.Pop();
        }

        public int Stack(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            foreach(string c in tokens)
            {
                if (c == "+")
                    stack.Push(stack.Pop() + stack.Pop());
                else if (c == "-")
                    stack.Push(stack.Pop() - stack.Pop());
                else if (c == "*")
                    stack.Push(stack.Pop() * stack.Pop());
                else if (c == "/")
                    stack.Push((int)((double)stack.Pop() / stack.Pop()));
                else
                    stack.Push(int.Parse(c));
                

            }
            return stack.Pop();
        }
    }
}
