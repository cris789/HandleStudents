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
        Male,
        Female,
        Other
    }

    public class Student
    {
        private string Name { get; set; }
        private string LastName { get; set; }
        public StudentType  StudentType { get; set; }
        public Gender Gender { get; set; }
    }
}
