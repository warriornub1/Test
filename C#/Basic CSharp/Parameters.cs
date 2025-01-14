using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Basic_CSharp
{
    public class Parameters
    {
        public Parameters()
        {
            PrintPlayername(35, "code", "string", "Iron man");
        }

        private static void PrintPlayername(int age, params string[] playerBaneArray)
        {
            Console.WriteLine(playerBaneArray.Length);
        }
    }
}
