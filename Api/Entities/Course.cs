using System.Collections.Generic;

namespace Api.Entities
{
    public abstract class Course : BaseEntity
    {
        public Course()
        {
            Students = new List<CourseStudent>();
        }

        public string Code { get; set; }

        public virtual ICollection<CourseStudent> Students { get; set; }
    }
}
