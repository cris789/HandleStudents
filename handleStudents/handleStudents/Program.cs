using handleStudents.Models;
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

        /// <param name="intOption">An option whose argument is parsed as an int</param>
        /// <param name="boolOption">An option whose argument is parsed as a bool</param>
        /// <param name="fileOption">An option whose argument is parsed as a FileInfo</param>
        static void Main(string name = "", string type = "", string gender = "", FileInfo input = null)
        {
            RegisterServices();

            var studentService = _serviceProvider.GetService<IStudentService>();
            var mockTool = _serviceProvider.GetService<IMockTool>();

            DisposeServices();

            Console.WriteLine($"The value of name is: {name}");
            Console.WriteLine($"The value of type is: {type}");
            Console.WriteLine($"The value of gender is: {gender}");
            Console.WriteLine($"The value of fileOption is: {input?.FullName ?? "C:/Users/Cristian/Desktop/Heber/st/st/MOCK_DATA.csv" }");
            Console.WriteLine("The value for --int-option ");
            studentService.ReadCsvFile("C:/Users/Cristian/Desktop/Heber/st/st/MOCK_DATA.csv");

            Console.WriteLine("Welcome to console app to handle students!");

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
