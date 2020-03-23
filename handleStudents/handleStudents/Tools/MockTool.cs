using handleStudents.Models;
using handleStudents.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace handleStudents.Tools
{
    public class MockTool :IMockTool
    {
        private readonly IStudentRepository _studentRepository;

        public MockTool(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void InsertStudents()
        {
            Student sonnie = new Student();
            sonnie.Id = Guid.NewGuid();
            sonnie.Name = "sonnie";
            sonnie.StudentType = StudentType.kinder;
            sonnie.Gender = Gender.M;
            sonnie.EnrollmentDate = new DateTime(2016, 3, 28, 13, 6, 55);
            Student ceciley = new Student();
            ceciley.Id = Guid.NewGuid();
            ceciley.Name = "ceciley";
            ceciley.StudentType = StudentType.elementary;
            ceciley.Gender = Gender.F;
            ceciley.EnrollmentDate = new DateTime(2019, 10, 25, 8, 44, 55);
            Student james = new Student();
            james.Id = Guid.NewGuid();
            james.Name = "james";
            james.StudentType = StudentType.elementary;
            james.Gender = Gender.M;
            james.EnrollmentDate = new DateTime(2017, 6, 1, 21, 30, 55);
            Student kelsy = new Student();
            kelsy.Id = Guid.NewGuid();
            kelsy.Name = "kelsy";
            kelsy.StudentType = StudentType.kinder;
            kelsy.Gender = Gender.F;
            kelsy.EnrollmentDate = new DateTime(2008, 7, 22, 15, 14, 55);
            Student mia = new Student();
            mia.Id = Guid.NewGuid();
            mia.Name = "mia";
            mia.StudentType = StudentType.university;
            mia.Gender = Gender.F;
            mia.EnrollmentDate = new DateTime(2003, 11, 4, 11, 34, 55);
            Student shawn = new Student();
            shawn.Id = Guid.NewGuid();
            shawn.Name = "shawn";
            shawn.StudentType = StudentType.university;
            shawn.Gender = Gender.M;
            shawn.EnrollmentDate = new DateTime(2005, 3, 3, 8, 22, 55);
            Student sophia = new Student();
            sophia.Id = Guid.NewGuid();
            sophia.Name = "sophia";
            sophia.StudentType = StudentType.high;
            sophia.Gender = Gender.F;
            sophia.EnrollmentDate = new DateTime(2009, 12, 25, 9, 44, 55);
            Student alair = new Student();
            alair.Id = Guid.NewGuid();
            alair.Name = "alair";
            alair.StudentType = StudentType.high;
            alair.Gender = Gender.M;
            alair.EnrollmentDate = new DateTime(2014, 10, 24, 18, 44, 55);
            Student caroline = new Student();
            caroline.Id = Guid.NewGuid();
            caroline.Name = "caroline";
            caroline.StudentType = StudentType.kinder;
            caroline.Gender = Gender.F;
            caroline.EnrollmentDate = new DateTime(2016, 1, 24, 15, 42, 55);
            Student claus = new Student();
            claus.Id = Guid.NewGuid();
            claus.Name = "claus";
            claus.StudentType = StudentType.elementary;
            claus.Gender = Gender.M;
            claus.EnrollmentDate = new DateTime(2010, 12, 4, 18, 44, 55);
            _studentRepository.AddNewStudent(sonnie);
            _studentRepository.AddNewStudent(ceciley);
            _studentRepository.AddNewStudent(james);
            _studentRepository.AddNewStudent(kelsy);
            _studentRepository.AddNewStudent(mia);
            _studentRepository.AddNewStudent(shawn);
            _studentRepository.AddNewStudent(sophia);
            _studentRepository.AddNewStudent(alair);
            _studentRepository.AddNewStudent(caroline);
            _studentRepository.AddNewStudent(claus);
        }
    }
}
