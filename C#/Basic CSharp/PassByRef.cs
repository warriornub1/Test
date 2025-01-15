namespace Basic_CSharp
{
    public class PassByRef
    {
        public PassByRef()
        {
            MyClass myClass = new MyClass();
            myClass.a = 7;

            MyClass mySecondClass = myClass;
            mySecondClass.a = 5; // Pass by reference

            MyStruct myStruct = new MyStruct();
            myStruct.a = 7;
            MyStruct mySecondStruct = myStruct;
            myStruct.a = 5; // Pass by value

            int? nullableInt = null;  // Shorthand
            Nullable<int> nullableInt1 = null;  // Equivalent
            var res = nullableInt.HasValue == true; // true if not null, false otherwise
            nullableInt.GetValueOrDefault(); // Returns 0 (default for int)
            nullableInt1.GetValueOrDefault(42); // Returns 42 if null


            /*
            Key Points:
            The variable must be initialized before passing it with ref.
            Changes made inside the method affect the original variable.

             */
            int value = 5;
            ModifyRef(ref value);
            Console.WriteLine(value); // Output: 15

            //Key Points:
            //The variable does not need to be initialized before passing it with out.
            //The method must assign a value to the variable before it returns.


            int result;
            AssignOut(out result);
            Console.WriteLine(result); // Output: 42
        }

        void ModifyRef(ref int number)
        {
            number += 10;
        }


        private static void MyFunction(MyClass myClass, MyStruct myStruct)
        {
            myClass.a = 7;
            myStruct.a = 5;
        }
        void AssignOut(out int number)
        {
            number = 42; // Must assign a value
        }
        private static void Myfunction(int a, int[] intArray)
        {
            a = 7;
            intArray[0] = 5;
        }
    }

    public class MyClass
    {
        public int a { get; set; }
    }

    public struct MyStruct
    {
        public int a { get; set; }
    }
}
