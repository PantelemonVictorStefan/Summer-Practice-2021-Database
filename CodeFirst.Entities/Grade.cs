using System;

namespace CodeFirst.Entities
{
    public class Grade : BaseEntity
    {
        public int Value { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }
    }
}
