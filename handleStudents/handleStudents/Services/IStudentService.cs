using handleStudents.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace handleStudents.Services
{
   public interface IStudentService
    {
        public Student RegisterStudent(string name, string typeStudent, string gender);
        public Boolean RemoveStudent();
        public IEnumerable<Student> GetAllStudents();
        public IEnumerable<Student> SearchStudentsByName(string name);
        public IEnumerable<Student> SearchStudentsByTypeOfStudent(string typeOfStudent);
        public IEnumerable<Student> SearchStudentsByGenderAndType(string gender, string typeOfStudent);
        public void ReadCsvFile(string path);
        public Student AddStudentFromCsvFile(string name, string gender, string typeOfStudent, string enrollment);
        public void PrintStudents(IEnumerable<Student> students);
    }
}
