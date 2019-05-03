﻿using System;

namespace Core.Entities
{
    public class CourseStudent : BaseEntity
    {
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }

        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
