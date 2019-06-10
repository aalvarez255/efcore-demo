using System;
using System.Collections.Generic;

namespace Api.Entities
{
    public class StudentAddress : BaseEntity
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
