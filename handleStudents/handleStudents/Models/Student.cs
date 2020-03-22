using System;
using System.Collections.Generic;
using System.Text;

namespace handleStudents.Models
{
    public enum StudentType
    {
        kinder,
        elementary,
        high,
        university
    }

    public enum Gender
    {
        M,
        F
    }

    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public StudentType  StudentType { get; set; }
        public Gender Gender { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
