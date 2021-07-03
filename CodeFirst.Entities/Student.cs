using System;

namespace CodeFirst.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual Address Address { get; set; }
    }
}
