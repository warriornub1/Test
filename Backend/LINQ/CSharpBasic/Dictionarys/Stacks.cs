namespace LINQ.CSharpBasic.Dictionarys
{
    public class Stacks
    {
        public Stacks()
        {
            Stack<string> nameStack = new Stack<string>();
            nameStack.Push("Code Moneky");
            nameStack.Push("Iron Man");
            nameStack.Push("Spider-Man");

            nameStack.Pop();
            nameStack.Peek();
        }
    }
}
