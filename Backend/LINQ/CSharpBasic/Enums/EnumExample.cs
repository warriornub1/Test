using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.CSharpBasic.Enums
{
    public class EnumExample
    {
        public enum DaysOfWeek
        {
            Sunday = 1,
            Monday = 2,
            Tuesday = 3,
            Wednesday = 4,
            Thursday = 5,
            Friday = 6,
            Saturday= 7,
        }

        public EnumExample()
        {
            DaysOfWeek today = DaysOfWeek.Monday;
            if(today == DaysOfWeek.Monday)
                Console.WriteLine("It's Monday!");

            Console.WriteLine(today.ToString()); // Outputs : "Monday"

            DaysOfWeek day = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), "Friday");

            foreach(var dayy in Enum.GetValues(typeof(DaysOfWeek)))
            {
                Console.WriteLine(dayy);
            }
        }

    }
}
