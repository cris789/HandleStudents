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

        /// <summary>
        ///   This function return all students from studen list
        ///   and send the information to print on console
        /// </summary>
        /// <returns>List of students </returns>
        public void GetAllStudents()
        {
            PrintStudents(_studentRepository.GetAllStudents());
        }

        /// <summary>
        ///   This function register a student
        /// </summary>
        /// <param name="name">the name of the student</param>
        /// <param name="type">you can choose between kinder, elementary, high and university</param>
        /// <param name="gender">you can choose between M(Male) and F(Female)</param>
        /// <returns>Print on console the student that was registered</returns>
        /// <response code="200">The token was generated.</response>
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

        /// <summary>
        ///   This function remove a student
        /// </summary>
        /// <param name="studentId">the student id</param>
        /// <returns>Print on console the all students after to remove the student</returns>
        /// <response boolean="true">confirm if the user was deleted</response>
        /// <response boolean="false">"The student that you wish delete was not found</response>
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

        /// <summary>
        ///   This function Search students by gender and type
        /// </summary>
        /// <param name="gender">insert the gender of student </param>
        /// <param name="typeOfStudent">insert the type of student</param>
        /// <returns>Print on console the all students order by most recent</returns>
        public void SearchStudentsByGenderAndType(string gender, string typeOfStudent)
        {
            PrintStudents(_studentRepository.GetStudentsByGenderAndType(gender, typeOfStudent));
        }

        /// <summary>
        ///   This function search students by name
        /// </summary>
        /// <param name="name">insert the name of student </param>
        /// <returns>Print on console the all students order by most recent</returns>
        public void SearchStudentsByName(string name)
        {
            PrintStudents(_studentRepository.GetStudentsByName(name));
        }

        /// <summary>
        ///   This function search students by type
        /// </summary>
        /// <param name="typeOfStudent">insert type of student </param>
        /// <returns>Print on console the all students order by most recent</returns>
        public void SearchStudentsByTypeOfStudent(string typeOfStudent)
        {
            PrintStudents(_studentRepository.GetStudentsByTypeOfStudent(typeOfStudent));
        }

        /// <summary>
        ///   This function print students
        /// </summary>
        /// <param name="students"> insert IEnumerable<Student> this a students list </param>
        /// <returns>Print on console the all students</returns>
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

        /// <summary>
        ///   This function read csv file and send the information to add the student
        /// </summary>
        /// <param name="path">the path of the csv file</param>
        /// <returns>Print on console the all students</returns>
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

        /// <summary>
        ///   This function add student from csv file
        /// </summary>
        /// <param name="name">the name of the student</param>
        /// <param name="typeOfStudent">you can choose between kinder, elementary, high and university</param>
        /// <param name="gender">you can choose between M(Male) and F(Female)</param>
        /// <param name="enrollment">insert the date of student enrollment on string</param>
        /// <returns>return a student that was registered</returns>
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
