using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.CSharpBasic.Ref
{
    public class Reference
    {
        /*
        Can value types be null?

        What is a struct and how does it differ from a class in terms
        of being a value type or reference type

        Is an array of int a value type?

        What is a nullable type?

        Why can reference types be null while value types cannot>
         */
        public Reference()
        {
            int a = 7;
            MyClass myClass = new MyClass();
            myClass.a = 7;

            MyClass myClass1 = myClass;
            myClass1.a = 5;

            Console.WriteLine(myClass.a); // 5

            MyStruct myStruct = new MyStruct();
            myStruct.a = 7;
            MyStruct mySecondStruct = myStruct;
            mySecondStruct.a = 5;
            Console.WriteLine(myStruct.a); // 7

            MyFunction(myClass, myStruct); // myClass ref is changed but not myStruct


            int b = 7;
            int[] intArray = new int[] { 7 };
            MyFunction1(b, intArray); // 7, 5 

            static void MyFunction(MyClass myClass, MyStruct myStruct)
            {
                myClass.a = 5;
                myStruct.a = 5;
            }

            static void MyFunction1(int b, int[] newArray)
            {
                b = 1;
                newArray[0] = 1;
            }
        }
    }


    public class MyClass
    {
        public int a;
    }

    public struct MyStruct
    {
        public int a;
    }
}
