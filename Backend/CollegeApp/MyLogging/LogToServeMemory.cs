namespace CollegeApp.MyLogging
{
    public class LogToServeMemory : IMyLogger
    {
        public void Log(string message) 
        {
            Console.WriteLine(message);
            Console.WriteLine("Logto Server memory");
        }
    }
}
