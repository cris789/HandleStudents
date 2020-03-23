using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using handleStudents.Exceptions;
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

        public bool DeleteStudent(string id)
        {
            try
            {
              Guid oldGuid = Guid.Parse(id);
              var item = _students.SingleOrDefault(x => x.Id == oldGuid);
              return _students.Remove(item);

            } catch (Exception ex)
            {
                throw new RepositoryException($"Invalid student id: {id}");
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students.OrderBy(x => x.Name).ToList(); ;
        }

        public IEnumerable<Student> GetStudentsByGenderAndElementary(string gender, string studenTtype)
        {
            var typeStudent = (StudentType)Enum.Parse(typeof(StudentType), studenTtype);
            var studentGender = (Gender)Enum.Parse(typeof(Gender), gender);
            List<Student> users = _students.FindAll(x => (x.StudentType == typeStudent) && (x.Gender == studentGender));
            users.Sort((a, b) => (b.EnrollmentDate).CompareTo(a.EnrollmentDate));
            return users;
        }

        public IEnumerable<Student> GetStudentsByName(string name)
        {
            return (_students.Where(x => x.Name.Contains(name))).OrderBy(x => x.Name).ToList();
        }

        public IEnumerable<Student> GetStudentsByTypeOfStudent(string type)
        {
            var typeStudent = (StudentType)Enum.Parse(typeof(StudentType), type);

            List<Student> users = _students.Where(x => x.StudentType == typeStudent).ToList();
            users.Sort((a, b) => (b.EnrollmentDate).CompareTo(a.EnrollmentDate));
            return users;
        }

        public Student AddNewStudent(Student student)
        {
            _students.Add(student);
            return student;
        }
    }
}
