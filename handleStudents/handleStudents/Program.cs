using handleStudents.Models;
using handleStudents.Repository;
using handleStudents.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace handleStudents
{
    class Program
    {
        private static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //StudentRepository repository = new StudentRepository();
            //StudentService studentService = new StudentService();
            //Student student = new Student();
            //student.Id = Guid.NewGuid();
            //student.Name = "jino";
            //student.StudentType = StudentType.elementary;
            //student.Gender = Gender.M;
            //Student student2 = new Student();
            //student2.Id = Guid.NewGuid();
            //student2.Name = "alex";
            //student2.StudentType = StudentType.kinder;
            //student2.Gender = Gender.M;
            //Student r = repository.AddNewStudent(student);
            //Student rr = repository.AddNewStudent(student2);
            //Console.WriteLine($"{r.Id} {r.Name} {r.StudentType} {r.Gender} {r.EnrollmentDate}");


            RegisterServices();

            var studentService = _serviceProvider.GetService<IStudentService>();


            DisposeServices();

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
