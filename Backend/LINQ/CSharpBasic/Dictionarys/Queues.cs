namespace LINQ.CSharpBasic.Dictionarys
{
    public class Queues
    {
        public Queues()
        {
            Queue<string> stringQueue = new Queue<string>();
            stringQueue.Enqueue("Code Monkey");
            stringQueue.Enqueue("Iron Man");
            stringQueue.Enqueue("Spider-Man");

            stringQueue.Dequeue();
        }
    }
}
