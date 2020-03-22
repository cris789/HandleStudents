using handleStudents.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace handleStudents.Repository
{
    public interface IStudentRepository
    {
        public Student AddNewStudent( Student student);
        public Student GetStudent();
        public IEnumerable<Student> GetAllStudents();
        public Boolean DeleteStudent(Guid id);
        public IEnumerable<Student> GetStudentsByName( string name);
        public IEnumerable<Student> GetStudentsByTypeOfSchool(string school);
        public IEnumerable<Student> GetStudentsByGender(string gender);
    }
}
