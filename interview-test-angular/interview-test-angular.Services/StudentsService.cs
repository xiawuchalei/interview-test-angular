using interview_test_angular.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interview_test_angular.Services
{
    public class StudentsService : IStudentsService
    {
        public List<Student> students = new List<Student>();

        public StudentsService()
        {
            students.Add(new Student
            {
                Id = 1,
                FirstName = "Marty",
                LastName = "McFly",
                Email = "back.future@test.com",
                Major = "History"
            });

            students.Add(new Student {
                Id = 2,
                FirstName = "Emmett",
                LastName = "Brown",
                Email = "dr.brown@test.com",
                Major = "Physics"
            });

            students.Add(new Student
            {
                Id = 3,
                FirstName = "Biff",
                LastName = "Tannen",
                Email = "biff@test.com",
                Major = "PE"
            });
        }

        public bool AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }
    }
}
