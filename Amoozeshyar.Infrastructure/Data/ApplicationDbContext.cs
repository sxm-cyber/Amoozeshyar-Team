using Amoozeshyar.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Amoozeshyar.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser , IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Course>()
                .HasMany(c => c.Enrollments)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.EnrollmentTeaching)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);



            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole<Guid>
                {
                    Id = Guid.NewGuid(),
                    Name = "Teacher",
                    NormalizedName = "TEACHER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole<Guid>
                {
                    Id = Guid.NewGuid(),
                    Name = "Student",
                    NormalizedName = "STUDENT",
                    ConcurrencyStamp = Guid.NewGuid().ToString()

                });
        }
    }
}


