namespace LINQ.LINQ
{
    public class a_GroupBy
    {
        public a_GroupBy()
        {

            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice", Age = 20 },
                new Student { Id = 2, Name = "Bob", Age = 22 },
                new Student { Id = 3, Name = "Charlie", Age = 22 },
                new Student { Id = 4, Name = "Diana", Age = 20 },
            };

            // Group by Age
            var groupedByAge = from student in students
                               group student by student.Age into ageGroup
                               select ageGroup;

            Console.WriteLine("Students grouped by age:");
            foreach (var group in groupedByAge)
            {
                Console.WriteLine($"\nAge Group: {group.Key}");
                foreach (var student in group)
                {
                    Console.WriteLine($" - {student.Name}");
                }
            }

            //var studentGroup = from student in students
            //                   where student.Age == 20
            //                   group student by student.Department into departmentGroup
            //                   select departmentGroup;
                               
        }
    }
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
    }
}
