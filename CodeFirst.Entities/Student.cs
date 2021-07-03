using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeFirst.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
