namespace LINQ.LINQ
{
    public class b_OrderBy
    {
        public b_OrderBy()
        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice", Age = 20 },
                new Student { Id = 2, Name = "Bob", Age = 22 },
                new Student { Id = 3, Name = "Charlie", Age = 19 },
                new Student { Id = 4, Name = "Diana", Age = 23 },
            };

            // Sort by Age (Ascending)
            var sortedByAge = students.OrderBy(s => s.Age);

            // Sort by Age (Descending)
            var sortedByAgeDesc = students.OrderByDescending(s => s.Age);

            // Sorting with Multiple Criteria
            var sortedByAgeAndName = students
                                    .OrderBy(s => s.Age)
                                    .ThenBy(s => s.Name);

            // Aggregating Student Ages
            var totalAge = students.Sum(s => s.Age);
            var averageAge = students.Average(s => s.Age);
            var youngestAge = students.Min(s => s.Age);
            var oldestAge = students.Max(s => s.Age);

        }
    }
}
