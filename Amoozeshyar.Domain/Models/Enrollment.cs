using System;
using System.Globalization;
using Amoozeshyar.Domain.Common;

namespace Amoozeshyar.Domain.Models
{
    public class Enrollment : BaseEntity
    {
        public string Semester { get; private set; } = "Fall";

        public int MaxStudents { get; private set; } = 30;

        public double? Grade { get; private set; }

        public DateTime? EnrolledAt { get; private set; } = GetPersianNow();

        public bool IsFinalized { get; private set; } = false;


        public Guid TeacherId { get; private set; }
        public ApplicationUser Teacher { get; private set; }


        public Guid StudentId { get; private set; }
        public ApplicationUser? Student { get; private set; }

        public Guid CourseId { get; private set; }
        public Course? Course { get; private set; }

        private Enrollment() { }

        public Enrollment(Guid studentId, Guid courseId, Guid teacherId, Guid createdBy)
            : base(createdBy)
        {
            StudentId = studentId;
            CourseId = courseId;
            TeacherId = teacherId;
        }

        public void SetGrade(double grade, bool finalized = false)
        {
            Grade = grade;
            IsFinalized = finalized;
        }
    }
}
