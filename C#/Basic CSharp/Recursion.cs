using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_CSharp
{
    public class Recursion
    {
        public Recursion()
        {
            
        }

        public int RecursionIncrementer(int number, int numberMax, int incrementAmount)
        {
            if (number < numberMax)
            {
                return RecursionIncrementer(number + incrementAmount, numberMax, number);
            }
            else
            {
                return number;
            }
        }
    }
}
