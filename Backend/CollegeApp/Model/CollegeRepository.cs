namespace CollegeApp.Model
{
    public static class CollegeRepository
    {
        public static List<Student> Students { get; set; } = new List<Student>()
        {
            new Student
            {
                Id = 1,
                StudentName = "Student 1",
                Email = "Studentemail@gmail.com",
                Address = "Hyd, India"
            },
            new Student
            {
                Id = 2,
                StudentName = "Student 2",
                Email = "Student2email@gmail.com",
                Address = "Hyd, India"
            }
        };
    }
}
