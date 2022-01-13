using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zadanie1_Kozera.Models;

namespace Zadanie1_Kozera.Data
{
    public class Zadanie1_KozeraContext : DbContext
    {
        public Zadanie1_KozeraContext (DbContextOptions<Zadanie1_KozeraContext> options)
            : base(options)
        {
        }

        public DbSet<Zadanie1_Kozera.Models.Movie> Movie { get; set; }

        public DbSet<Zadanie1_Kozera.Models.Tabelka> Tabelka { get; set; }

        public DbSet<Zadanie1_Kozera.Models.Aktor> Aktor { get; set; }



        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }


        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<JobHierarchy> jobHierarchies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<Tabelka>().ToTable("tabelka");
            modelBuilder.Entity<Aktor>().ToTable("Aktor");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");

            modelBuilder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });

            modelBuilder.Entity<Job>().ToTable("Job");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<JobHierarchy>().ToTable("JobHierarchy");
        }




    }
}
