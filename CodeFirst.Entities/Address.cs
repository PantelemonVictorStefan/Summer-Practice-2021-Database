using System;

namespace CodeFirst.Entities
{
    public class Address : BaseEntity
    {
        public string City { get; set; }

        public string Street { get; set; }

        public Guid StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
