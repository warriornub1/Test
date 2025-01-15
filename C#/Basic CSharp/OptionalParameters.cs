using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_CSharp
{
    public class OptionalParameters
    {
        public OptionalParameters()
        {
            // Calling the method with different arguments
            Greet();                      // Output: Hello, Guest!
            Greet("Alice");               // Output: Hello, Alice!
            Greet("Bob", "Hi");           // Output: Hi, Bob!
        }
        // Method with optional parameters
        void Greet(string name = default, string greeting = "Hello")
        {
            Console.WriteLine($"{greeting}, {name}!");
        }


    }
}
