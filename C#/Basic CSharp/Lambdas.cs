using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_CSharp
{
    public class Lambdas
    {
        public Lambdas()
        {
            print("Message");

            Action<string> myAction = (string message) =>
            {
                Console.WriteLine(message);
            };

            void print(string message)
            {
                Console.WriteLine(message);
            }

            Action<string> myaction2 = print;
        }
    }
}
