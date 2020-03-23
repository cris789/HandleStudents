using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        ///   This function delete a student
        /// </summary>
        /// <param name="id">id of the student to delete</param>
        /// <returns>boolean to confirm if the student was deleted </returns>
        ///  <exception cref="System.Exception">Thrown when one id is incorrect format, 
        /// because the id is Guid.</exception>
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

        /// <summary>
        ///   This function return all students
        /// </summary>
        /// <returns>return all students order by alphabetically</returns>
        public IEnumerable<Student> GetAllStudents()
        {
            return _students.OrderBy(x => x.Name).ToList(); ;
        }

        /// <summary>
        ///   This function Get students by gender and type 
        /// </summary>
        /// <param name="studenTtype">you can choose between kinder, elementary, high and university</param>
        /// <param name="gender">you can choose between M(Male) and F(Female)</param>
        /// <returns>return all students order by most recent to least recent</returns>
        public IEnumerable<Student> GetStudentsByGenderAndType(string gender, string studenTtype)
        {
            var typeStudent = (StudentType)Enum.Parse(typeof(StudentType), studenTtype.ToLower());
            var studentGender = (Gender)Enum.Parse(typeof(Gender), gender.ToUpper());
            List<Student> users = _students.FindAll(x => (x.StudentType == typeStudent) && (x.Gender == studentGender));
            users.Sort((a, b) => (b.EnrollmentDate).CompareTo(a.EnrollmentDate));
            return users;
        }

        /// <summary>
        ///   This function return all students with the same name
        /// </summary>
        /// <param name="name">name of student to search</param>
        /// <returns>return all order by alphabetically </returns>
        public IEnumerable<Student> GetStudentsByName(string name)
        {
            return (_students.Where(x => x.Name.Contains(name.ToLower()))).OrderBy(x => x.Name).ToList();
        }

        /// <summary>
        ///   This function return all students  by type
        /// </summary>
        /// <param name="type">you can choose between kinder, elementary, high and university</param>
        /// <returns>return all students  by type order by most recent to least recent </returns>
        public IEnumerable<Student> GetStudentsByTypeOfStudent(string type)
        {
            var typeStudent = (StudentType)Enum.Parse(typeof(StudentType), type.ToLower());

            List<Student> users = _students.Where(x => x.StudentType == typeStudent).ToList();
            users.Sort((a, b) => (b.EnrollmentDate).CompareTo(a.EnrollmentDate));
            return users;
        }

        /// <summary>
        ///   This function store a student on the students list
        /// </summary>
        /// <param name="student">information of student to store</param>
        /// <returns>return a student that was stored</returns>
        public Student AddNewStudent(Student student)
        {
            student.Name = student.Name.ToLower();
            _students.Add(student);
            return student;
        }
    }
}
