using System.Runtime.CompilerServices;

namespace Basic_CSharp
{
    public class Delegates
    {
        delegate void MyDelegate(string message);
        public Delegates()
        {
            // A delegate is a type that represents a reference to a method with a specific signature.

            // Assign a method to the delegate
            MyDelegate del = PrintMessage;
            del("Hello world !");

            // Using an anonymous method
            MyDelegate delAnon = delegate (string msg)
            {
                Console.WriteLine(msg);
            };
            delAnon("Anonymous Method!");

            // Using a lambda expression
            MyDelegate delLambda = msg => Console.WriteLine(msg);
            delLambda("Lambda Expression !");

            /*
             * Action is a predefined delegate provided by .NET that represents a method that takes no return value.
            */
            Action sayHello = () => Console.WriteLine("Hello World");
            sayHello();

            // With parameters
            Action<string> printMessage = msg => Console.WriteLine(msg);
            printMessage("Using Action!");

            Action<int, int> add = (a, b) => Console.WriteLine($"Sum: {a + b}");
            add(5, 10);

            // Func is a predefined delegate that represents a method with a return value. The last type parameter specifies the return type.
            // No parameters, returns a value
            Func<string> getMessage = () => "Hello from Func!";
            Console.WriteLine(getMessage());

            // With parameters, returns a value
            Func<int, int, int> multiply = (a, b) => a * b;
            Console.WriteLine($"Product: {multiply(5, 10)}");

            Func<string, int> stringLength = s => s.Length;
            Console.WriteLine($"Length: {stringLength("C# Programming")}");

            /*
            Delegates: Use when you need a custom delegate type or want to enforce a specific signature explicitly.
            Action: Use when you need a method reference that performs an action but does not return a value.
            Func: Use when you need a method reference that performs an operation and returns a value.
            */


            MyDelegate del1;

            // Assign a method
            del1 = Method1;

            // Add another method
            del1 += Method2;

            // Add a third method
            del1 += Method3;

            // Invoke the multicast delegate
            del1("Hello, Multicast Delegate!");

            // Remove a method
            del1 -= Method2;

            Console.WriteLine("\nAfter removing Method2:");
            del1("Hello again!");

        }

        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void Method1(string message)
        {
            Console.WriteLine($"Method1: {message}");
        }

        static void Method2(string message)
        {
            Console.WriteLine($"Method2: {message}");
        }

        static void Method3(string message)
        {
            Console.WriteLine($"Method3: {message}");
        }

    }
}
