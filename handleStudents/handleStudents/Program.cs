using handleStudents.Models;
using handleStudents.Repository;
using System;

namespace handleStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            StudentRepository repository = new StudentRepository();
            Student student = new Student();
            student.Id = Guid.NewGuid();
            student.Name = "jino";
            student.StudentType = StudentType.elementary;
            student.Gender = Gender.M;
            Student student2 = new Student();
            student2.Id = Guid.NewGuid();
            student2.Name = "alex";
            student2.StudentType = StudentType.kinder;
            student2.Gender = Gender.M;
            Student r = repository.AddNewStudent(student);
            Student rr = repository.AddNewStudent(student2);
            Console.WriteLine($"{r.Id} {r.Name} {r.StudentType} {r.Gender} {r.EnrollmentDate}");
            
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
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Student ID                             Name       kind of student    Gender      Enrollment date" );
                    foreach ( Student user in repository.GetAllStudents() ) 
                    {
                        Console.WriteLine($"{user.Id}   {user.Name}       {user.StudentType}              {user.Gender}           {user.EnrollmentDate}");
                    }
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    goto Start;
                case 2:
                    Student x = new Student();
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Please, insert the name of your student");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please, insert kind of student, you can choose between kinder, elementary, high and university");
                    string studentType = Console.ReadLine();
                    var typeStudent = (StudentType)Enum.Parse(typeof(StudentType), studentType);
                    Console.WriteLine("Please, insert the gender of your student, you can choose between M(Male) and F(Female)");
                    string genderStudent = Console.ReadLine();
                    var typeStudentGender = (Gender)Enum.Parse(typeof(Gender), genderStudent);
                    x.Id = Guid.NewGuid();
                    x.Name = name;
                    x.StudentType = typeStudent;
                    x.Gender = typeStudentGender;
                    Student resullt = repository.AddNewStudent(x);
                    Console.WriteLine("Your student was stored successfully with the following information:");
                    Console.WriteLine("Student ID                             Name       kind of student    Gender      Enrollment date");
                    Console.WriteLine($"{resullt.Id}   {resullt.Name}       {resullt.StudentType}               {resullt.Gender}        {resullt.EnrollmentDate}");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    goto Start;
                case 3:
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Please, insert the ID of your student to delete");
                    string studentId = Console.ReadLine();
                    repository.DeleteStudent(studentId);
                    Console.WriteLine("Student ID                             Name       kind of student    Gender      Enrollment date");
                    foreach (Student user in repository.GetAllStudents())
                    {
                        Console.WriteLine($"{user.Id}   {user.Name}       {user.StudentType}              {user.Gender}        {user.EnrollmentDate}");
                    }
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    goto Start;
                case 4:
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Please, insert the student name to search");
                    string nameStudent = Console.ReadLine();
                    Console.WriteLine("Student ID                             Name       kind of student    Gender      Enrollment date");
                    foreach (Student user in repository.GetStudentsByName(nameStudent))
                    {
                        Console.WriteLine($"{user.Id}   {user.Name}       {user.StudentType}              {user.Gender}        {user.EnrollmentDate}");
                    }
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    goto Start;
                case 5:
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Please, insert the type fo student search,  you can choose between kinder, elementary, high and university");
                    string studentType2 = (Console.ReadLine()).ToLower();
                    Console.WriteLine("Student ID                             Name       kind of student    Gender      Enrollment date");
                    foreach (Student user in repository.GetStudentsByTypeOfStudent(studentType2))
                    {
                        Console.WriteLine($"{user.Id}   {user.Name}       {user.StudentType}              {user.Gender}        {user.EnrollmentDate}");
                    }
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    goto Start;
                case 6:
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Searh student by gender and type");
                    Console.WriteLine("Please, insert kind of student, you can choose between kinder, elementary, high and university");
                    string studentType3 = (Console.ReadLine()).ToLower();
                    Console.WriteLine("Please, insert the gender of your student, you can choose between M(Male) and F(Female)");
                    string genderStudent2 = (Console.ReadLine()).ToUpper();
                    foreach (Student user in repository.GetStudentsByGenderAndElementary(genderStudent2, studentType3))
                    {
                        Console.WriteLine($"{user.Id}   {user.Name}       {user.StudentType}              {user.Gender}        {user.EnrollmentDate}");
                    }
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    goto Start;
                case 7:
                    break;
                default:
                    Console.WriteLine($"Your choise {userChoise} is invalid");
                    goto Start;
            }

            Decide:
            Console.WriteLine("Do you want to do another operation YES or NO?");
            string userDesicion = Console.ReadLine();
            switch(userDesicion.ToLower())
            {
                case "yes":
                    goto Start;
                case "no":
                    break;
                default:
                    Console.WriteLine($"Your choise {userChoise} is invalid");
                    goto Decide;
            }
        }
    }
}
