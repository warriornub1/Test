using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.CSharpBasic.Param
{
    public class Params
    {
        public Params()
        {
            PrintPlayerName(35, "Code", "string", "Iron Man");
        }

        private void PrintPlayerName(int age, params string[] playerNameArray)
        {
            Console.WriteLine(playerNameArray.Length);
        }

    }
}
