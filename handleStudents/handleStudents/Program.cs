using handleStudents.Models;
using handleStudents.Repository;
using handleStudents.Services;
using handleStudents.Tools;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace handleStudents
{
    class Program
    {
        private static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();

            var studentService = _serviceProvider.GetService<IStudentService>();
            var mockTool = _serviceProvider.GetService<IMockTool>();


            DisposeServices();

            Console.WriteLine("Welcome to console app to handle students!");
            mockTool.InsertStudents();

        Start:
            Console.WriteLine("Please select an option");
            Console.WriteLine("Option 1: Get all students");
            Console.WriteLine("Option 2: Insert student");
            Console.WriteLine("Option 3: Delete student");
            Console.WriteLine("Option 4: Searh student by name");
            Console.WriteLine("Option 5: Searh student by type");
            Console.WriteLine("Option 6: Searh student by gender and type");
            Console.WriteLine("Option 7: Exit");
            Console.WriteLine("Please select an option");
            int userChoise = int.Parse(Console.ReadLine());

            switch (userChoise)
            {
                case 1:
                    studentService.GetAllStudents();
                    goto Start;
                case 2:
                    studentService.RegisterStudent();
                    goto Start;
                case 3:
                    studentService.RemoveStudent();
                    goto Start;
                case 4:
                    studentService.SearchStudentsByName();
                    goto Start;
                case 5:
                    studentService.SearchStudentsByTypeOfStudent();
                    goto Start;
                case 6:
                    studentService.SearchStudentsByGenderAndElementary();
                    goto Start;
                case 7:
                    break;
                default:
                    Console.WriteLine($"Your choise {userChoise} is invalid");
                    goto Start;
            }

            Decide:
            Console.WriteLine("Are you sure you want to  exit the program?, YES or NO?");
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
