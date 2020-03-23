using handleStudents.Models;
using handleStudents.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace handleStudents.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void GetAllStudents()
        {
            PrintStudents(_studentRepository.GetAllStudents());
        }

        public void RegisterStudent()
        {
            Student student= new Student();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Please, insert the name of your student");
            string name = Console.ReadLine();
            Console.WriteLine("Please, insert kind of student, you can choose between kinder, elementary, high and university");
            string studentType = Console.ReadLine();
            var typeStudent = (StudentType)Enum.Parse(typeof(StudentType), studentType);
            Console.WriteLine("Please, insert the gender of your student, you can choose between M(Male) and F(Female)");
            string genderStudent = Console.ReadLine();
            var typeStudentGender = (Gender)Enum.Parse(typeof(Gender), genderStudent);
            student.Id = Guid.NewGuid();
            student.Name = name;
            student.StudentType = typeStudent;
            student.Gender = typeStudentGender;
            student.EnrollmentDate = DateTime.Now;

            Student resullt = _studentRepository.AddNewStudent(student);
            Console.WriteLine("Your student was stored successfully with the following information:");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Student ID                             Name            kind of student         Gender of student          Enrollment date");
            Console.WriteLine($"{resullt.Id}   {resullt.Name}           {resullt.StudentType}                    {resullt.Gender}                        {resullt.EnrollmentDate}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public void RemoveStudent()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Please, insert the ID of your student to delete");
            string studentId = Console.ReadLine();
            if (_studentRepository.DeleteStudent(studentId))
            {
                PrintStudents(_studentRepository.GetAllStudents());
            }
            else
            {
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"The student that you wish delete was not found with id: {studentId}");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            }
        }

        public void SearchStudentsByGenderAndElementary(string gender, string typeOfStudent)
        {
            PrintStudents(_studentRepository.GetStudentsByGenderAndElementary(gender, typeOfStudent));
        }

        public void SearchStudentsByName(string name)
        {
            PrintStudents(_studentRepository.GetStudentsByName(name));
        }

        public void SearchStudentsByTypeOfStudent(string typeOfStudent)
        {
            PrintStudents(_studentRepository.GetStudentsByTypeOfStudent(typeOfStudent));
        }

        private void PrintStudents(IEnumerable<Student> students)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Student ID                             Name            kind of student         Gender of student          Enrollment date");
            foreach (Student user in students)
            {
                Console.WriteLine($"{user.Id}   {user.Name}            {user.StudentType}                   {user.Gender}                         {user.EnrollmentDate}");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public void ReadCsvFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string currentLine;
                int header = 0;
                while ((currentLine = sr.ReadLine()) != null)
                {
                    if(header == 0)
                    {
                        string[] data = currentLine.Split(',');
                        header++;
                    }
                    else
                    {
                        string []data = currentLine.Split(',');
                        AddStudentFromCsvFile(data[0] , data[1], data[2], data[3]);
                    }
                }
            }
            GetAllStudents();
        }

        public Student AddStudentFromCsvFile(string name, string gender, string typeOfStudent, string enrollment)
        {
            Student student = new Student();
            var typeStudent = (StudentType)Enum.Parse(typeof(StudentType), typeOfStudent);
            var typeStudentGender = (Gender)Enum.Parse(typeof(Gender), gender.ToUpper());
            student.Id = Guid.NewGuid();
            student.Name = name.ToLower();
            student.StudentType = typeStudent;
            student.Gender = typeStudentGender;
            student.EnrollmentDate = DateTime.ParseExact(enrollment, "yyyyMMddHHmmssFFF", null);
            Student resullt = _studentRepository.AddNewStudent(student);
            return resullt;
        }
    }
}
