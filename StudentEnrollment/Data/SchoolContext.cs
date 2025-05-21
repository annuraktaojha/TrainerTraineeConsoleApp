using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using StudentEnrollment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Data
{
    public class SchoolContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=INBMWN177550\\SQLEXPRESS;Initial Catalog=SchoolDBEFCORE;Integrated " +
                "Security=True;Encrypt=False;Trust Server Certificate=True")
                 .LogTo(Console.WriteLine, LogLevel.Information);
        }

        public DbSet<StudentEnrollment.Entities.StudentEnrollment> StudentEnrollments { get; set; }

        public DbSet<Student>   Students { get; set; }
         
        public DbSet<Course> Courses { get; set; }

        //public DbSet<OnsiteCourse> OnsiteCourses { get; set; }

        //public DbSet<OnlineCourse> OnlineCourses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add your model creating code here

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentEnrollment.Entities.StudentEnrollment>(entity =>
            {
                // The EnrollmentId is the primary key.
                entity.HasKey(e => e.EnrollmentId);

                // The StudentId and CourseId are foreign keys. 
                entity.HasOne(e => e.Student)
                    .WithMany(s => s.StudentEnrollments)
                    .HasForeignKey(e => e.StudentId).IsRequired();

                entity.HasOne(e => e.Course)
                    .WithMany(c => c.StudentEnrollments)
                    .HasForeignKey(e => e.CourseId).IsRequired();

                // The EnrollmentDate column is required.
                entity.Property(e => e.EnrollmentDate)
                    .IsRequired();
            });

            //modelBuilder.Entity<Course>()
            //    .HasDiscriminator<string>("Type")
            //    .HasValue<OnlineCourse>("OnlineCourse")
            //    .HasValue<OnsiteCourse>("OnsiteCourse");
            //modelBuilder.Entity<OnlineCourse>().ToTable("OnlineCourses");
            //modelBuilder.Entity<OnsiteCourse>().ToTable("OnsiteCourses");
            //modelBuilder.Entity<OnlineCourse>().HasBaseType<Course>();
            //modelBuilder.Entity<OnsiteCourse>().HasBaseType<Course>();
           // modelBuilder.Entity<Course>().UseTpcMappingStrategy();
            modelBuilder.Entity<Course>().UseTphMappingStrategy();


            // Configure Instructor entity
            modelBuilder.Entity<Instructor>()
                .HasKey(i => i.Id);

            // Configure OfficeAssignment entity
            modelBuilder.Entity<OfficeAssignment>()
                .HasKey(o => o.Id);

            // Configure one-to-one relationship with CASCADE delete
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.OfficeAssignment)
                .WithOne(o => o.Instructor)
                .HasForeignKey<OfficeAssignment>(o => o.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public Dictionary<int, decimal?> GetAverageCourseGrades()
        {
            return StudentEnrollments
                    .GroupBy(e=>e.CourseId)
                    .Select(static g => new {
                           CourseId = g.Key,
                           AverageGrade= g.Average(e => e.Grade)
                    })
                    .ToDictionary(x=>x.CourseId,x=>x.AverageGrade);
              

        }
    }
}
