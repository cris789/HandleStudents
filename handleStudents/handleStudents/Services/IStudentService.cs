using handleStudents.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace handleStudents.Services
{
   public interface IStudentService
    {
        public void RegisterStudent();
        public void RemoveStudent();
        public void GetAllStudents();
        public void SearchStudentsByName(string name);
        public void SearchStudentsByTypeOfStudent(string typeOfStudent);
        public void SearchStudentsByGenderAndType(string gender, string typeOfStudent);
        public void ReadCsvFile(string path);
        public Student AddStudentFromCsvFile(string name, string gender, string typeOfStudent, string enrollment);
    }
}
