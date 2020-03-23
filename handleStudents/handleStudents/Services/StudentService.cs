using handleStudents.Models;
using handleStudents.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace handleStudents.Services
{
    public class StudentService : IStudentService
    {
        public StudentRepository repository = new StudentRepository();

        public void GetAllStudents()
        {
            PrintStudents(repository.GetAllStudents());
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
            Student resullt = repository.AddNewStudent(student);
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
            repository.DeleteStudent(studentId);
            PrintStudents(repository.GetAllStudents());
        }

        public void SearchStudentsByGenderAndElementary()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Searh student by gender and type");
            Console.WriteLine("Please, insert kind of student to search, you can choose between kinder, elementary, high and university");
            string studentType = (Console.ReadLine()).ToLower();
            Console.WriteLine("Please, insert the gender of your student to search, you can choose between M(Male) and F(Female)");
            string genderStudent = (Console.ReadLine()).ToUpper();
            PrintStudents(repository.GetStudentsByGenderAndElementary(genderStudent, studentType));
        }

        public void SearchStudentsByName()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Please, insert the student name to search");
            string nameStudent = Console.ReadLine();
            PrintStudents(repository.GetStudentsByName(nameStudent));
        }

        public void SearchStudentsByTypeOfStudent()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Please, insert the type of student to search,  you can choose between kinder, elementary, high and university");
            string studentType = (Console.ReadLine()).ToLower();
            PrintStudents(repository.GetStudentsByTypeOfStudent(studentType));
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
    }
}
