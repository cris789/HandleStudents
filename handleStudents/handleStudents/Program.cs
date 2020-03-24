﻿using handleStudents.Models;
using handleStudents.Repository;
using handleStudents.Services;
using handleStudents.Tools;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace handleStudents
{
    class Program
    {
        private static ServiceProvider _serviceProvider;

        /// <param name="name">An option whose argument is parsed as an int</param>
        /// <param name="type">An option whose argument is parsed as a bool</param>
        /// <param name="gender">An option whose argument is parsed as a FileInfo</param>
        /// <param name="input">An option whose argument is parsed as a FileInfo</param>
        static void Main(string name = "", string type = "", string gender = "", FileInfo input = null)
        {
            RegisterServices();

            var studentService = _serviceProvider.GetService<IStudentService>();
            var mockTool = _serviceProvider.GetService<IMockTool>();

            DisposeServices();

            Console.WriteLine($"The value of name is: {name}");
            Console.WriteLine($"The value of type is: {type}");
            Console.WriteLine($"The value of gender is: {gender}");
            Console.WriteLine($"The value of input file is: {input?.FullName ?? "Nothing file" }");
            Console.WriteLine("Welcome to console app to handle students!");

            if (input != null)
            {
                studentService.ReadCsvFile(input.FullName);

                if (name.Length > 0)
                {
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"Results of search student by name: {name}");
                    studentService.PrintStudents(studentService.SearchStudentsByName(name));
                }
                else if (gender.Length > 0 && type.Length > 0)
                {
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"Results of search student by gender: {gender} and type: {type}");
                    studentService.PrintStudents(studentService.SearchStudentsByGenderAndType(gender, type));
                }
                else if (type.Length > 0)
                {
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"Results of search student by type: {type}");
                    studentService.PrintStudents(studentService.SearchStudentsByTypeOfStudent(type));
                }
            }
            else
            {
                Console.WriteLine("Do you like use fake data of students to try the program? yes/no");

                string userChoose = Console.ReadLine();
                switch (userChoose.ToLower())
                {
                    case "no":
                        goto Start;
                    case "yes":
                        mockTool.InsertStudents();
                        studentService.GetAllStudents();
                        goto Start;
                }
            }

        Start:

            Console.WriteLine("Welcome to console app to handle students!");

            Console.WriteLine("Please select an option");
            Console.WriteLine("Option 1: Get all students");
            Console.WriteLine("Option 2: Insert student");
            Console.WriteLine("Option 3: Delete student");
            Console.WriteLine("Option 4: Searh student by name");
            Console.WriteLine("Option 5: Searh student by type");
            Console.WriteLine("Option 6: Searh student by gender and type");
            Console.WriteLine("Option 7: Exit");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            int userChoise = int.Parse(Console.ReadLine());

            switch (userChoise)
            {
                case 1:
                    studentService.PrintStudents(studentService.GetAllStudents());
                    goto Start;
                case 2:
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Please, insert the name of your student");
                    string nameOfStudent = Console.ReadLine();
                    Console.WriteLine("Please, insert kind of student, you can choose between kinder, elementary, high and university");
                    string studentOfType = Console.ReadLine();
                    Console.WriteLine("Please, insert the gender of your student, you can choose between M(Male) and F(Female)");
                    string genderOfStudent = Console.ReadLine();
                    Student result = studentService.RegisterStudent(nameOfStudent, studentOfType, genderOfStudent);
                    Console.WriteLine("Your student was stored successfully with the following information:");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Student ID                             Name            kind of student         Gender of student          Enrollment date");
                    Console.WriteLine($"{result.Id}   {result.Name}           {result.StudentType}                    {result.Gender}                        {result.EnrollmentDate}");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                    goto Start;
                case 3:
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Please, insert the ID of your student to delete");
                    string studentId = Console.ReadLine();
                    studentService.RemoveStudent(studentId);
                    goto Start;
                case 4:
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Please, insert the student name to search");
                    string nameStudent = Console.ReadLine();
                    studentService.PrintStudents(studentService.SearchStudentsByName(nameStudent));
                    goto Start;
                case 5:
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Please, insert the type of student to search,  you can choose between kinder, elementary, high and university");
                    string studentType = (Console.ReadLine()).ToLower();
                    studentService.PrintStudents(studentService.SearchStudentsByTypeOfStudent(studentType));
                    goto Start;
                case 6:
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Searh student by gender and type");
                    Console.WriteLine("Please, insert kind of student to search, you can choose between kinder, elementary, high and university");
                    string typeStudent = (Console.ReadLine()).ToLower();
                    Console.WriteLine("Please, insert the gender of your student to search, you can choose between M(Male) and F(Female)");
                    string genderStudent = (Console.ReadLine()).ToUpper();
                    studentService.PrintStudents(studentService.SearchStudentsByGenderAndType(genderStudent, typeStudent));
                    goto Start;
                case 7:
                    break;
                default:
                    Console.WriteLine($"Your choise {userChoise} is invalid");
                    goto Start;
            }

            Decide:
            Console.WriteLine("Are you sure you want to  exit the program?, yes/no");
            string userDesicion = Console.ReadLine();
            switch(userDesicion.ToLower())
            {
                case "no":
                    goto Start;
                case "yes":
                    break;
                default:
                    Console.WriteLine($"Your choise {userChoise} is invalid");
                    goto Decide;
            }
        }

        private static void RegisterServices()

        {

            var collection = new ServiceCollection();

            collection.AddScoped<IStudentRepository, StudentRepository>();
            collection.AddScoped<IStudentService, StudentService>();
            collection.AddScoped<IMockTool, MockTool>();

            _serviceProvider = collection.BuildServiceProvider();

        }

        private static void DisposeServices()

        {

            if (_serviceProvider == null)

            {

                return;

            }

            if (_serviceProvider is IDisposable)

            {

                ((IDisposable)_serviceProvider).Dispose();

            }

        }
    }
}
