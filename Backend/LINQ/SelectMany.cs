using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class SelectMany
    {
        // SeletMany is used to project each element of a sequence to an IEnumerable<T> and flattens the resulting 
        // sequences into one sequence
        public SelectMany()
        {
            IEnumerable<string> subjects = Student.GetAllStudents().SelectMany(x => x.Subjects);
            foreach (string subject in subjects)
            {
                Console.WriteLine(subject);
            }
            
            IEnumerable<string> allSubjects = from student in Student.GetAllStudents()
                                              from subject in student.Subjects
                                              select subject;

            foreach (string subject in allSubjects)
            {
                Console.WriteLine(subject);
            }

            // Example 2
            string[] stringArray =
            {
                "ABCDEFG",
                "01234"
            };

            IEnumerable<char> result = stringArray.SelectMany(x => x);
            IEnumerable<char> result1 = from s in stringArray
                                        from c in s
                                        select c;

            // Example 3 Select student name along with all the subjects

            var result2 = Student.GetAllStudents().SelectMany(s => s.Subjects, (student, subject) =>
                                                            new { StudentName = student.Name, Subject = subject });

            var result3 = from student in Student.GetAllStudents()
                          from subject in student.Subjects
                          select new { StudentName = student.Name, SubjectName = subject };

            foreach (var res in result2)
            {
                Console.WriteLine(res.StudentName + " " + res.Subject);
            }
        }
    }
}
