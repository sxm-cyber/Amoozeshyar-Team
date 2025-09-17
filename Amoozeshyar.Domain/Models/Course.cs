using System;
using System.Collections.Generic;
using Amoozeshyar.Domain.Common;

namespace Amoozeshyar.Domain.Models
{
    public class Course : BaseEntity
    {
       

        public string Name { get; private set; } = string.Empty;

        public string Code { get; private set; } = string.Empty;

        public int Units { get; private set; }

        public string? Description { get; private set; }

        public ApplicationUser? Teacher { get; private set; }

        public ICollection<Enrollment>? Enrollments { get; private set; }

        private Course() { }

        public Course(string name, string code, int units, Guid createdBy, string? description = null)
            : base(createdBy)
        {
            Name = name;
            Code = code;
            Units = units;
            Description = description;
        }

        public void UpdateCourse(string name, string code, int units)
        {
            Name = name;
            Code = code;
            Units = units;
        }
    }
}
