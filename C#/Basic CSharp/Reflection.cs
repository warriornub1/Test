using System.Reflection;

namespace Basic_CSharp
{
    public class Reflection
    {
        public Reflection()
        {
            /*
             Reflection is part of the System.Reflection namespace. You can use it to:

            Get information about types at runtime.
            Invoke methods dynamically.
            Create instances of types at runtime.
             */
            Type type = typeof(Person);
            Console.WriteLine($"Class Name: {type.Name}");

            // You can obtain type information using typeof(), .GetType(), or Assembly.GetType().
            PropertyInfo[] properties = type.GetProperties();
            foreach (var prop in properties)
            {
                Console.WriteLine($"Property: {prop.Name}, Type: {prop.PropertyType}");
            }

            // You can use Activator.CreateInstance() to create an object without knowing its type at compile time.
            object obj = Activator.CreateInstance(type);

            // You can use reflection to get method information and call methods dynamically.
            MethodInfo method = type.GetMethod("SayHello");
            method.Invoke(obj, new object[] { "John" });

            // You can use Activator.CreateInstance() to create an object without knowing its type at compile time.
            FieldInfo field = type.GetField("_secret", BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(obj, "This is a secret!");

            string secretValue = (string)field.GetValue(obj);
            Console.WriteLine($"Private Field Value: {secretValue}");
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        private string _secret = "Default Secret";


        public void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
