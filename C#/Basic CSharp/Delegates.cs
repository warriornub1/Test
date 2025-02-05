using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Basic_CSharp
{
    public delegate void MyDelegate(string message);

    public class Delegates
    {
        public Delegates()
        {
            // Basic Syntax of a Delegate
            MyDelegate del = PrintMessage1;
            del("Hello delegates!");

            // Multicast Delegates
            MyDelegate del1 = PrintMessage1;
            del1 += PrintMessage2;
            del1("Hello Test");

            // Using Delegates as Parameters
            Execute(PrintMessage1, "Test");

            // Built-in generic delegates

            // Using Func<T, TResult> (method with return value)
            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine(add(5, 3));

            // Using Action<T> (method with no return value)
            Action<int, int> add1 = (a, b) => Console.WriteLine(a + b);
            add1(1, 2);
        }

        public void PrintMessage1(string msg)
        {
            Console.WriteLine("PrintMessage1" + msg);
        }

        public void PrintMessage2(string msg)
        {
            Console.WriteLine("PrintMessage2" + msg);
        }

        public void Execute(MyDelegate del, string msg)
        {
            del(msg);
        }
    }
}
