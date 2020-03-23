using handleStudents.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandleStudentUniTest.Tools
{
   public class MockStudents
    {
        public void InsertStudents()
        {
            Student michael = new Student();
            michael.Id = Guid.NewGuid();
            michael.Name = "michael";
            michael.StudentType = StudentType.kinder;
            michael.Gender = Gender.M;
            michael.EnrollmentDate = new DateTime(2016, 3, 28, 13, 6, 55);
            Student elena = new Student();
            elena.Id = Guid.NewGuid();
            elena.Name = "Elena";
            elena.StudentType = StudentType.elementary;
            elena.Gender = Gender.F;
            elena.EnrollmentDate = new DateTime(2019, 10, 25, 8, 44, 55);
            Student robert = new Student();
            robert.Id = Guid.NewGuid();
            robert.Name = "robert";
            robert.StudentType = StudentType.elementary;
            robert.Gender = Gender.M;
            robert.EnrollmentDate = new DateTime(2017, 6, 1, 21, 30, 55);
            Student ariana = new Student();
            ariana.Id = Guid.NewGuid();
            ariana.Name = "Ariana";
            ariana.StudentType = StudentType.kinder;
            ariana.Gender = Gender.F;
            ariana.EnrollmentDate = new DateTime(2008, 7, 22, 15, 14, 55);
            Student serenity = new Student();
            serenity.Id = Guid.NewGuid();
            serenity.Name = "serenity";
            serenity.StudentType = StudentType.university;
            serenity.Gender = Gender.F;
            serenity.EnrollmentDate = new DateTime(2003, 11, 4, 11, 34, 55);
            Student jerome = new Student();
            jerome.Id = Guid.NewGuid();
            jerome.Name = "jerome";
            jerome.StudentType = StudentType.university;
            jerome.Gender = Gender.M;
            jerome.EnrollmentDate = new DateTime(2005, 3, 3, 8, 22, 55);
            Student sadie = new Student();
            sadie.Id = Guid.NewGuid();
            sadie.Name = "Sadie";
            sadie.StudentType = StudentType.high;
            sadie.Gender = Gender.F;
            sadie.EnrollmentDate = new DateTime(2009, 12, 25, 9, 44, 55);
            Student milton = new Student();
            milton.Id = Guid.NewGuid();
            milton.Name = "milton";
            milton.StudentType = StudentType.high;
            milton.Gender = Gender.M;
            milton.EnrollmentDate = new DateTime(2014, 10, 24, 18, 44, 55);
            Student madeline = new Student();
            madeline.Id = Guid.NewGuid();
            madeline.Name = "Madeline";
            madeline.StudentType = StudentType.kinder;
            madeline.Gender = Gender.F;
            madeline.EnrollmentDate = new DateTime(2016, 1, 24, 15, 42, 55);
            Student jack = new Student();
            jack.Id = Guid.NewGuid();
            jack.Name = "jack";
            jack.StudentType = StudentType.elementary;
            jack.Gender = Gender.M;
            jack.EnrollmentDate = new DateTime(2010, 12, 4, 18, 44, 55);
        }

        public IEnumerable<Student> GetStudents()
        {
            Student milton = new Student();
            milton.Id = Guid.NewGuid();
            milton.Name = "milton";
            milton.StudentType = StudentType.high;
            milton.Gender = Gender.M;
            milton.EnrollmentDate = new DateTime(2014, 10, 24, 18, 44, 55);
            Student madeline = new Student();
            madeline.Id = Guid.NewGuid();
            madeline.Name = "Madeline";
            madeline.StudentType = StudentType.kinder;
            madeline.Gender = Gender.F;
            madeline.EnrollmentDate = new DateTime(2016, 1, 24, 15, 42, 55);
            Student jack = new Student();
            jack.Id = Guid.NewGuid();
            jack.Name = "jack";
            jack.StudentType = StudentType.elementary;
            jack.Gender = Gender.M;
            jack.EnrollmentDate = new DateTime(2010, 12, 4, 18, 44, 55);

            List<Student> students = new List<Student>();
            students.Add(milton);
            students.Add(madeline);
            students.Add(jack);
            return students;
        }

        public IEnumerable<Student> GetStudentsbyGenderAndType()
        {
            Student robert = new Student();
            robert.Id = Guid.NewGuid();
            robert.Name = "robert";
            robert.StudentType = StudentType.elementary;
            robert.Gender = Gender.M;
            robert.EnrollmentDate = new DateTime(2017, 6, 1, 21, 30, 55);
            Student jack = new Student();
            jack.Id = Guid.NewGuid();
            jack.Name = "jack";
            jack.StudentType = StudentType.elementary;
            jack.Gender = Gender.M;
            jack.EnrollmentDate = new DateTime(2010, 12, 4, 18, 44, 55);

            List<Student> students = new List<Student>();
            students.Add(robert);
            students.Add(jack);
            return students;
        }

        public IEnumerable<Student> GetStudentsbyName()
        {
            Student milton = new Student();
            milton.Id = Guid.NewGuid();
            milton.Name = "milton";
            milton.StudentType = StudentType.high;
            milton.Gender = Gender.M;
            milton.EnrollmentDate = new DateTime(2014, 10, 24, 18, 44, 55);
            Student michael = new Student();
            michael.Id = Guid.NewGuid();
            michael.Name = "michael";
            michael.StudentType = StudentType.kinder;
            michael.Gender = Gender.M;
            michael.EnrollmentDate = new DateTime(2016, 3, 28, 13, 6, 55);

            List<Student> students = new List<Student>();
            students.Add(milton);
            students.Add(michael);
            return students;
        }

        public IEnumerable<Student> GetStudentsbyTypeofStudent()
        {
            Student sadie = new Student();
            sadie.Id = Guid.NewGuid();
            sadie.Name = "Sadie";
            sadie.StudentType = StudentType.high;
            sadie.Gender = Gender.F;
            sadie.EnrollmentDate = new DateTime(2009, 12, 25, 9, 44, 55);
            Student milton = new Student();
            milton.Id = Guid.NewGuid();
            milton.Name = "milton";
            milton.StudentType = StudentType.high;
            milton.Gender = Gender.M;
            milton.EnrollmentDate = new DateTime(2014, 10, 24, 18, 44, 55);

            List<Student> students = new List<Student>();
            students.Add(sadie);
            students.Add(milton);
            return students;
        }
    }
}
