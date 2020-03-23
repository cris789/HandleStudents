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
        public void SearchStudentsByName();
        public void SearchStudentsByTypeOfStudent();
        public void SearchStudentsByGenderAndElementary();
        public void ReadCsvFile(string path);
        public Student AddStudentFromCsvFile(string name, string gender, string typeOfStudent, string enrollment);
    }
}
