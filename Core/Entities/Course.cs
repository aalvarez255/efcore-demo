﻿using System.Collections.Generic;

namespace Core.Entities
{
    public class Course : BaseEntity
    {
        public Course()
        {
            Students = new List<CourseStudent>();
        }

        public string Code { get; set; }

        public virtual ICollection<CourseStudent> Students { get; set; }
    }
}