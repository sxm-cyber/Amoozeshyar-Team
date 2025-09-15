using System;
using Amoozeshyar.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Amoozeshyar.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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
                .HasMany(u => u.CoursesTeaching)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<IdentityRole<int>>().HasData(

                new IdentityRole<int> { Id=1,Name="Admin",NormalizedName="ADMIN",ConcurrencyStamp=Guid.NewGuid().ToString()},
                new IdentityRole<int> { Id=2,Name= "Teacher",NormalizedName="TEACHER",ConcurrencyStamp=Guid.NewGuid().ToString() },
                new IdentityRole<int> { Id=3,Name= "Student",NormalizedName="STUDENT",ConcurrencyStamp=Guid.NewGuid().ToString() }

                );

        }
    }
}


