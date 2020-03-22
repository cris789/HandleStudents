using System;
using System.Collections.Generic;
using System.Text;
using handleStudents.Models;

namespace handleStudents.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public static List<Student> _students;

        public StudentRepository()
        {
            _students = new List<Student>();
        }

        public bool DeleteStudent(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudent()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsByGender(string gender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsByTypeOfSchool(string school)
        {
            throw new NotImplementedException();
        }

        public Student AddNewStudent(Student student)
        {
            student.EnrollmentDate = DateTime.Now;
            _students.Add(student);
            return student;
        }
    }
}
