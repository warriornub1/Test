using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_CSharp
{
    public class Enums
    {
        enum DaysOfWeek
        {
            Sunday,    // 0
            Monday,    // 1
            Tuesday,   // 2
            Wednesday, // 3
            Thursday,  // 4
            Friday,    // 5
            Saturday   // 6
        }
        public Enums()
        {
            DaysOfWeek today = DaysOfWeek.Monday;

            Console.WriteLine(today);          // Output: Monday
            Console.WriteLine((int) today);     // Output: 1


            foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
            {
                Console.WriteLine(day);
            }
        }
    }
}
