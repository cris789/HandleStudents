using handleStudents.Models;
using handleStudents.Repository;
using handleStudents.Services;
using HandleStudentUniTest.Tools;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HandleStudentUniTest.ServicesUnitest
{
    public class StudentServiceTest
    {
        [Fact]
        public void Register_Student_Return_Student()
        {
            Student alan = new Student();
            alan.Name = "alan";
            alan.Gender = Gender.M;
            alan.StudentType = StudentType.elementary;
            alan.EnrollmentDate = DateTime.Now;

            String name = "alan";
            String gender = "M";
            String typeStudent = "elementary";

            var mockStudentRepository = new Moq.Mock<IStudentRepository>();
            mockStudentRepository.Setup(x => x.AddNewStudent(It.IsAny<Student>())).Returns(alan);
            StudentService studentService = new StudentService(mockStudentRepository.Object);

            var result = studentService.RegisterStudent(name, typeStudent, gender);

            Assert.IsType<Student>(result);

        }

        [Fact]
        public void Get_AllStudents_Return_All_Students() 
        {
            MockStudents mockStudents = new MockStudents();

            var mockStudentRepository = new Moq.Mock<IStudentRepository>();
            mockStudentRepository.Setup(x => x.GetAllStudents()).Returns(mockStudents.GetStudents());
            StudentService studentService = new StudentService(mockStudentRepository.Object);
            var result = studentService.GetAllStudents();
            Assert.NotNull(result);
        }

        [Fact]
        public void Remove_Student_Return_True()
        {
            string id = "765b7824-4ebf-4e8d-8b41-00bf1c9bdb43";
            var mockStudentRepository = new Moq.Mock<IStudentRepository>();
            mockStudentRepository.Setup(x => x.DeleteStudent(It.IsAny<String>())).Returns(true);
            StudentService studentService = new StudentService(mockStudentRepository.Object);
            var result = studentService.RemoveStudent(id);
            Assert.True(result);
        }

        [Fact]
        public void Remove_Student_Return_False()
        {
            string id = "765b7824-4ebf-4e8d-8b41-00bf1c9bdb45";
            var mockStudentRepository = new Moq.Mock<IStudentRepository>();
            mockStudentRepository.Setup(x => x.DeleteStudent(It.IsAny<String>())).Returns(false);
            StudentService studentService = new StudentService(mockStudentRepository.Object);
            var result = studentService.RemoveStudent(id);
            Assert.False(result);
        }

        [Fact]
        public void Search_Students_By_Gender_And_Type_Return_Students_Founded()
        {
            MockStudents mockStudents = new MockStudents();
            string gender = "m";
            string typeOfStudent = "elemenetary";

            var mockStudentRepository = new Moq.Mock<IStudentRepository>();
            mockStudentRepository.Setup(x => x.GetStudentsByGenderAndType(It.IsAny<String>(), It.IsAny<String>())).Returns(mockStudents.GetStudentsbyGenderAndType());
            StudentService studentService = new StudentService(mockStudentRepository.Object);
            var result = studentService.SearchStudentsByGenderAndType(gender, typeOfStudent);
            Assert.NotNull(result);
        }

        [Fact]
        public void Search_Students_By_Name_Return_Students_Founded()
        {
            MockStudents mockStudents = new MockStudents();
            string name = "mi";

            var mockStudentRepository = new Moq.Mock<IStudentRepository>();
            mockStudentRepository.Setup(x => x.GetStudentsByName(It.IsAny<String>())).Returns(mockStudents.GetStudentsbyName());
            StudentService studentService = new StudentService(mockStudentRepository.Object);
            var result = studentService.SearchStudentsByName(name);
            Assert.NotNull(result);
        }

        [Fact]
        public void Search_Students_ByType_Of_Student_Return_Students_Founded()
        {
            MockStudents mockStudents = new MockStudents();
            string typeStudent = "kinder";

            var mockStudentRepository = new Moq.Mock<IStudentRepository>();
            mockStudentRepository.Setup(x => x.GetStudentsByTypeOfStudent(It.IsAny<String>())).Returns(mockStudents.GetStudentsbyTypeofStudent());
            StudentService studentService = new StudentService(mockStudentRepository.Object);
            var result = studentService.SearchStudentsByTypeOfStudent(typeStudent);
            Assert.NotNull(result);
        }

        [Fact]
        public void Add_Student_From_Csv_File_Return_Student()
        {
            string name = "kelly";
            string gender = "F";
            string typeStudent = "kinder".ToLower();
            string enrollment = "20120412182348";
            Student kelly = new Student();
            kelly.Id = Guid.Parse("765b7824-4ebf-4e8d-8b41-00bf1c9bdb43");
            kelly.Name = "kelly";
            kelly.StudentType = (StudentType)Enum.Parse(typeof(StudentType), typeStudent.ToLower());
            kelly.Gender = (Gender)Enum.Parse(typeof(Gender), gender.ToUpper());
            kelly.EnrollmentDate = DateTime.ParseExact(enrollment, "yyyyMMddHHmmssFFF", null);


            var mockStudentRepository = new Moq.Mock<IStudentRepository>();
            mockStudentRepository.Setup(x => x.AddNewStudent(It.IsAny<Student>())).Returns(kelly);
            StudentService studentService = new StudentService(mockStudentRepository.Object);
            var result = studentService.AddStudentFromCsvFile(name, gender, typeStudent, enrollment);
            Assert.IsType<Student>(result);
        }
    }
}
