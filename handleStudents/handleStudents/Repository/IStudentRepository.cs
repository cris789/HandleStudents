using handleStudents.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace handleStudents.Repository
{
    public interface IStudentRepository
    {
        public Student AddNewStudent( Student student);
        public IEnumerable<Student> GetAllStudents();
        public Boolean DeleteStudent(string id);
        public IEnumerable<Student> GetStudentsByName( string name);
        public IEnumerable<Student> GetStudentsByTypeOfStudent(string school);
        public IEnumerable<Student> GetStudentsByGenderAndType(string gender, string studenTtype);
    }
}
