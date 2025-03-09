using System;

namespace Basic_CSharp
{
    public class Delegate
    {
        public delegate void MyDelegate(string message);
        public delegate void Notify();


        public static void ShowMessage(string message)
        {
            Console.WriteLine("Message: " + message);
        }


        public static void Message1() => Console.WriteLine("Message 1");
        public static void Message2() => Console.WriteLine("Message 2");

        static void PrintMessage(string message)
        {
            Console.WriteLine("Message: " + message);
        }

        public Delegate()
        {
            // Create an instance of the delegate and assign a method
            MyDelegate del = ShowMessage;

            // Invoke the delegate
            del("Hello, Delegates!");

            Notify del1 = Message1;
            del1 += Message2; // Add another method

            del1(); // Calls both Message1 and Message2

            // The Action<T> delegate represents a method that takes parameters but does not return a value.
            Action<string> action = PrintMessage; // Assign method to Action
            action("Hello, Action!"); // Invoke the delegate

            //Action<T1, T2, T3> can take up to 16 parameters but always returns void.
            Action<int, int> add = (a, b) => Console.WriteLine(a + b);
            add(5, 10);  // Output: 15

            // Func<T, TResult> delegate represents a method that takes parameters and returns a value.
            Func<int, int, int> add1 = (a, b) => a + b;
            Console.WriteLine(add1(5, 10)); // Output: 15

            // The Predicate<T> delegate represents a method that takes one parameter and returns a bool.
            Predicate<int> isEven = num => num % 2 == 0;
            Console.WriteLine(isEven(10)); // Output: True
            Console.WriteLine(isEven(7));  // Output: False

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> evenNumbers = numbers.FindAll(isEven);

            Console.WriteLine(string.Join(", ", evenNumbers)); // Output: 2, 4, 6

        }
    }
}
