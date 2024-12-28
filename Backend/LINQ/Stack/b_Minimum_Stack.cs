namespace LINQ.Stack
{
    public class b_Minimum_Stack
    {
        private Stack<int> stack;
        private Stack<int> minStack;
        public b_Minimum_Stack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int val)
        {
            stack.Push(val);
            val = Math.Min(val, minStack.Count == 0 ? val : minStack.Peek());
            minStack.Push(val);
        }

        public void Pop()
        {
            stack.Pop();
            minStack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();

        }

    }
}
