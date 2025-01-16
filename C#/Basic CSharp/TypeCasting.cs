namespace Basic_CSharp
{
    public class TypeCasting
    {
        public TypeCasting()
        {
            object obj = 42;
            int number = (int)obj; // Explicit cast from object to int
            Console.WriteLine(number); // Output: 42

            object obj1 = "Hello, World!";
            if (obj1 is string)
            {
                Console.WriteLine($"'{obj1}' is a string!");
            }
            // Output: 'Hello, World!' is a string!

            string str = obj1 as string; // Safe cast
            if (str != null)
            {
                Console.WriteLine($"The string is: {str}");
            }
            // Output: The string is: Hello, World!

        }
    }
}
